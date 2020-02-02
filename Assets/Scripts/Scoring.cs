using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    List<float> roundScores;
    CustomerManager cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CustomerManager>();
        roundScores = new List<float>();
    }

    public void scoreRound(bool timedOut) {
        GameObject customer = cm.getCurrentCustomer();
        CustomerController cc = customer.GetComponent<CustomerController>();
        List<GameObject> petParts = cc.getPetGOs();
        Dictionary<string, string> alignments = GetComponent<AnimalParts>().getAnimalAlignments();
        string customerAlignment = cc.alignment;
        float score = 1;
        if (timedOut) {
            roundScores.Add(0f);
            return;
        }
        foreach (GameObject petPart in petParts) {
            BodyPartController bpc = petPart.GetComponent<BodyPartController>();
            string petPartName = bpc.GetComponent<SpriteRenderer>().sprite.name;
            string[] splitName = petPartName.Split('_');
            if (splitName[1] != "body") {
                string animal = splitName[2];
                string animalAlignment = alignments[animal];
                if (animalAlignment == customerAlignment) {
                    score++;
                }
            }
        }
        // time deductions
        roundScores.Add(score);
    }

    public float getRoundScore() {
        return roundScores[roundScores.Count - 1];
    }

    public float getFinalScore() {
        float sum = 0;
        foreach(float score in roundScores) {
            sum += score;
        }
        return sum / roundScores.Count;
    }
}
