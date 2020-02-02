using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartController : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite currentSprite;
    SpriteRenderer renderer;
    Color ogColor;
    bool flash = false;
    public string partName;
    AnimalParts ap;
    public string baseAnimal;
    MusicController levelMusic;

    GameObject SwapAnimation;
    private Animator anim;




    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        currentSprite = renderer.sprite;
        ap = GameObject.Find("GlobalScripts").GetComponent<AnimalParts>();
        ogColor = renderer.color;

        //find the music object in scene
        levelMusic = GameObject.Find("LevelMusic").GetComponent<MusicController>();
        levelMusic.resetPet();

        SwapAnimation = GameObject.Find ("AttachmentEffects");
        anim = SwapAnimation.GetComponent<Animator>();

    }

    public void onClick()
    {
        StopCoroutine(Flash());
        updateSprite(ap.getRandomSprite(baseAnimal, currentSprite.name, partName));
    }

   

    

    public void updateSprite(Sprite sprite)
    {
        currentSprite = sprite;
        GetComponent<SpriteRenderer>().sprite = sprite;
        flash = false;
        renderer.color = ogColor;

        //changing music based on update
        levelMusic.PartsCheck();
        anim.StopPlayback();
        anim.Play("Swap", 0,0);
        
        //anim.play();


    }

    private void OnMouseEnter()
    {
        flash = true;
        StartCoroutine(Flash());

    }

    private void OnMouseExit()
    {
        Debug.Log("stop");
        flash = false;
        renderer.color = ogColor;
    }

    IEnumerator Flash()
    {

        while (flash)
        {
            Debug.Log("yellow");
            renderer.color = Color.yellow;
            yield return new WaitForSeconds(0.1f);
            renderer.color = ogColor;
            yield return new WaitForSeconds(0.1f);
            Debug.Log("normal");
        }
    }
}
