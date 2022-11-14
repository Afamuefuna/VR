using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] boxReveals;
    public bool isPlayerGrabbing;

    public void SetGrabbing(bool isGrabbing)
    {
        isPlayerGrabbing = isGrabbing;
    }

    private void Start()
    {
        Reveals(false);
    }

    public void Reveals(bool condition)
    {
        foreach (var boxReveal in boxReveals)
        {
            boxReveal.SetActive(condition);
        }
    }
}
