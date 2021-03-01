/*
 * Ashton Lively
 * BodyBlack.cs
 * Assignment 5
 * Attributes for black bodies
 */
public class BodyBlack : Body
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
        return "Black";
    }
}
