using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<string, int> dialogueTracker;
    void Start()
    {
        Dialog.TextLoader.LoadDialog();
        dialogueTracker = new Dictionary<string, int>() {
            { "CustomerA_Prompt", 0 },
            { "CustomerA_5", 1 },
            { "CustomerA_3", 2 },
            { "CustomerA_1", 3 },
            { "CustomerA_Timeout", 13 },
            { "CustomerB_Prompt", 4 },
            { "CustomerB_5", 5 },
            { "CustomerB_3", 6 },
            { "CustomerB_1", 7 },
            { "CustomerB_Timeout", 14 },
            { "CustomerC_Prompt", 8 },
            { "CustomerC_5", 9 },
            { "CustomerC_3", 10 },
            { "CustomerC_1", 11 },
            { "CustomerC_Timeout", 15 },
            { "IntroText", 12 },
            { "Final_5", 16 },
            { "Final_3", 17 },
            { "Final_1", 18 },
        };
    }

    public string getDialogueByName(string dialogueKey) {
        return Dialog.TextLoader.GetDialog(dialogueTracker[dialogueKey]);
    }
    public int getDialogueByID(string dialogueKey)
    {
        return dialogueTracker[dialogueKey];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
