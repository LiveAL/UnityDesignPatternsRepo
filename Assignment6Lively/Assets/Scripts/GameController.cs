/*
 * Ashton Lively
 * GameController.cs
 * Assignment 6
 * Use player input to run the game and create new animals
 */
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Hatchery hatchery;
    private enum HatcheryTypes { REPTILE, MAMMAL, AVIAN};

    // Start is called before the first frame update
    void Start()
    {
        CreateNewEgg();
    }

    public Image eggImage;

    /// <summary>
    /// Create a new egg to hatch
    /// </summary>
    public void CreateNewEgg()
    {
        attributes.text = "No attributes yet.";
        HatcheryTypes randHatchery = (HatcheryTypes)Random.Range(0, 3);
        switch(randHatchery)
        {
            case HatcheryTypes.AVIAN:
                hatchery = new AvianHatchery();
                eggImage.GetComponent<Image>().color = Color.blue;
                break;
            case HatcheryTypes.MAMMAL:
                hatchery = new MammalHatchery();
                eggImage.GetComponent<Image>().color = Color.red;
                break;
            case HatcheryTypes.REPTILE:
                hatchery = new ReptileHatchery();
                eggImage.GetComponent<Image>().color = Color.green;
                break;
        }
    }

    public Text attributes;
    public Text hatchedAnimal;
    public Image animalImage;

    public Sprite lionPic;
    public Sprite wolfPic;
    public Sprite deerPic;
    public Sprite falconPic;
    public Sprite hawkPic;
    public Sprite pythonPic;
    public Sprite parrotPic;
    public Sprite alligatorPic;
    public Sprite iguanaPic;

    public void HatchEgg()
    {
        hatchery.HatchAnimal();
        attributes.text = hatchery.AnimalAttributes();
        hatchedAnimal.text = "You hatched a " + hatchery.animal;

        switch (hatchery.animal)
        {
            case "lion":
                animalImage.GetComponent<Image>().sprite = lionPic;
                break;
            case "wolf":
                animalImage.GetComponent<Image>().sprite = wolfPic;
                break;
            case "deer":
                animalImage.GetComponent<Image>().sprite = deerPic;
                break;
            case "falcon":
                animalImage.GetComponent<Image>().sprite = falconPic;
                break;
            case "hawk":
                animalImage.GetComponent<Image>().sprite = hawkPic;
                break;
            case "python":
                animalImage.GetComponent<Image>().sprite = pythonPic;
                break;
            case "parrot":
                animalImage.GetComponent<Image>().sprite = parrotPic;
                break;
            case "alligator":
                animalImage.GetComponent<Image>().sprite = alligatorPic;
                break;
            case "iguana":
                animalImage.GetComponent<Image>().sprite = iguanaPic;
                break;
        }
        
    }
}
