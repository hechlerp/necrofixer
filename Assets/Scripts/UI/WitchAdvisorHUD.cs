using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WitchAdvisorHUD : MonoBehaviour
{
    Scoring sc;
    DialogueController dc;
    CustomerManager cm;
    public bool isFinalScore;
    private void Awake() {
        sc = GameObject.Find("GlobalScripts").GetComponent<Scoring>();
        dc = GameObject.Find("GlobalScripts").GetComponent<DialogueController>();
        cm = GameObject.Find("GlobalScripts").GetComponent<CustomerManager>();
        isFinalScore = false;
    }

    void showRoundScore() {
        float roundScore = sc.getRoundScore();
        float reviewScore;
        string dialogueText;
        if (roundScore == 0) {
            reviewScore = 1;
            dialogueText = dc.getDialogueByName(cm.getCurrentCustomerName() + "_" + "Timeout");
        } else {
            reviewScore = roundScore % 2 == 0 ? roundScore - 1 : roundScore;
            dialogueText = dc.getDialogueByName(cm.getCurrentCustomerName() + "_" + reviewScore);
        }
        transform.GetChild(0).GetComponent<Text>().text = dialogueText;
        transform.parent.GetChild(2).GetComponent<WitchAdvisorStars>().setStars(reviewScore);
    }

    void showFinalScore() {
        float finalScore = sc.getFinalScore();
        float reviewScore;
        string dialogueText;
        reviewScore = finalScore % 2 == 0 ? finalScore - 1 : finalScore;
        dialogueText = dc.getDialogueByName("Final" + "_" + reviewScore);
        // dialogue text
        transform.GetChild(0).GetComponent<Text>().text = dialogueText;
        // next customer button
        transform.parent.GetChild(1).GetComponent<NextCustomerBtn>().isFinal = true;
        transform.parent.GetChild(2).GetComponent<WitchAdvisorStars>().setStars(reviewScore);
    }

    private void OnEnable() {
        if (isFinalScore) {
            showFinalScore();
        } else {
            showRoundScore();
        }
    }

    private void OnDisable() {
        transform.GetChild(0).GetComponent<Text>().text = "";
    }
}
