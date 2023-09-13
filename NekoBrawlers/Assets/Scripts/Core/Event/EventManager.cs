using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Event
{
    public enum EventType
    {

    }


    public static class EventManager
    {
        private static Dictionary<EventType, Action<object>> EventSystem = new Dictionary<EventType, Action<object>>();

        public static void SubscribeToEvent(EventType type, Action<object> func)
        {
            if (!EventSystem.ContainsKey(type))
            {
                EventSystem[type] = new Action<object>(func);
            }
            else
            {
                EventSystem[type] += func;
            }
        }

        public static void UnsubscribeToEvent(EventType type, Action<object> func)
        {
            if (EventSystem.ContainsKey(type))
            {
                EventSystem[type] -= func;
            }
        }

        public static void TriggerEvent(EventType type, object data = null)
        {
            if (EventSystem.ContainsKey(type))
                EventSystem[type]?.Invoke(data);
            else
                Debug.LogWarning("No subscriber for " + type);
        }
    }
}