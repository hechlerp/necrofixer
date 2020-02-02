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

    public void scoreRound(bool timedOut)
    {
        GameObject customer = cm.getCurrentCustomer();
        CustomerController cc = customer.GetComponent<CustomerController>();
        List<GameObject> petParts = cc.getPetGOs();
        Dictionary<string, string> alignments = GetComponent<AnimalParts>().getAnimalAlignments();
        string customerAlignment = cc.alignment;
        float score = 1;
        if (timedOut)
        {
            foreach (GameObject petPart in petParts)
            {
                BodyPartController bpc = petPart.GetComponent<BodyPartController>();
                bpc.HasClicked = false;
            }
            roundScores.Add(0f);
            return;
        }
        Dictionary<string, float> consistency = new Dictionary<string, float>();
        List<string> consistencyKeys = new List<string>();
        foreach (GameObject petPart in petParts)
        {

            BodyPartController bpc = petPart.GetComponent<BodyPartController>();
            if (bpc.HasClicked)
            {
                string petPartName = bpc.GetComponent<SpriteRenderer>().sprite.name;
                string[] splitName = petPartName.Split('_');
                if (splitName[1] != "body")
                {
                    string animal = splitName[2];
                    string animalAlignment = alignments[animal];
                    if (customerAlignment == "CON")
                    {
                        float animalScore;
                        if (consistency.TryGetValue(animal, out animalScore))
                        {
                            consistency[animal] = consistency[animal] + 1;
                        }
                        else
                        {
                            consistency.Add(animal, 1f);
                            consistencyKeys.Add(animal);
                        }
                    }
                    else if (animalAlignment == customerAlignment)
                    {
                        score++;
                    }
                }
            }
            bpc.HasClicked = false;
        }
        if (customerAlignment == "CON")
        {
            foreach (string animalKey in consistencyKeys)
            {
                if (consistency[animalKey] + 1 > score)
                {
                    score = consistency[animalKey] + 1;
                }
            }
        }
        // time deductions
        roundScores.Add(score);
    }

    public float getRoundScore()
    {
        return roundScores[roundScores.Count - 1];
    }

    public float getFinalScore()
    {
        float sum = 0;
        foreach (float score in roundScores)
        {
            sum += score;
        }
        return Mathf.Floor(sum / roundScores.Count);
    }
}
