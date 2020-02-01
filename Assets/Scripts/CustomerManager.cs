using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> customers;
    public Vector2 customerPos;
    int currentCustomerIdx;
    GameObject currentCustomer;
    void Start()
    {
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

    void endCurrentCustomerCycle() {
        currentCustomer.GetComponent<CustomerController>().disablePet();
        GetComponent<Scoring>().scoreRound();
        // dialogue
        Destroy(currentCustomer);
        if (currentCustomerIdx < customers.Count) {
            startCustomerCycle();
        } else {
            GetComponent<GameController>().endGame();
        }
    }

    void startCustomerCycle() {
        currentCustomer = Instantiate(customers[currentCustomerIdx]);
        currentCustomer.transform.position = customerPos;
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
