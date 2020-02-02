using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public List<string> petParts;
    public GameObject basePart;
    public string animalBase;
    public List<Vector3> partPositions;
    public List<Vector3> partScale;
    public string alignment;
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

    public List<GameObject> getPetGOs() {
        return petGOs;
    }

    void createPet() {
        // currently, as it's built, every customer has their own controller, so the else will never happen.
        if (petGOs.Count == 0) {
            for (int i = 0; i < petParts.Count; i++) {
                GameObject instantiatedPart = Instantiate(basePart);
                Sprite sprite = ap.getSprite(animalBase + "_" + petParts[i]);
                instantiatedPart.GetComponent<SpriteRenderer>().sprite = sprite;
                instantiatedPart.transform.position = partPositions[i];
                instantiatedPart.transform.localScale = partScale[i];
                instantiatedPart.name = sprite.name;
                if (sprite.name.Contains("body")) {
                    Destroy(instantiatedPart.GetComponent<BoxCollider2D>());
                    Destroy(instantiatedPart.GetComponent<CircleCollider2D>());
                }
                BodyPartController bpc = instantiatedPart.GetComponent<BodyPartController>();
                bpc.baseAnimal = animalBase;
                bpc.partName = petParts[i].Split('_')[0];
                petGOs.Add(instantiatedPart);
            }
        } else {
            for (int i = 0; i < petGOs.Count; i++) {
                Sprite sprite = ap.getSprite(petParts[i]);
                GameObject petGO = petGOs[i];
                BodyPartController bpc = petGO.GetComponent<BodyPartController>();
                bpc.baseAnimal = animalBase;
                bpc.updateSprite(sprite);
                bpc.partName = petParts[i].Split('_')[0];
                petGO.name = sprite.name;
                petGO.transform.position = partPositions[i];
                petGO.transform.localScale = partScale[i];
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
