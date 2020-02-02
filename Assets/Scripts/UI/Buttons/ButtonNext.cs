using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNext : MonoBehaviour
{

    public ToolUI.UI_Dialog dialog;
    public CustomerManager customerManager;
    private int count = 5;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            NextPressed();
    }
    public void NextPressed()
    {
        count -= 2;
        if (count <= 0)
            count = 5;
        string call = customerManager.CurrentCustomerName + "_" + count.ToString();
        dialog.DialogShow(customerManager.gameObject.GetComponent<DialogueController>().getDialogueByID(call));
    }

}
