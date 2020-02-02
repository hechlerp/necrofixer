using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    //TimerClock timer;
    // Start is called before the first frame update
    int timer;
    int maxTime;
    System.Action callbackFunc;
    void Start() {
        timer = -1;
        maxTime = 3000;
        //TimerClock Testtimer = new TimerClock(gameObject);
        //timer = TimerControllerManager.GetTimer(gameObject);
        //timer.SetupTimer(300f);
        //timer.PauseTimer();
    }

    public void startTimer(System.Action callback) {
        timer = maxTime;
        callbackFunc = callback;
        //timer.ResetTimer();
        //timer.ResumeTimer();
    }

    public void stopTimer() {
        //timer.PauseTimer();
        // do something
        timer = -1;
    }

    public int getTime() {
        return timer;
    }

    public int getMaxTime() {
        return maxTime;
    }

    void timerCallback() {
        timer = -1;
        callbackFunc();
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            timer--;
        } else if (timer == 0) {
            timerCallback();
        }
        //if (timer.IsTimerEnabled && timer.TimeCount > 0) {
        //    Debug.Log(timer.TimeCount);
        //} else if (timer.IsTimerEnabled) {
        //    stopTimer();
        //}
    }
}
