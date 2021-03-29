/*
 * Ashton Lively
 * FollowerBryan.cs
 * Assignment 8
 * Update how Bryan feels about the player character. 
 */

public class FollowerBryan : Follower
{
    public FollowerBryan()
    {
        SetUI("Bryan");
    }

    public override bool CheckPartyStatus(int points)
    {
        if (points < 2)
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
                    case ActionReciever.ROYALTY: // Likes helping royalty
                        return Mood.HAPPY;
                    case ActionReciever.ANIMAL: // Dislikes helping animals
                        return Mood.UPSET;
                }
                break;
            case Action.HURT:
                switch (receiver)
                {
                    case ActionReciever.ROYALTY: // Dislikes hurting royalty
                        return Mood.UPSET;
                    case ActionReciever.CHILD: // Likes hurting children
                        return Mood.HAPPY;
                    case ActionReciever.PEASENT:// Likes hurting peasentry
                        return Mood.HAPPY;
                    case ActionReciever.ANIMAL: // Likes hurting animals
                        return Mood.HAPPY;
                }
                break;
        }

        return Mood.NEUTRAL;
    }
}
