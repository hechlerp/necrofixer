using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCustomerBtn : MonoBehaviour
{
    CustomerManager cm;
    bool hovering;
    private void Awake() {
        cm = GameObject.Find("GlobalScripts").GetComponent<CustomerManager>();
        hovering = false;
    }

    private void Update() {
        if (hovering && Input.GetMouseButtonUp(0)) {
            transform.parent.gameObject.SetActive(false);
            cm.finishReview();
        }
    }

    private void OnMouseEnter() {
        hovering = true;
    }

    private void OnMouseExit() {
        hovering = false;
    }
}
