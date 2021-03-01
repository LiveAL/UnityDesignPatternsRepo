/*
 * Ashton Lively
 * BodyWhite.cs
 * Assignment 5
 * Attributes for white bodies
 */
public class BodyWhite : Body
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
        return "White";
    }
}
