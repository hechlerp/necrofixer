using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartController : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite currentSprite;
    SpriteRenderer renderer;
    Color ogColor;
  
    public string partName;
    AnimalParts ap;
    public string baseAnimal;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        currentSprite = renderer.sprite;
        ap = GameObject.Find("GlobalScripts").GetComponent<AnimalParts>();
        ogColor = renderer.color;

    }

    public void onClick()
    {
        renderer.color = ogColor;
        updateSprite(ap.getRandomSprite(baseAnimal, currentSprite.name, partName));
    }

   

    

    public void updateSprite(Sprite sprite)
    {
        currentSprite = sprite;
        GetComponent<SpriteRenderer>().sprite = sprite;
      
        renderer.color = ogColor;
    }

    private void OnMouseEnter()
    {

        renderer.color = Color.yellow;

    }

    private void OnMouseExit()
    {
        
        
        renderer.color = ogColor;
    }

}
