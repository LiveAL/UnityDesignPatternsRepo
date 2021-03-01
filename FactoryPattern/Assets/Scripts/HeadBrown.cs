/*
 * Ashton Lively
 * HeadBrown.cs
 * Assignment 5
 * Attributes for brown heads
 */

public class HeadBrown : Head
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
        return "Brown";
    }
}
