using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<string, int> dialogueTracker;
    void Awake()
    {
        Dialog.TextLoader.LoadDialog();
        dialogueTracker = new Dictionary<string, int>() {
            { "CustomerA_Prompt", 0 },
            { "CustomerA_5", 1 },
            { "CustomerA_3", 2 },
            { "CustomerA_1", 3 },
            { "CustomerA_Timeout", 17 },
            { "CustomerB_Prompt", 4 },
            { "CustomerB_5", 5 },
            { "CustomerB_3", 6 },
            { "CustomerB_1", 7 },
            { "CustomerB_Timeout", 18 },
            { "CustomerC_Prompt", 8 },
            { "CustomerC_5", 9 },
            { "CustomerC_3", 10 },
            { "CustomerC_1", 11 },
            { "CustomerC_Timeout", 19 },
            { "CustomerD_Prompt", 27 },
            { "CustomerD_5", 23 },
            { "CustomerD_3", 24 },
            { "CustomerD_1", 25 },
            { "CustomerD_Timeout", 26 },
            { "IntroText", 12 },
            { "IntroText1", 13 },
            { "IntroText2", 14 },
            { "IntroText3", 15 },
            { "IntroText4", 16 },
            { "Final_5", 20 },
            { "Final_3", 21 },
            { "Final_1", 22 },
        };
    }

    public string getDialogueByName(string dialogueKey) {
        return Dialog.TextLoader.GetDialog(dialogueTracker[dialogueKey]);
    }
    public int getDialogueByID(string dialogueKey)
    {
        int val;
        if (dialogueTracker.TryGetValue(dialogueKey, out val)) {
            return val;
        } else {
            return -1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
