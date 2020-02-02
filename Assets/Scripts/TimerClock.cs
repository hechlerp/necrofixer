/* TIMER CLOCK
 * Used for Clock timer events 
 * 
 * Scott Tongue
 * 2020
 */

using System;
using System.Timers;
using UnityEngine;

public class TimerClock 
{
    public TimerClock(GameObject gameObject)
    {
        TimerControllerManager.AddTimer(gameObject, this);
    }

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
    private Timer _timer;

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
        get { return _timer.Enabled;  }
    }

    #region public 

    /// <summary>
    /// Destory Object
    /// USE WITH CATION!!!
    /// </summary>
    public void Dispose()
    {
        TimerRemoved();
        _timer.Dispose();
        this.Dispose();
    }

    /// <summary>
    /// Setup timer and start it
    /// </summary>
    /// <param name="timelimit">Set the amount of time</param>
    public void SetupTimer(float timelimit)
    {
        if (_timer != null)
            return;
      
        _timer = new Timer(100);
        _timer.Elapsed += TimeCountDownEvent;

        _maxTime = timelimit;
        _timeCounter = timelimit;

        TimerStart();
        _timer.Enabled = true;
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
        _timer.Enabled = false;
        TimerPaused();
    }

    /// <summary>
    /// resumer timer
    /// </summary>
    public void ResumeTimer()
    {
        _timer.Enabled = true;
        TimerRemused();
    }

    /// <summary>
    /// remove the timer and destory it
    /// </summary>
    public void RemoveTimer()
    {
        TimerRemoved();
        Dispose();
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
    private  void TimeCountDownEvent(System.Object source, ElapsedEventArgs e)
    {
       if(_timeCounter >= 0f)
        {
            _timeCounter -= 0.1f;
            if(_timeCounter < 0)
            {
                TimerEnded();
                _timeCounter = 0.0f;
                _timer.Enabled = false;
            }
                
        }
    }
    #endregion
}
