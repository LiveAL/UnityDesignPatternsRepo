/*
 * Ashton Lively
 * GameController.cs
 * Assignment 8
 * Manage the game actions.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Follower[] followers = new Follower[3];

    public GameObject followersMenu;

    private void Start()
    {
        RecruitNew();
    }

    /// <summary>
    /// Recruit new followers
    /// </summary>
    public void RecruitNew()
    {
        // Clear previously made followers
        Transform[] followerMenus = followersMenu.GetComponentsInChildren<Transform>();
        foreach (Transform followerMenu in followerMenus)
        {
            if (followerMenu.gameObject.name != "Followers")
                Destroy(followerMenu.gameObject);
        }

        followers[0] = new FollowerAna();
        followers[1] = new FollowerBryan();
        followers[2] = new FollowerFrank();
    }

    private Follower.Action action;
    private Follower.ActionReciever reciever;

    /// <summary>
    /// Player chooses to hurt or help
    /// </summary>
    public void ActionSelect(string input)
    {
        switch (input)
        {
            case ("hurt"):
                action = Follower.Action.HURT;
                break;
            case ("help"):
                action = Follower.Action.HELP;
                break;
        }
    }

    public void ReceiverSelect(string input)
    {
        switch (input)
        {
            case ("child"):
                reciever = Follower.ActionReciever.CHILD;
                break;
            case ("royalty"):
                reciever = Follower.ActionReciever.ROYALTY;
                break;
            case ("murderer"):
                reciever = Follower.ActionReciever.MURDERER;
                break;
            case ("peasent"):
                reciever = Follower.ActionReciever.PEASENT;
                break;
            case ("animal"):
                reciever = Follower.ActionReciever.ANIMAL;
                break;
        }

        foreach (Follower follower in followers)
        {
            follower.React(action, reciever);
        }
    }
}
