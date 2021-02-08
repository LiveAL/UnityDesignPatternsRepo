using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private ElementalAttack elementalAttack;
    private int currAttackIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Set the current attack type
        currAttackIndex = 0;
        elementalAttack = gameObject.AddComponent<FireAttack>();
        elementalAttack.AssignParticles();
    }

    // Update is called once per frame
    void Update()
    {
        // Switch the element attack type 
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currAttackIndex++;
            if (currAttackIndex > 2)
            {
                currAttackIndex = 0;
            }

            switch(currAttackIndex)
            {
                case (0):
                    Debug.Log("Switching to fire attack.");
                    Destroy(GetComponent<ElementalAttack>());
                    elementalAttack = gameObject.AddComponent<FireAttack>();
                    elementalAttack.AssignParticles();
                    break;
                case (1):
                    Debug.Log("Switching to ice attack.");
                    Destroy(GetComponent<ElementalAttack>());
                    elementalAttack = gameObject.AddComponent<IceAttack>();
                    elementalAttack.AssignParticles();
                    break;
                default:
                    Debug.Log("Switching to lightning attack.");
                    Destroy(GetComponent<ElementalAttack>());
                    elementalAttack = gameObject.AddComponent<LightningAttack>();
                    elementalAttack.AssignParticles();
                    break;
            }
        }

        // Attack on click
        if (Input.GetMouseButtonDown(0))
        {
            elementalAttack.Attack(transform);
        }
    }
}
