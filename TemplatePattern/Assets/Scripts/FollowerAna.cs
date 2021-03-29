/*
 * Ashton Lively
 * FollowerAna.cs
 * Assignment 8
 * Update how Ana feels about the player character. 
 */

public class FollowerAna : Follower
{
    public FollowerAna()
    {
        SetUI("Ana");
    }

    public override bool CheckPartyStatus(int points)
    {
        if (points < 3)
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
                    case ActionReciever.ROYALTY: // Dislikes helping royalty
                        return Mood.UPSET;
                    case ActionReciever.ANIMAL: // Likes helping animals
                        return Mood.HAPPY;
                }
                break;
            case Action.HURT:
                switch (receiver)
                {
                    case ActionReciever.ANIMAL: // Dislikes hurting animals
                        return Mood.UPSET;
                    case ActionReciever.CHILD: // Dislikes hurting children
                        return Mood.UPSET;
                }
                break;
        }

        return Mood.NEUTRAL;
    }
}
