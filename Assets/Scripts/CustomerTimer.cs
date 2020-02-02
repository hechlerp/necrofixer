using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    TimerClock timer;
    // Start is called before the first frame update
    void Start() {
        TimerClock Testtimer = new TimerClock(gameObject);
        timer = TimerControllerManager.GetTimer(gameObject);
        timer.SetupTimer(300f);
        timer.PauseTimer();
    }

    public void startTimer() {
        timer.ResetTimer();
        timer.ResumeTimer();
    }

    void stopTimer() {
        timer.PauseTimer();
        // do something
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.IsTimerEnabled && timer.TimeCount > 0) {
            Debug.Log(timer.TimeCount);
        } else if (timer.IsTimerEnabled) {
            stopTimer();
        }
    }
}
