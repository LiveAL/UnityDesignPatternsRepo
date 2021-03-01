/*
 * Ashton Lively
 * TailLong.cs
 * Assignment 5
 * Attributes for long tails
 */
public class TailLong : Tail
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
        return "Long";
    }
}
