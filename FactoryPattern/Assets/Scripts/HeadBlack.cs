/*
 * Ashton Lively
 * HeadBlack.cs
 * Assignment 5
 * Attributes for black heads
 */
public class HeadBlack : Head
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
        return "Black";
    }
}
