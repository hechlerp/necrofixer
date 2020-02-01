﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    CustomerManager cm;
    Scoring sc;
    int gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 0;
        cm = GetComponent<CustomerManager>();
        sc = GetComponent<Scoring>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer++;
        if (gameTimer == 20) {
            cm.progressCustomer();
        }
        
    }

    public void endGame() {
        Debug.Log("IT'S OVAH");
        Debug.Log("Final score: " + sc.getFinalScore());
    }
}
