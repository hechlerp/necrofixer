/* Timer Controller Manager
 * Used to get timers anywhere
 * 
 * Scott Tongue
 * 2020
 */ 



using System.Collections.Generic;
using UnityEngine;

public static class TimerControllerManager 
{

    static private Dictionary<GameObject, TimerClock> _timerDictionary = new Dictionary<GameObject, TimerClock>();


    static public TimerClock GetTimer(GameObject gameObject)
    {
        if (_timerDictionary.ContainsKey(gameObject))
        {
            return _timerDictionary[gameObject];
  
        }
        return null;
    }

    static public void AddTimer(GameObject gameObject, TimerClock timer)
    {
        if (!_timerDictionary.ContainsKey(gameObject))
        {
            _timerDictionary.Add(gameObject, timer);
        }
        else
        {
            timer.Dispose();
        }
    }

    static public void RemoveTimer(GameObject gameObject)
    {
        if (_timerDictionary.ContainsKey(gameObject))
        {
            _timerDictionary[gameObject].RemoveTimer();
            _timerDictionary.Remove(gameObject);
        }
    }

    static public void ResetAllTimers()
    {
        foreach (var timerclock in _timerDictionary.Values)
        {
            timerclock.ResetTimer();
        }
    }

    static public void PauseAllTimers(bool pauseMe)
    {
        foreach (var timerclock in _timerDictionary.Values)
        {
            timerclock.PauseTimer();
        }
    }

    static public void ClearAllTimers()
    {
        foreach (var timerclock in _timerDictionary.Values)
        {
            timerclock.RemoveTimer();
        }
        _timerDictionary.Clear();
    }

}
