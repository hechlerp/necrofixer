using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNext : MonoBehaviour
{

    public ToolUI.UI_Dialog dialog;
    public CustomerManager customerManager;
    private int count = 0;
    bool isNext;

    private void OnEnable() {
        count = 0;
        determineButtonText();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
            onButtonPressed();
    }

    public void onButtonPressed() {
        if (isNext) {
            NextPressed();
        } else {
            DonePressed();
        }
    }

    public void NextPressed()
    {
        count++;
        string call = customerManager.CurrentCustomerName + "_" + count.ToString();
        dialog.DialogShow(customerManager.gameObject.GetComponent<DialogueController>().getDialogueByID(call));
    }
    public void DonePressed() {
        customerManager.finishDialogue();
    }

    void determineButtonText() {
        int nextItem = count + 1;
        int id = customerManager.gameObject.GetComponent<DialogueController>().getDialogueByID(dialog.sourceTextName + count);
        if (id > -1) {
            isNext = true;
            transform.GetChild(0).gameObject.GetComponent<Text>().text = "Next";
        } else {
            isNext = false;
            transform.GetChild(0).gameObject.GetComponent<Text>().text = "Done";
        }
    }

}
