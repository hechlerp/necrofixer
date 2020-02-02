/* TIMER CLOCK
 * Used for Clock timer events 
 * 
 * Scott Tongue
 * 2020
 */

using System;
using System.Collections;
using UnityEngine;

public class TimerClock : MonoBehaviour
{
  

    public event Action TimerStart = delegate { };
    public event Action TimerPaused = delegate { };
    public event Action TimerRemused = delegate { };
    public event Action TimerEnded = delegate { };
    public event Action TimeAdd = delegate { };
    public event Action TimeRemoved = delegate { };

    /// <summary>
    /// USE THIS EVENT TO MAKE SURE YOU DESUB TO THE OTHER delegate other memory leaks happen
    /// Gets called on the dispose function
    /// </summary>
    public event Action TimerRemoved = delegate { };


    private float _timeCounter = 0f; 
    private float _maxTime;
    private bool _timerRunning = false, _timerCreated =false;
    private WaitForSecondsRealtime _delay = new WaitForSecondsRealtime(0.1f);

    public float TimeCount
    {
        get { return _timeCounter; }
    }

    public float MaxTime
    {
        get { return _maxTime; }
    }

    public bool IsTimerEnabled
    {
        get { return _timerRunning;  }
    }


    #region public 

  

    /// <summary>
    /// Setup timer and start it
    /// </summary>
    /// <param name="timelimit">Set the amount of time</param>
    public void SetupTimer(float timelimit)
    {
        if (_timerCreated)
            return;

        _timerCreated = true;
        _timeCounter = timelimit;
        _maxTime = timelimit;
        StartCoroutine(TimerCoutdown());

    }

    /// <summary>
    /// Sets new timelimit
    /// </summary>
    /// <param name="NewTimeLimit">Sets new timelimit</param>
    public void ChangeTimeLimit(float NewTimeLimit)
    {
        _maxTime = NewTimeLimit;

    }

    /// <summary>
    /// Resets the timer to max time limit and pauses it 
    /// </summary>
    public void ResetTimer()
    {
        _timeCounter = _maxTime;
        PauseTimer();
    }

    /// <summary>
    /// Pause timer
    /// </summary>
    public void PauseTimer ()
    {
        _timerRunning = false;
        StopCoroutine(TimerCoutdown());
        TimerPaused();
    }

    /// <summary>
    /// resumer timer
    /// </summary>
    public void ResumeTimer()
    {
        _timerRunning = true;
        StartCoroutine(TimerCoutdown());
        TimerRemused();
    }

    /// <summary>
    /// remove the timer and destory it
    /// </summary>
    public void RemoveTimer()
    {
        TimerRemoved();
        Destroy(this);
    }

    /// <summary>
    /// add time to timer
    /// </summary>
    /// <param name="timeamount"> add time to timer</param>
    public void AddTime (float timeamount)
    {
        _timeCounter += timeamount;
        TimeAdd();
    }

    /// <summary>
    /// remove time from timer
    /// </summary>
    /// <param name="timeamount">remove time amount from timer</param>
    public void RemoveTime(float timeamount)
    {
        _timeCounter -= timeamount;
        TimeRemoved();
    }
    #endregion

    #region private

    IEnumerator TimerCoutdown()
    {

        while (true)
        {
            _timeCounter -= 0.1f;
            if (_timeCounter <= 0f)
                break;
            yield return _delay;
        }
        TimerEnded();
        _timerRunning = false;


    }
    
    #endregion
}
