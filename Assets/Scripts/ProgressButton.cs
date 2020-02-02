using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressButton : MonoBehaviour
{
    CustomerManager cm;
    private void Start() {
        cm = GameObject.Find("GlobalScripts").GetComponent<CustomerManager>();
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonUp(0)) {
            cm.progressCustomer();
        }
    }
}
