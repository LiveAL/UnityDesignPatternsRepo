/*
 * Ashton Lively
 * HeadWhite.cs
 * Assignment 5
 * Attributes for white heads
 */
public class HeadWhite : Head
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
        return "White";
    }
}
