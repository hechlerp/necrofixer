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
    private void Awake() {
        sc = GameObject.Find("GlobalScripts").GetComponent<Scoring>();
        dc = GameObject.Find("GlobalScripts").GetComponent<DialogueController>();
        cm = GameObject.Find("GlobalScripts").GetComponent<CustomerManager>();
    }

    private void OnEnable() {
        float roundScore = sc.getRoundScore();
        float reviewScore = roundScore % 2 == 0 ? roundScore - 1 : roundScore;
        string dialogueText = dc.getDialogueByName(cm.getCurrentCustomerName() + "_" + reviewScore);
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogueText;
    }

    private void OnDisable() {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
    }
}
