/*
 * Ashton Lively
 * TailShort.cs
 * Assignment 5
 * Attributes for short tails
 */
public class TailShort : Tail
{
    public override bool dominant
    {
        get
        {
            return true;
        }
    }

    public override string toString()
    {
        return "Short";
    }
}