/*
 * Ashton Lively
 * HorseBreeder.cs
 * Assignment 5
 * Creates the attributes for a horse
 */
using UnityEngine;

public class HorseBreeder : MonoBehaviour
{
    private Body _bodyAllele1;
    private Body _bodyAllele2;
    private Body _body;
    private enum BodyTypes { BROWN, BLACK, WHITE }

    private Head _headAllele1;
    private Head _headAllele2;
    private Head _head;
    private enum HeadTypes { BROWN, BLACK, WHITE }

    private Tail _tailAllele1;
    private Tail _tailAllele2;
    private Tail _tail;
    private enum TailTypes { LONG, SHORT, NONE }

    /// <summary>
    /// Create body with parent genes
    /// </summary>
    /// <param name="parent1"></param>
    /// <param name="parent2"></param>
    public void CreateBody(Horse parent1, Horse parent2)
    {
        // Create punnet square quadrants 
        Body[] quad1 = new Body[2] { parent1.GetBodyAllele1(), parent2.GetBodyAllele1() };
        Body[] quad2 = new Body[2] { parent1.GetBodyAllele1(), parent2.GetBodyAllele2() };
        Body[] quad3 = new Body[2] { parent1.GetBodyAllele2(), parent2.GetBodyAllele1() };
        Body[] quad4 = new Body[2] { parent1.GetBodyAllele2(), parent2.GetBodyAllele2() };

        int gene = Random.Range(0, 4);

        switch (gene)
        {
            case 0:
                _bodyAllele1 = quad1[0];
                _bodyAllele2 = quad1[1];
                break;
            case 1:
                _bodyAllele1 = quad2[0];
                _bodyAllele2 = quad2[1];
                break;
            case 2:
                _bodyAllele1 = quad3[0];
                _bodyAllele2 = quad3[1];
                break;
            case 3:
                _bodyAllele1 = quad4[0];
                _bodyAllele2 = quad4[1];
                break;
        }

        SelectBody();
    }

    /// <summary>
    /// Creates a body with no parent genes
    /// </summary>
    public void CreateBody()
    {
        BodyTypes bodyRand1 = (BodyTypes)Random.Range(0, 3);
        BodyTypes bodyRand2 = (BodyTypes)Random.Range(0, 3);

        switch (bodyRand1)
        {
            case BodyTypes.BROWN:
                _bodyAllele1 = new BodyBrown();
                break;
            case BodyTypes.BLACK:
                _bodyAllele1 = new BodyBlack();
                break;
            case BodyTypes.WHITE:
                _bodyAllele1 = new BodyWhite();
                break;
        }

        switch (bodyRand2)
        {
            case BodyTypes.BROWN:
                _bodyAllele2 = new BodyBrown();
                break;
            case BodyTypes.BLACK:
                _bodyAllele2 = new BodyBlack();
                break;
            case BodyTypes.WHITE:
                _bodyAllele2 = new BodyWhite();
                break;
        }

        SelectBody();
    }

    /// <summary>
    /// Select the body that is displayed
    /// </summary>
    private void SelectBody()
    {
        // Select random if both are dominant or recessive 
        if ((_bodyAllele1.dominant == true && _bodyAllele2.dominant == true)
            || (_bodyAllele1.dominant == false && _bodyAllele2.dominant == false))
        {
            
            int randomBody = Random.Range(0, 1);

            switch (randomBody)
            {
                case 0:
                    _body = _bodyAllele1;
                    break;
                case 1:
                    _body = _bodyAllele2;
                    break;
            }
        }
        // Select dominant if one is dominant 
        else
        {
            if (_bodyAllele1.dominant == true)
            {
                _body = _bodyAllele1;
            }
            else
            {
                _body = _bodyAllele2;
            }
        }
    }

    public Body GetBody()
    {
        return _body;
    }

    public Body GetBodyAllele1()
    {
        return _bodyAllele1;
    }

    public Body GetBodyAllele2()
    {
        return _bodyAllele2;
    }

    /// <summary>
    /// Create head with parent genes
    /// </summary>
    /// <param name="parent1"></param>
    /// <param name="parent2"></param>
    public void CreateHead(Horse parent1, Horse parent2)
    {
        // Create punnet square quadrants 
        Head[] quad1 = new Head[2] { parent1.GetHeadAllele1(), parent2.GetHeadAllele1() };
        Head[] quad2 = new Head[2] { parent1.GetHeadAllele1(), parent2.GetHeadAllele2() };
        Head[] quad3 = new Head[2] { parent1.GetHeadAllele2(), parent2.GetHeadAllele1() };
        Head[] quad4 = new Head[2] { parent1.GetHeadAllele2(), parent2.GetHeadAllele2() };

        int gene = Random.Range(0, 4);

        switch (gene)
        {
            case 0:
                _headAllele1 = quad1[0];
                _headAllele2 = quad1[1];
                break;
            case 1:
                _headAllele1 = quad2[0];
                _headAllele2 = quad2[1];
                break;
            case 2:
                _headAllele1 = quad3[0];
                _headAllele2 = quad3[1];
                break;
            case 3:
                _headAllele1 = quad4[0];
                _headAllele2 = quad4[1];
                break;
        }

        SelectHead();
    }

