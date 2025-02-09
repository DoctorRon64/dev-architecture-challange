using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    OnBulletDied = 0
}

public static class EventManager
{
    private Dictionary<EventType, Delegate> eventDictionary = new Dictionary<EventType, Delegate>();

    public void AddListener<T>(EventType type, Action<T> action)
    {
        if (!eventDictionary.ContainsKey(type))
        {
            eventDictionary.Add(type, null);
        }
        eventDictionary[type] = (Action<T>)eventDictionary[type] + action;
    }

    public void RemoveListener<T>(EventType type, Action<T> action)
    {
        if (eventDictionary.ContainsKey(type) && eventDictionary[type] != null)
        {
            eventDictionary[type] = (Action<T>)eventDictionary[type] - action;
        }
    }

    public void InvokeEvent<T>(EventType type, T parameter)
    {
        if (eventDictionary.ContainsKey(type) && eventDictionary[type] != null)
        {
            ((Action<T>)eventDictionary[type])?.Invoke(parameter);
        }
    }

    public class EventManagerParamaterless
    {
        private Dictionary<EventType, System.Action> eventDictionary = new Dictionary<EventType, System.Action>();

        public void AddListener(EventType type, System.Action action)
        {
            if (!eventDictionary.ContainsKey(type))
            {
                eventDictionary.Add(type, null);
            }
            eventDictionary[type] += action;
        }

        public void RemoveListener(EventType type, System.Action action)
        {
            if (eventDictionary.ContainsKey(type) && eventDictionary[type] != null) { }
            eventDictionary[type] -= action;
        }

        public void InvokeEvent(EventType type, System.Action action)
        {
            eventDictionary[type]?.Invoke();
        }
    }
}