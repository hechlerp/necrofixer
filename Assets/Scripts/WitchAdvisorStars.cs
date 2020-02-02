using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAdvisorStars : MonoBehaviour
{
    Scoring sc;
    private void Awake() {
        sc = GameObject.Find("GlobalScripts").GetComponent<Scoring>();
    }

    private void OnEnable() {
        float roundScore = sc.getRoundScore();
        if (roundScore < 1) {
            roundScore = 1;
        }
        for (int i = 0; i < roundScore; i++) {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void OnDisable() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }
}
