using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortCDM.Code
{
    public class PortCallMessageGrouper
    {
        Dictionary<string, List<portCallMessage>> pcmGroups;

        public PortCallMessageGrouper()
        {
            pcmGroups = new Dictionary<string, List<portCallMessage>>();
        }

        public PortCallMessageGrouper(portCallMessage pcm) : this()
        {
           add(pcm);
        }

        public PortCallMessageGrouper(List<portCallMessage> pcms) : this()
        {
            foreach (var pcm in pcms)
            {
                add(pcm);
            }
        }

        public void add(portCallMessage pcm)
        {
            string key = getKey(pcm);
            if (pcmGroups.ContainsKey(key))
            {
                pcmGroups[key].Add(pcm);
            }
            else
            {
                List<portCallMessage> pcms = new List<portCallMessage>();
                pcms.Add(pcm);
                pcmGroups.Add(key, pcms);
            }
        }

        public List< List < portCallMessage > > getGroups()
        {
            return pcmGroups.Values.ToList();
        }

        public static bool isLocationState(portCallMessage pcm)
        {
            return pcm.locationState != null;
        }

        private static string getKey(portCallMessage pcm)
        {
            string key = "";
            if (pcm == null)
                return null;

            key += pcm.portCallId;
            if (isLocationState(pcm))
            {
                LocationState ls = pcm.locationState;
                key += ls.referenceObject.ToString();
                key += ls.time.ToString();
                if (ls.arrivalLocation != null)
                {
                    LocationStateArrivalLocation al = ls.arrivalLocation;
                    if(al.from != null)
                        key += al.from.locationMRN ?? "";
                    if(al.to != null)
                        key += al.to.locationMRN ?? "";
                }
                if (ls.departureLocation != null)
                {
                    LocationStateDepartureLocation dl = ls.departureLocation;
                    if(dl.from != null)
                        key += dl.from.locationMRN ?? "";
                    if(dl.to != null)
                        key += dl.to.locationMRN ?? "";
                }
            }
            else
            {
                ServiceState ss = pcm.serviceState;
                key += ss.serviceObject;
                key += ss.time;
                if (ss.at != null)
                {
                    key += ss.at.locationMRN ?? "";
                }
                else if (ss.between != null)
                {
                    ServiceStateBetween b = ss.between;
                    key += b.from.locationMRN ?? "";
                    key += b.to.locationMRN ?? "";
                }
            }

            return key;
        }
    }
}
