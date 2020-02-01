﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    float netScore;
    List<float> roundScores;
    CustomerManager cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CustomerManager>();
        netScore = 0;
        roundScores = new List<float>();
    }

    public void scoreRound() {
        GameObject customer = cm.getCurrentCustomer();
        CustomerController cc = customer.GetComponent<CustomerController>();
        List<GameObject> petParts = cc.getPetGOs();
        Dictionary<string, string> alignments = GetComponent<AnimalParts>().getAnimalAlignments();
        string customerAlignment = cc.alignment;
        float score = 0;
        foreach (GameObject petPart in petParts) {
            string animal = petPart.name.Split('-')[2];
            string animalAlignment = alignments[animal];
            if (animalAlignment == customerAlignment) {
                score++;
            }
        }
        // time deductions
        roundScores.Add(score);
    }
}