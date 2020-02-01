using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalParts : MonoBehaviour
{
    List<string> bodyPartNames;
    Dictionary<string, Sprite> textureDict;
    Dictionary<string, List<string>> partNames;
    Object[] loadedTextures;
    public Vector2 spriteSize;
    public List<string> animalWeighting;

    void Awake()
    {
        bodyPartNames = new List<string> ();
        bodyPartNames.Add("Front Legs");
        bodyPartNames.Add("Back Legs");
        bodyPartNames.Add("Body");
        bodyPartNames.Add("Head");
        bodyPartNames.Add("Tail");
        textureDict = new Dictionary<string, Sprite>();
        partNames = new Dictionary<string, List<string>>();
        Vector2 originPosition = new Vector2(0, 0);
        Vector2 centerAnchor = new Vector2(0.5f, 0.5f);
        Sprite entry;

        foreach (string bodyPartName in bodyPartNames) {
            loadedTextures = Resources.LoadAll("BodyParts/" + bodyPartName);
            List<string> partNamesList = new List<string>();
            foreach (Object texture in loadedTextures) {
                if (!textureDict.TryGetValue(texture.name, out entry)) {
                    Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(originPosition, spriteSize), centerAnchor);
                    sprite.name = texture.name;
                    textureDict.Add(texture.name, sprite);
                    partNamesList.Add(texture.name);
                }
            }
            partNames.Add(bodyPartName, partNamesList);
        }
    }

    public Sprite getSprite(string partName) {
        Sprite entry;
        if (textureDict.TryGetValue(partName, out entry)) {
            return entry;
        } else {
            return null;
        }
    }

    public Sprite getRandomSprite(string currentName, string partName) {
        string randomName = getWeightedRandomName(currentName, partName);
        return textureDict[randomName];
    }

    public string getWeightedRandomName(string currentName, string partName) {
        string currentAnimal = currentName.Split('-')[0];
        int randomizedPercentage = Random.Range((int)0, (int)100);
        string chosenAnimal = "";
        int currentTotal = 0;
        for (int i = 0; i < animalWeighting.Count; i++) {
            string[] animalEntry = animalWeighting[i].Split('-');
            int weight = int.Parse(animalWeighting[i].Split('-')[1]);
            string animalName = animalEntry[0];
            currentTotal += weight;
            if (currentAnimal != animalName && randomizedPercentage < currentTotal) {
                i = animalWeighting.Count;
                chosenAnimal = animalName;
            }
        }
        return partNames[partName].Find(animalPartName => animalPartName == chosenAnimal + "-" + partName);
    }
}
