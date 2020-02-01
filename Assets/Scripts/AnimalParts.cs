using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalParts : MonoBehaviour
{
    List<string> bodyPartNames;
    Dictionary<string, Sprite> spriteDict;
    Dictionary<string, List<string>> partNames;
    Dictionary<string, string> animalAlignments;
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
        spriteDict = new Dictionary<string, Sprite>();
        partNames = new Dictionary<string, List<string>>();
        Vector2 originPosition = new Vector2(0, 0);
        Vector2 centerAnchor = new Vector2(0.5f, 0.5f);
        Sprite entry;

        foreach (string bodyPartName in bodyPartNames) {
            loadedTextures = Resources.LoadAll("BodyParts/" + bodyPartName);
            List<string> partNamesList = new List<string>();
            foreach (Object texture in loadedTextures) {
                if (!spriteDict.TryGetValue(texture.name, out entry)) {
                    Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(originPosition, spriteSize), centerAnchor);
                    sprite.name = texture.name;
                    spriteDict.Add(texture.name, sprite);
                    partNamesList.Add(texture.name);
                }
            }
            partNames.Add(bodyPartName, partNamesList);
        }
        animalAlignments = new Dictionary<string, string>() {
            {"Cat", "CU" },
            {"Dog", "CU" },
            {"Unicorn", "CU" },
            {"Dragon", "D"},
            {"Mantis", "D" },
            {"Griffin", "D" },
            {"Swordfish", "D" },
            {"Crow", "CR" },
            {"Human", "CR" },
            {"Octopus", "CR" }
        };
    }

    public Dictionary<string, string> getAnimalAlignments() {
        return animalAlignments;
    }

    public Sprite getSprite(string partName) {
        Sprite entry;
        if (spriteDict.TryGetValue(partName, out entry)) {
            return entry;
        } else {
            return null;
        }
    }

    public Sprite getRandomSprite(string baseAnimal, string currentName, string partName) {
        string randomName = getWeightedRandomName(baseAnimal, currentName, partName);
        return spriteDict[randomName];
    }

    public string getWeightedRandomName(string baseAnimal, string currentName, string partName) {
        string currentAnimal = currentName.Split('-')[2];
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
        string compositeName = baseAnimal + "-" + partName + "-" + chosenAnimal;
        return partNames[partName].Find(animalPartName => animalPartName == compositeName);
    }
}
