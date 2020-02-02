using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCustomerBtn : MonoBehaviour
{
    CustomerManager cm;
    GameController gc;
    public bool isFinal;
    private void Awake() {
        isFinal = false;
        GameObject gs = GameObject.Find("GlobalScripts");
        cm = gs.GetComponent<CustomerManager>();
        gc = gs.GetComponent<GameController>();
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonUp(0)) {
            if (!isFinal) {
                transform.parent.gameObject.SetActive(false);
                cm.finishReview();
            } else {
                gc.sendToMenu();
            }
        }
    }
}
