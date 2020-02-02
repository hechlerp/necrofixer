using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimerClock))]
public class TimerTest : MonoBehaviour
{
    TimerClock timer;
    // Start is called before the first frame update
    void Start()
    {
     // TimerClock Testtimer=  this
    //  timer = TimerControllerManager.GetTimer(this.gameObject);
        timer.SetupTimer(10f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer.TimeCount);
    }
}
