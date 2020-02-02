﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    CustomerManager cm;
    Scoring sc;
    public GameObject witchAdvisor;
    public GameObject dialogueBox;
    public ToolUI.UI_Dialog dialog;
    // not to be confused with Waluigi
    WitchAdvisorHUD wah;
    int gameTimer;

    void Start()
    {
        gameTimer = 0;
        cm = GetComponent<CustomerManager>();
        sc = GetComponent<Scoring>();
        wah = witchAdvisor.transform.GetChild(3).GetComponent<WitchAdvisorHUD>();
    }


    void Update()
    {
        if (gameTimer < 20) {
            gameTimer++;
            if (gameTimer == 20) {
                startGame();
            }
        }
        
    }

    void startGame() {
        dialogueBox.SetActive(true);
        dialog.setFinishAction(cm.progressCustomer);
        dialog.sourceTextName = "IntroText";
        dialogueBox.transform.GetChild(1).GetComponent<ButtonNext>().determineButtonText();
        dialog.DialogShow(GetComponent<DialogueController>().getDialogueByID("IntroText"));
    }

    public void endGame() {
        wah.isFinalScore = true;
        witchAdvisor.SetActive(true);
    }

    public void sendToMenu() {
        SceneManager.LoadScene(0);
    }
}
