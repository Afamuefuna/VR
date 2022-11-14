using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.UIManager.Animators;
using Doozy.Runtime.UIManager.Audio;
using Doozy.Runtime.UIManager.Containers;
using UnityEngine;

public class Item : MonoBehaviour
{
    private UIContainerUIAnimator _uiAnimator;
    private bool hasRevealed = false;
    private void Start()
    {
        _uiAnimator = gameObject.GetComponent<UIContainerUIAnimator>();
        _uiAnimator.InstantHide();
    }

    public void Reveal()
    {
        if(hasRevealed)
            return;

        hasRevealed = true;
        
        _uiAnimator.Show();
    }

    public void DisableAudio()
    {
        UIContainerAudio uiContainerAudio = GetComponent<UIContainerAudio>();
        AudioSource audioSource = GetComponent<AudioSource>();

        audioSource.enabled = false;
        uiContainerAudio.enabled = false;
    }
}
