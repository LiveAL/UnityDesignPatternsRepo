/*
 * Ashton Lively
 * BodyBrown.cs
 * Assignment 5
 * Attributes for brown bodies
 */
public class BodyBrown : Body
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
        return "Brown";
    }
}
