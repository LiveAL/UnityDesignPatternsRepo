/*
 * Ashton Lively
 * GameController.cs
 * Assignment 5
 * Controls the game and manages the created horses.
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// List of horses created
    /// </summary>
    private List<Horse> horses = new List<Horse>();

    /// <summary>
    /// List of active horse buttons in scene
    /// </summary>
    private List<GameObject> horseButtons = new List<GameObject>();

    [Tooltip("Prefab for the horse buttons.")]
    public GameObject horseButton;

    [Tooltip("The UI canvas in the scene.")]
    public Transform uiCanvas;

    // Horse product of two other horses
    private Horse _resultHorse;
    /// <summary>
    /// Button with the result horse contained
    /// </summary>
    private GameObject resultHorseButton;

    // Start is called before the first frame update
    void Start()
    {
        _resultHorse = new Horse();
        CreateResultHorseButton();
        CreateHorseOptions();
    }

    // Update is called once per frame
    void Update()
    {
        // Show horse info hover
        if (Input.GetKeyDown(KeyCode.Space) && HoverController.currentHover != null)
        {
            GameObject hover = HoverController.currentHover.transform.Find("Horse Hover Info").gameObject;

            if (hover.active == true)
            {
                hover.SetActive(false);
            }
            else
            {
                hover.SetActive(true);
            }
        }

        // Breed the horse
        if (Input.GetMouseButtonDown(0) && HoverController.currentHover != null)
        {
            Breed();
        }
    }

    [Tooltip("Text with the body alleles inside.")]
    public Text bodyAlleles;
    [Tooltip("Text with the head alleles inside.")]
    public Text headAlleles;
    [Tooltip("Text with the tail alleles inside.")]
    public Text tailAlleles;

    /// <summary>
    /// Create the resulting horse button and attributes
    /// </summary>
    private void CreateResultHorseButton()
    {
        resultHorseButton = Instantiate(horseButton, uiCanvas);
        resultHorseButton.transform.localPosition = new Vector3(-235.5611f, 90.79448f, 0);
        resultHorseButton.transform.Find("Horse Button").GetComponent<Button>().enabled = false;

        bodyAlleles.text = _resultHorse.GetBodyAllele1().toString() + "     " + _resultHorse.GetBodyAllele2().toString();
        headAlleles.text = _resultHorse.GetHeadAllele1().toString() + "     " + _resultHorse.GetHeadAllele2().toString();
        tailAlleles.text = _resultHorse.GetTailAllele1().toString() + "     " + _resultHorse.GetTailAllele2().toString();

        SetUpHorseButton(_resultHorse, resultHorseButton);
    }

    [Tooltip("Positions of the horse options buttons.")]
    public List<Vector2> horseOptionPositions = new List<Vector2>();

    /// <summary>
    /// Create the options for horse breeding
    /// </summary>
    private void CreateHorseOptions()
    {
        for (int i = 0; i < horseOptionPositions.Count; i++)
        {
            horses.Add(new Horse());
            horseButtons.Add(Instantiate(horseButton, uiCanvas));
            horseButtons[i].transform.localPosition = horseOptionPositions[i];
            SetUpHorseButton(horses[i], horseButtons[i]);
        }
    }

    public Sprite blackBody;
    public Sprite whiteBody;
    public Sprite brownBody;

    public Sprite blackHead;
    public Sprite brownHead;
    public Sprite whiteHead;

    public Sprite longTail;
    public Sprite shortTail;

    /// <summary>
    /// Set up the button hover text and image displayed
    /// </summary>
    /// <param name="horse"></param>
    /// <param name="currentButton"></param>
    private void SetUpHorseButton(Horse horse, GameObject currentButton)
    {
        // Set up hover
        Transform hover = currentButton.transform.Find("Horse Hover Info").transform;
        hover.Find("Body").GetComponent<Text>().text = "Body: " + horse.GetBody().toString();
        hover.Find("Head").GetComponent<Text>().text = "Head: " + horse.GetHead().toString();
        hover.Find("Tail").GetComponent<Text>().text = "Tail: " + horse.GetTail().toString();

        // Set up image 
        Transform button = currentButton.transform.Find("Horse Button").transform;

        if (horse.GetBody().toString() == "Black")
        {
            button.Find("Body Image").GetComponent<Image>().sprite = blackBody;
        }
        else if (horse.GetBody().toString() == "Brown")
        {
            button.Find("Body Image").GetComponent<Image>().sprite = brownBody;
        }
        else
        {
            button.Find("Body Image").GetComponent<Image>().sprite = whiteBody;
        }

        if (horse.GetHead().toString() == "Black")
        {
            button.Find("Head Image").GetComponent<Image>().sprite = blackHead;
        }
        else if (horse.GetHead().toString() == "Brown")
        {
            button.Find("Head Image").GetComponent<Image>().sprite = brownHead;
        }
        else
        {
            button.Find("Head Image").GetComponent<Image>().sprite = whiteHead;
        }


        if (horse.GetTail().toString() == "Long")
        {
            button.Find("Tail Image").GetComponent<Image>().sprite = longTail;
        }
        else if (horse.GetTail().toString() == "Short")
        {
            button.Find("Tail Image").GetComponent<Image>().sprite = shortTail;
        }
        else
        {
            button.Find("Tail Image").GetComponent<Image>().enabled = false;
        }
    }

    /// <summary>
    /// Combine two horses together
    /// </summary>
    private void Breed()
    {
        _resultHorse = new Horse(_resultHorse, horses[horseButtons.IndexOf(HoverController.currentHover)]);

        // Destroy old horses
        Destroy(resultHorseButton);
        foreach (GameObject button in horseButtons)
        {
            Destroy(button);
        }
        horseButtons.Clear();
        horses.Clear();

        // Create new horses
        CreateResultHorseButton();
        CreateHorseOptions();
    }
}
