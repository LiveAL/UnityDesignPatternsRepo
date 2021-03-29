/*
 * Ashton Lively
 * FollowerFrank.cs
 * Assignment 8
 * Update how Frank feels about the player character. 
 */

public class FollowerFrank : Follower
{
    public FollowerFrank()
    {
        SetUI("Frank");
    }

    public override bool CheckPartyStatus(int points)
    {
        if (points < 1)
        {
            reaction.text = "Left the party";
            return false;
        }

        return true;
    }

    public override Mood DetermineMood(Action action, ActionReciever receiver)
    {
        switch (action)
        {
            case Action.HELP:
                switch (receiver)
                {
                    case ActionReciever.CHILD: // Likes helping children
                        return Mood.HAPPY;
                    case ActionReciever.MURDERER: // Dislikes helping murderers
                        return Mood.UPSET;
                    case ActionReciever.PEASENT: // Likes helping peasentry
                        return Mood.HAPPY;
                }
                break;
            case Action.HURT:
                switch (receiver)
                {
                    case ActionReciever.CHILD: // Dislikes hurting children
                        return Mood.UPSET;
                    case ActionReciever.ROYALTY: // Dislikes hurting royalty
                        return Mood.UPSET;
                    case ActionReciever.PEASENT:// Dislikes hurting peasentry
                        return Mood.UPSET;
                }
                break;
        }

        return Mood.NEUTRAL;
    }
}
