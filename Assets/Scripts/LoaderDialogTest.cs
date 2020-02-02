using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderDialogTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dialog.TextLoader.LoadDialog();
        FindObjectOfType<ToolUI.UI_Dialog>().DialogShow(5);
    }

  
}
