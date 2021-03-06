﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PortCDM.Code
{
    public class DepartureMessage
    {
		private static StringBuilder departureMessage = new StringBuilder();

		public static DateTime locationOrService(portCallMessage pcm)
		{
		    if (pcm.locationState != null)
		    {
		        return pcm.locationState.time;
		    }

		    return pcm.serviceState.time;
		}


		public static async Task<string> createDepartureMessage(string shipIMO)
		{
            string portCallID = DataBaseHandler.getPortCallId(shipIMO);
			
            departureMessage.Clear();
			departureMessage.Append("PortCall ID: " + portCallID + "<br />");

			List<portCallMessage> list = await RestHandler.getEvents(portCallID);



			//Sort list based on DateTime time
			list.Sort((x, y) => DateTime.Compare(locationOrService(x), locationOrService(y)));

			foreach (portCallMessage pcm in list)
			{
				appendMessageInfo(pcm);
			}
			addComment("<br />" + portCallID);

            return departureMessage.ToString();
		}


		public static void appendMessageInfo(portCallMessage pcm)
		{
            //APPEND WITH SERVICESTATE TIMESEQUENCE(COMMENCED / COMPLETED)
            if (pcm.serviceState != null)
            {
                ServiceTimeSequence serviceTime = pcm.serviceState.timeSequence;
                if (serviceTime == ServiceTimeSequence.COMMENCED ||
                    serviceTime == ServiceTimeSequence.COMPLETED)
                {
                    addTime(pcm);
                    addObject(pcm);
                    addLocation(pcm);
                    departureMessage.Append(pcm.serviceState.timeSequence + "<br />");
                }
            }
		}

		public static void addTime(portCallMessage pcm)
		{
            //APPEND WITH LOCATIONSTATE TIME
            if (pcm.locationState != null)
			{
				object niceDate = Utils.niceDate(pcm.locationState.time);
				departureMessage.Append(niceDate + " ");
			}
            //APPEND WITH SERVICESTATE TIME
            if (pcm.serviceState != null){
				object niceDate = Utils.niceDate(pcm.serviceState.time);
				departureMessage.Append(niceDate + " ");
			}
		}

		public static void addObject(portCallMessage pcm)
		{
            //APPEND WITH LOCATIONSTATE REFERENCEOBJECT
            if (pcm.locationState != null)
			{
				departureMessage.Append(pcm.locationState.referenceObject + " ");
			}
            //APPEND WITH SERVICESTATE SERVICEOBJECT
            if (pcm.serviceState != null)
			{
				departureMessage.Append(pcm.serviceState.serviceObject + " ");
			}
		}

		public static void addLocation(portCallMessage pcm)
		{
            //APPEND WITH LOCATIONSTATE ARRIVAL(TO AND FROM)
            if (pcm.locationState != null)
			{
				string locationFrom = pcm.locationState.arrivalLocation.from.locationMRN;
				string locationTo = pcm.locationState.arrivalLocation.to.locationMRN;
				departureMessage.Append(NiceString(locationFrom) + " -> " + NiceString(locationTo));
			}

            //APPEND WITH LOCATIONSTATE DEPARTURE(TO AND FROM)
            if (pcm.locationState != null)
			{
				string locationFrom = pcm.locationState.departureLocation.from.locationMRN;
				string locationTo = pcm.locationState.departureLocation.to.locationMRN;
				departureMessage.Append(NiceString(locationFrom) + " -> " + NiceString(locationTo));
			}

            //APPEND WITH SERVICESTATE POSTITION AT
            if (pcm.serviceState != null)
			{
				string locationAt = pcm.serviceState.at.locationMRN;
				departureMessage.Append("at " + NiceString(locationAt) + " ");
			}
		}

		public static void addComment(string portCallId)
		{
			string comment = DataBaseHandler.getComment(portCallId);
			departureMessage.Append("Comments: " + comment);
		}





		//Converts String to a nicer formatted string
		public static string NiceString(string str)
		{
			if (str.Contains("BERTH:"))
			{
				return str.Replace("urn:mrn:stm:location:segot:BERTH:", "");
			}
			if (str.Contains("ANCHORING_AREA"))
			{
				return str.Replace("urn:mrn:stm:location:segot:ANCHORING_AREA:", "AREA ");
			}
			else return "normal:" + str;
		}
    }
}
