using System.Collections.Generic;
using UnityEngine.Events;

namespace BasicEvents
{
    public class BasicEventArgs {

    }

    public static class BasicEventManager
    {
        private class BasicEvent : UnityEvent<BasicEventArgs>
        {
            private int _nonPersistantListeners = 0;
            public int NonPersistantListeners => _nonPersistantListeners;

            public void AddNonPersistantListener(UnityAction<BasicEventArgs> action)
            {
                AddListener(action);
                _nonPersistantListeners++;
            }

            public void RemoveNonPersistantListener(UnityAction<BasicEventArgs> action)
            {
                RemoveListener(action);
                _nonPersistantListeners--;
            }
        }

        private static Dictionary<string, BasicEvent> events = new Dictionary<string, BasicEvent>();

        public static void StartListening(string eventName, UnityAction<BasicEventArgs> action)
        {
            if (events.ContainsKey(eventName))
            {
                events[eventName].AddNonPersistantListener(action);
            }
            else
            {
                BasicEvent newEventInfo = new BasicEvent();
                newEventInfo.AddNonPersistantListener(action);
                events.Add(eventName, newEventInfo);
            }
        }

        public static void StopListening(string eventName, UnityAction<BasicEventArgs> action)
        {
            if (!events.ContainsKey(eventName))
            {
                return;
            }

            events[eventName].RemoveNonPersistantListener(action);

            if (events[eventName].NonPersistantListeners == 0)
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
