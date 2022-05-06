using System.Collections.Generic;
using UnityEngine.Events;

namespace BasicEvents
{
    public class BasicEventArgs { }

    public static class BasicEventManager
    {
        private class BasicEvent : UnityEvent<BasicEventArgs> { }

        private static Dictionary<string, BasicEvent> events = new Dictionary<string, BasicEvent>();

        public static void StartListening(string eventName, UnityAction<BasicEventArgs> action)
        {
            if (events.ContainsKey(eventName))
            {
                events[eventName].AddListener(action);
            }
            else
            {
                BasicEvent newEventInfo = new BasicEvent();
                newEventInfo.AddListener(action);
                events.Add(eventName, newEventInfo);
            }
        }

        public static void StopListening(string eventName, UnityAction<BasicEventArgs> action)
        {
            if (!events.ContainsKey(eventName))
            {
                return;
            }

            events[eventName].RemoveListener(action);
            if (events[eventName].GetPersistentEventCount() == 0)
            {
                events.Remove(eventName);
            }
        }
        public static void PublishEvent(string eventName, BasicEventArgs e)
        {
            if (events.ContainsKey(eventName))
            {
                events[eventName].Invoke(e);
            }
        }
    }
}
