using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressButton : MonoBehaviour
{
    CustomerManager cm;
    bool hovering;
    private void Start() {
        cm = GameObject.Find("GlobalScripts").GetComponent<CustomerManager>();
        hovering = false;
    }

    private void Update() {
        if (hovering && Input.GetMouseButtonUp(0)) {
            cm.progressCustomer();
        }
    }

    private void OnMouseEnter() {
        hovering = true;
    }

    private void OnMouseExit() {
        hovering = false;
    }
}
