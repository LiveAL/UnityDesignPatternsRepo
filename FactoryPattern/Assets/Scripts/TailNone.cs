/*
 * Ashton Lively
 * TailNone.cs
 * Assignment 5
 * Attributes for lack of tail
 */
public class TailNone : Tail
{
    public override bool dominant
    {
        get
        {
            return false;
        }
    }

    public override string toString()
    {
        return "None";
    }
}
