using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class SetofOrbsAnimation : MonoBehaviour
{
    public bool EnteredTrigger = false;
    public UnityArmatureComponent Orb;
    public GameObject obtainedOrb;
    public GameObject orbObject;
    public GameObject description;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            EnteredTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            EnteredTrigger = false;
        }
    }

    public void Absorb()
    {
        if (EnteredTrigger == true)
        {
            Orb.animation.Play("OBTAINED", 1);
            description.SetActive(true);
            obtainedOrb.SetActive(true);
        }
        
    }

    public void enteredTrigger()
    {
        if (EnteredTrigger == true)
        {
            orbObject.SetActive(false);
        }
    }
}
