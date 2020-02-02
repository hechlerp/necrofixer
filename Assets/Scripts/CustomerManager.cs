﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> customers;
    public GameObject witchAdvisor;
    public GameObject progressButton;
    public GameObject dialogBox;
    public Vector2 customerPos;
    public ToolUI.UI_Dialog dialog;
    int currentCustomerIdx;
    GameObject currentCustomer;
    CustomerTimer ct;
    string currentCustomerName;
    public string CurrentCustomerName
    {
        get { return currentCustomerName; }
    }
    void Start()
    {
        ct = GameObject.Find("Timer").GetComponent<CustomerTimer>();
        currentCustomerIdx = -1;
        currentCustomer = null;
        dialogBox.SetActive(false);
        progressButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getCurrentCustomer() {
        return currentCustomer;
    }

    public string getCurrentCustomerName() {
        return currentCustomerName;
    }

    void showReview() {
        dialogBox.SetActive(false);
        witchAdvisor.SetActive(true);
        progressButton.SetActive(false);
        dialogBox.SetActive(false);
    }

    public void finishReview() {
        if (currentCustomerIdx < customers.Count) {
            progressButton.SetActive(true);
            startCustomerCycle();
        } else {
            GetComponent<GameController>().endGame();
        }
    }

    void endCurrentCustomerCycle() {
        bool timedOut = ct.getTime() == 0;
        if (ct.getTime() > 0) {
            ct.stopTimer();
        }
        currentCustomer.GetComponent<CustomerController>().disablePet();
        GetComponent<Scoring>().scoreRound(timedOut);
        if (timedOut)
        {
            string callPrompt = currentCustomerName + "_Timeout";
            dialog.DialogShow(this.GetComponent<DialogueController>().getDialogueByID(callPrompt));
        }

        // dialogue
        Destroy(currentCustomer);
        showReview();
    }

    void startCustomerCycle() {
        progressButton.SetActive(true);
        dialogBox.SetActive(true);
        currentCustomer = Instantiate(customers[currentCustomerIdx]);
        currentCustomerName = customers[currentCustomerIdx].name;
        currentCustomer.transform.position = customerPos;
        string callPrompt = currentCustomerName + "_Prompt";
        dialog.DialogShow(this.GetComponent<DialogueController>().getDialogueByID(callPrompt));

        ct.startTimer(progressCustomer);
    }

    public void progressCustomer() {
        currentCustomerIdx++;
        if (currentCustomer != null) {
            endCurrentCustomerCycle();
        } else {
            startCustomerCycle();

        }
    }
}
