using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject("EventManager");
                instance = go.AddComponent<EventManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    //이벤트와 옵저버를 연결하는 딕셔너리
    private Dictionary<string, Action<object>> _eventDictionary = new Dictionary<string, Action<object>>();

    //이벤트에 옵저버 추가
    public void AddListener(string eventName, Action<object> listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent += listener;
            _eventDictionary[eventName] = listener;
        }
        else
        {
            _eventDictionary.Add(eventName, listener);
        }
    }

    //이벤트에서 오저버 제거
    public void RemoveListener(string eventName, Action<object> listener)
    {
        if(_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent -= listener;
            _eventDictionary[eventName] = listener;
        }
    }

    //이벤트발생(모든 옵저버에게 알림)
    public void TriggerEvent(string eventName, object data = null)
    {
        if(_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent?.Invoke(data);
        }
    }

}
