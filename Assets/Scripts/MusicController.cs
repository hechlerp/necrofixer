using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    FMOD.Studio.EventInstance LevelMusic;
    CustomerManager cm;
    bool isPlaying;
    
   
   //variables for the specific tracks
  public float dog = 0f;
  public float cat = 1f;
   public float dragon = 0f;
   public float unicorn = 0f;
   public float mantis = 0f;
   public float human = 0f;
   public float griffin = 0f;
   public float swordfish = 0f;
   public float octopus = 0f;
     
   // in house variables
    public float creepy = 0f;
    public float gameOver = 0f;
    public float gameStart = 1f;



    // Start is called before the first frame update
   
    void Start()
    {
    //finding the global scripts object to get the list of body parts
    cm = GameObject.Find("GlobalScripts").GetComponent<CustomerManager>();
    //creating an instance the the audio we want
    
  if(isPlaying == false){
      LevelMusic = FMODUnity.RuntimeManager.CreateInstance ("event:/Music/LevelMusic");
      LevelMusic.start();
    
    isPlaying = true;
      Debug.Log("This is already playing");
  }

    
    //starting the correct loop at the top of the level
      LevelMusic.setParameterByName ("GameOver", gameOver);
      LevelMusic.setParameterByName ("GameStart",gameStart);
      LevelMusic.setParameterByName ("Creepy", creepy);

    //set cat track on
      LevelMusic.setParameterByName ("Cat",cat);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
 
    public void PartsCheck()
    {
     // Debug.Log("Testing the music changes");
      GameObject customer = cm.getCurrentCustomer();
      CustomerController cc = customer.GetComponent<CustomerController>();
      List<GameObject> petParts = cc.getPetGOs();
      //get the list of parts
      foreach (GameObject petPart in petParts) {
            BodyPartController bpc = petPart.GetComponent<BodyPartController>();
            string petPartName = bpc.GetComponent<SpriteRenderer>().sprite.name;
            string[] splitName = petPartName.Split('_');

            if (splitName[1] != "body") {
                string animal = splitName[2];
                
                LevelMusic.setParameterByName (animal, 1f);
                Debug.Log ("this is the part for " + animal);
                
             }
                  
  }

 
}

public void resetPet(){

LevelMusic.setParameterByName ("Cat",cat);
LevelMusic.setParameterByName ("Dragon",0f);
LevelMusic.setParameterByName ("Dog",0f);
LevelMusic.setParameterByName ("Unicorn",0f);
LevelMusic.setParameterByName ("Mantis",0f);
LevelMusic.setParameterByName ("Human",0f);
LevelMusic.setParameterByName ("Griffin",0f);
LevelMusic.setParameterByName ("Swordfish",0f);
LevelMusic.setParameterByName ("Octopus",0f);
LevelMusic.setParameterByName ("Crow", 0f);
}

}
