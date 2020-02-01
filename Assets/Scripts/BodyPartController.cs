using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartController : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite currentSprite;
    public string partName;
    AnimalParts ap;
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>().sprite;
        ap = GameObject.Find("GlobalScripts").GetComponent<AnimalParts>();
    }

    public void onClick() {
        updateSprite(ap.getRandomSprite(currentSprite.name, partName));
    }

    public void updateSprite(Sprite sprite) {
        currentSprite = sprite;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
