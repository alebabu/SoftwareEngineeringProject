using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PortCDM_Filter;
using System.Timers;

namespace PortCDM_App_Code
{
	public static class Subscriptions
	{
		private static List<string> subscribedQueues = new List<string>();

		private static System.Timers.Timer timer;

		private static void startTimer()
		{
			Console.WriteLine("Starting timer");

			timer = new System.Timers.Timer(10000);
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 10000;
			timer.Enabled = true;
		}

		public static async Task<List<string>> subscribe(string portCallId)
		{
			List<Filter> filter = new List<Filter>();
			filter.Add(new Filter(FilterType.PORT_CALL, portCallId));

			Console.WriteLine("Creating queue with Filter PORTCALL, " + portCallId + "...");

			string queueId = await QueueHandler.createFilteredQueue(filter);

			Console.WriteLine("Queue created with id: " + queueId + ", adding to subscribed list...");

			subscribedQueues.Add(queueId);

			Console.WriteLine("Added " + queueId + " to list of subscriptions");

			startTimer();

			return subscribedQueues;
		}

		private static async void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			Console.WriteLine("Looking for new messages...");
			List<portCallMessage> result = new List<portCallMessage>();

			foreach (string sub in subscribedQueues)
			{
				List<portCallMessage> tmp = await QueueHandler.pollQueue(sub);
				foreach (portCallMessage pcm in tmp)
				{
					Console.WriteLine("Update detected on PortCall: " + pcm.portCallId);
					result.Add(pcm);
				}
			}

			if (result.Count == 0)
			{
				Console.WriteLine("No new updates");
			}
		}
	}
}
