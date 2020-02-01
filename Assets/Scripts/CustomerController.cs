using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public List<string> petParts;
    public GameObject basePart;
    public List<Vector3> partPositions;
    AnimalParts ap;
    List<GameObject> petGOs;
    // Start is called before the first frame update
    void Start()
    {
        ap = GameObject.Find("GlobalScripts").GetComponent<AnimalParts>();
        petGOs = new List<GameObject>();
        createPet();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialize() {
        // load dialogue
        createPet();
    }

    void createPet() {
        if (petGOs.Count == 0) {
            for (int i = 0; i < petParts.Count; i++) {
                GameObject instantiatedPart = Instantiate(basePart);
                instantiatedPart.GetComponent<SpriteRenderer>().sprite = ap.getSprite(petParts[i]);
                instantiatedPart.transform.position = partPositions[i];
                instantiatedPart.GetComponent<BodyPartController>().partName = petParts[i].Split('-')[1];
                petGOs.Add(instantiatedPart);
            }
        } else {
            for (int i = 0; i < petGOs.Count; i++) {
                Sprite sprite = ap.getSprite(petParts[i]);
                GameObject petGO = petGOs[i];
                petGO.GetComponent<BodyPartController>().updateSprite(sprite);
                petGO.GetComponent<BodyPartController>().partName = petParts[i].Split('-')[1];
                petGO.transform.position = partPositions[i];
                petGO.SetActive(true);
            }
        }
    }

    public void disablePet() {
        foreach (GameObject petGO in petGOs) {
            petGO.SetActive(false);
        }
    }
}