    /// <summary>
    /// Creates a head with no parent genes
    /// </summary>
    public void CreateHead()
    {
        HeadTypes headRand1 = (HeadTypes)Random.Range(0, 3);
        HeadTypes headRand2 = (HeadTypes)Random.Range(0, 3);

        switch (headRand1)
        {
            case HeadTypes.BROWN:
                _headAllele1 = new HeadBrown();
                break;
            case HeadTypes.BLACK:
                _headAllele1 = new HeadBlack();
                break;
            case HeadTypes.WHITE:
                _headAllele1 = new HeadWhite();
                break;
        }

        switch (headRand2)
        {
            case HeadTypes.BROWN:
                _headAllele2 = new HeadBrown();
                break;
            case HeadTypes.BLACK:
                _headAllele2 = new HeadBlack();
                break;
            case HeadTypes.WHITE:
                _headAllele2 = new HeadWhite();
                break;
        }

        SelectHead();
    }

    /// <summary>
    /// Select the head that is displayed
    /// </summary>
    private void SelectHead()
    {
        // Select random if both are dominant or recessive 
        if ((_headAllele1.dominant == true && _headAllele2.dominant == true)
            || (_headAllele1.dominant == false && _headAllele2.dominant == false))
        {
            int randomHead = Random.Range(0, 1);

            switch (randomHead)
            {
                case 0:
                    _head = _headAllele1;
                    break;
                case 1:
                    _head = _headAllele2;
                    break;
            }
        }
        // Select dominant if one is dominant 
        else
        {
            if (_headAllele1.dominant == true)
            {
                _head = _headAllele1;
            }
            else
            {
                _head = _headAllele2;
            }
        }
    }

    public Head GetHead()
    {
        return _head;
    }

    public Head GetHeadAllele1()
    {
        return _headAllele1;
    }

    public Head GetHeadAllele2()
    {
        return _headAllele2;
    }


    /// <summary>
    /// Create tail with parent genes
    /// </summary>
    /// <param name="parent1"></param>
    /// <param name="parent2"></param>
    public void CreateTail(Horse parent1, Horse parent2)
    {
        // Create punnet square quadrants 
        Tail[] quad1 = new Tail[2] { parent1.GetTailAllele1(), parent2.GetTailAllele1() };
        Tail[] quad2 = new Tail[2] { parent1.GetTailAllele1(), parent2.GetTailAllele2() };
        Tail[] quad3 = new Tail[2] { parent1.GetTailAllele2(), parent2.GetTailAllele1() };
        Tail[] quad4 = new Tail[2] { parent1.GetTailAllele2(), parent2.GetTailAllele2() };

        int gene = Random.Range(0, 4);

        switch (gene)
        {
            case 0:
                _tailAllele1 = quad1[0];
                _tailAllele2 = quad1[1];
                break;
            case 1:
                _tailAllele1 = quad2[0];
                _tailAllele2 = quad2[1];
                break;
            case 2:
                _tailAllele1 = quad3[0];
                _tailAllele2 = quad3[1];
                break;
            case 3:
                _tailAllele1 = quad4[0];
                _tailAllele2 = quad4[1];
                break;
        }

        SelectTail();
    }

    /// <summary>
    /// Creates a tail with no parent genes
    /// </summary>
    public void CreateTail()
    {
        TailTypes tailRand1 = (TailTypes)Random.Range(0, 3);
        TailTypes tailRand2 = (TailTypes)Random.Range(0, 3);

        switch (tailRand1)
        {
            case TailTypes.LONG:
                _tailAllele1 = new TailLong();
                break;
            case TailTypes.SHORT:
                _tailAllele1 = new TailShort();
                break;
            case TailTypes.NONE:
                _tailAllele1 = new TailNone();
                break;
        }

        switch (tailRand2)
        {
            case TailTypes.LONG:
                _tailAllele2 = new TailLong();
                break;
            case TailTypes.SHORT:
                _tailAllele2 = new TailShort();
                break;
            case TailTypes.NONE:
                _tailAllele2 = new TailNone();
                break;
        }

        SelectTail();
    }

    /// <summary>
    /// Select the tail that is displayed
    /// </summary>
    private void SelectTail()
    {
        // Select random if both are dominant or recessive 
        if ((_tailAllele1.dominant == true && _tailAllele2.dominant == true)
            || (_tailAllele1.dominant == false && _tailAllele2.dominant == false))
        {
            int randomTail = Random.Range(0, 1);

            switch (randomTail)
            {
                case 0:
                    _tail = _tailAllele1;
                    break;
                case 1:
                    _tail = _tailAllele2;
                    break;
            }
        }
        // Select dominant if one is dominant 
        else
        {
            if (_tailAllele1.dominant == true)
            {
                _tail = _tailAllele1;
            }
            else
            {
                _tail = _tailAllele2;
            }
        }
    }

    public Tail GetTail()
    {
        return _tail;
    }

    public Tail GetTailAllele1()
    {
        return _tailAllele1;
    }

    public Tail GetTailAllele2()
    {
        return _tailAllele2;
    }
}
