using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class SetofCubes : MonoBehaviour
{
    public AudioSource completedCube;

    public bool EnteredTrigger = false;
    public UnityArmatureComponent Cube;
    public GameObject CubeUI;
    public GameObject cubeObject;

    public GameObject Collected0;
    public GameObject Collected1;
    public GameObject Collected2;
    public GameObject Collected3;

    void Start()
    {
        completedCube = GetComponent<AudioSource>();
    }

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
            CubeUI.SetActive(true);
        }

    }

    public void enteredTrigger()
    {
        if (EnteredTrigger == true)
        {
            cubeObject.SetActive(false);
        }
    }

    public void CubeCompleted()
    {
        completedCube.Play();
        Cube.animation.Play("OBTAINED",1);
        GetComponent<BoxCollider2D>().enabled = false;
        CubeUI.SetActive(false);

        if (Collected0.active == true)
        {
            Collected0.SetActive(false);
            Collected1.SetActive(true);
        }

        else if (Collected1.active == true)
        {
            Collected1.SetActive(false);
            Collected2.SetActive(true);
        }

        else if (Collected2.active == true)
        {
            Collected2.SetActive(false);
            Collected3.SetActive(true);
        }

    }
}
