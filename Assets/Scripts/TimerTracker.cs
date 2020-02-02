using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTracker : MonoBehaviour
{
    CustomerTimer ct;
    Image timerImg;
    // Start is called before the first frame update
    void Awake()
    {
        ct = GameObject.Find("Timer").GetComponent<CustomerTimer>();
        timerImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ct.getTime() > 0) {
            timerImg.fillAmount = (float)ct.getTime() / (float)ct.getMaxTime();
        }
    }
}
