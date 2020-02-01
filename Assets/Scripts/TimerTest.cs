using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    TimerClock timer;
    // Start is called before the first frame update
    void Start()
    {
      TimerClock Testtimer= new TimerClock(this.gameObject);
      timer = TimerControllerManager.GetTimer(this.gameObject);
        timer.SetupTimer(10f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer.TimeCount);
    }
}
