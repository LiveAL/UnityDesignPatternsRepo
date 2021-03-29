/*
 * Ashton Lively
 * Follower.cs
 * Assignment 8
 * Contains methods to determine how a follower feels about the player and
 * update the game accordingly. 
 */
using UnityEngine;
using UnityEngine.UI;

public abstract class Follower : MonoBehaviour
{
    public enum Mood { HAPPY, UPSET, NEUTRAL};
    public int approvalPoints = 5;
        
    public enum Action { HURT, HELP };
    public enum ActionReciever { CHILD, ROYALTY, MURDERER, PEASENT, ANIMAL };

    /// <summary>
    /// React to the player's actions
    /// </summary>
    /// <param name="action">Action type performed.</param>
    /// <param name="reciever">Type of person that recieved the action. </param>
    public void React(Action action, ActionReciever reciever)
    {
        if (CheckPartyStatus(approvalPoints))
        {
            switch (DetermineMood(action, reciever))
            {
                case Mood.HAPPY:
                    Happy();
                    break;
                case Mood.UPSET:
                    Upset();
                    break;
                case Mood.NEUTRAL:
                    Neutral();
                    break;
            }

            DisplayApprovalStatus();
        }
    }

    public Text reaction;
    public Image approvalIcon1;
    public Image approvalIcon2;
    public Image approvalIcon3;

    public Sprite likes;
    public Sprite dislikes;
    public Sprite neutral;

    /// <summary>
    /// Set common values of UI 
    /// </summary>
    /// <param name="infoPanel"></param>
    public void SetUI(string name)
    {
        // Instantiate UI for this follower
        GameObject infoPrefab = Resources.Load<GameObject>("Prefabs/Follower Info");
        GameObject followersPanel = GameObject.Find("Followers");
        GameObject infoPanel = Instantiate(infoPrefab, followersPanel.transform);

        // Set the approval icons
        approvalIcon1 = infoPanel.transform.Find("Approval1").GetComponent<Image>();
        approvalIcon2 = infoPanel.transform.Find("Approval2").GetComponent<Image>();
        approvalIcon3 = infoPanel.transform.Find("Approval3").GetComponent<Image>();

        // Set the status text
        reaction = infoPanel.transform.Find("Reaction").Find("Text").GetComponent<Text>();

        // Set the name 
        infoPanel.transform.Find("Name").GetComponent<Text>().text = name;

        // Set up the sprites used for showing approval rating
        dislikes = Resources.Load<Sprite>("Sprites/bad");
        likes = Resources.Load<Sprite>("Sprites/good");
        neutral = Resources.Load<Sprite>("Sprites/neutral");
    }

    /// <summary>
    /// Follower is happy with the player
    /// </summary>
    void Happy()
    {
        // Add to current trust 
        approvalPoints++;
        approvalPoints = Mathf.Clamp(approvalPoints, 0, 10);

        reaction.text = "Approves.";
    }

    /// <summary>
    /// Follower is unhappy with the player
    /// </summary>
    void Upset()
    {
        approvalPoints--;
        approvalPoints = Mathf.Clamp(approvalPoints, 0, 10);

        reaction.text = "Disapproves.";
    }

    /// <summary>
    /// Follower does not care either way.
    /// </summary>
    void Neutral()
    {
        reaction.text = "Neutral.";
    }

    void DisplayApprovalStatus()
    {
        // Set the UI visuals to reflect new feelings
        if (approvalPoints == 5) // neutral
        {
            approvalIcon1.sprite = neutral;
            approvalIcon2.gameObject.SetActive(false);
        }
        else if (approvalPoints <= 4 && approvalPoints >= 3) // disliked
        {
            approvalIcon1.sprite = dislikes;
            approvalIcon2.gameObject.SetActive(false);
        }
        else if (approvalPoints >= 1 && approvalPoints <= 2) // hated
        {
            approvalIcon2.sprite = dislikes;
            approvalIcon2.gameObject.SetActive(true);
        }
        else if (approvalPoints < 1) // extremely hated
        {
            approvalIcon3.sprite = dislikes;
            approvalIcon3.gameObject.SetActive(true);
        }
        else if (approvalPoints <= 7 && approvalPoints >= 6) // respected
        {
            approvalIcon1.sprite = likes;
            approvalIcon2.gameObject.SetActive(false);
        }
        else if (approvalPoints <= 9 && approvalPoints >= 8) // friends
        {
            approvalIcon2.sprite = likes;
            approvalIcon2.gameObject.SetActive(true);

            approvalIcon3.gameObject.SetActive(false);
        }
        else if (approvalPoints > 9) // trusted friends
        {
            approvalIcon3.sprite = likes;
            approvalIcon3.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Determine if the character is still in the party
    /// </summary>
    /// <param name="points">Current amount of approval points the player has.</param>
    public abstract bool CheckPartyStatus(int points);

    /// <summary>
    /// How the follower feels about the situation
    /// </summary>
    /// <param name="action">Action type performed.</param>
    /// <param name="reciever">Type of person that recieved the action. </param>
    /// <returns> The mood the follower has about what happened. </returns>
    public virtual Mood DetermineMood(Action action, ActionReciever receiver)
    {
        return Mood.NEUTRAL;
    }
}
