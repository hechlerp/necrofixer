using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    CustomerManager cm;
    Scoring sc;
    public GameObject witchAdvisor;
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
        gameTimer++;
        if (gameTimer == 20) {
            cm.progressCustomer();
        }
        
    }

    public void endGame() {
        wah.isFinalScore = true;
        witchAdvisor.SetActive(true);
    }

    public void sendToMenu() {
        SceneManager.LoadScene(0);
    }
}
