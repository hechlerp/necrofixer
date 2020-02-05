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
    MusicController levelMusic;

    GameObject SwapAnimation;
    private Animator anim;

    AudioSource soundEffect;

    private bool _hasClicked = false;

    public bool HasClicked{
        get {return _hasClicked;}
        set {_hasClicked = value;}
    }


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
        soundEffect = GetComponent<AudioSource>();

    }

    public void onClick()
    {
        renderer.color = ogColor;
        _hasClicked = true;
        updateSprite(ap.getRandomSprite(baseAnimal, currentSprite.name, partName));
    }

   

    

    public void updateSprite(Sprite sprite)
    {
        currentSprite = sprite;
        GetComponent<SpriteRenderer>().sprite = sprite;
      
        renderer.color = ogColor;

        //changing music based on update
        levelMusic.PartsCheck();
        anim.StopPlayback();
        anim.Play("Swap", 0,0);
        soundEffect.Play();        
        
        //anim.play();


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
