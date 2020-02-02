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
    public System.Action onFinishDialogue;

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
        string nextPrompt = dialog.sourceTextName + count.ToString();
        dialog.DialogShow(customerManager.gameObject.GetComponent<DialogueController>().getDialogueByID(nextPrompt));
        determineButtonText();
    }
    public void DonePressed() {
        onFinishDialogue();
    }

    public void determineButtonText() {
        int nextItem = count + 1;
        int id = customerManager.gameObject.GetComponent<DialogueController>().getDialogueByID(dialog.sourceTextName + nextItem.ToString());
        if (id > -1) {
            isNext = true;
        } else {
            isNext = false;
        }
    }

}
