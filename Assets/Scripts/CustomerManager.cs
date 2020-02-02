using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> customers;
    public GameObject witchAdvisor;
    public GameObject progressButton;
    public Vector2 customerPos;
    int currentCustomerIdx;
    GameObject currentCustomer;
    CustomerTimer ct;
    string currentCustomerName;
    void Start()
    {
        ct = GameObject.Find("Timer").GetComponent<CustomerTimer>();
        currentCustomerIdx = -1;
        currentCustomer = null;
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
        witchAdvisor.SetActive(true);
        progressButton.SetActive(false);
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
        if (ct.getTime() > -1) {
            ct.stopTimer();
        }
        currentCustomer.GetComponent<CustomerController>().disablePet();
        GetComponent<Scoring>().scoreRound();
        // dialogue
        Destroy(currentCustomer);
        showReview();
    }

    void startCustomerCycle() {
        currentCustomer = Instantiate(customers[currentCustomerIdx]);
        currentCustomerName = customers[currentCustomerIdx].name;
        currentCustomer.transform.position = customerPos;
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
