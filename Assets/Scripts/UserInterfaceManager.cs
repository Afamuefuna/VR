using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.UIManager.Containers;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] private Text instructionTxt;
    public static bool hasDropped;
    public void ShowView(UIView mView)
    {
        foreach (var view in UIView.visibleViews)
        {
            view.Hide();
        }
        
        mView.Show();
    }

    public void HideAllViews()
    {
        foreach (var view in UIView.visibleViews)
        {
            view.Hide();
        }
    }
    
    public void ShowContainer(UIContainer uiContainer)
    {
        uiContainer.Show();
    }

    private void Start()
    {
        hasDropped = false;
    }

    public void ChangeInstructionText(string instruction)
    {
        if(hasDropped)
            return;
        
        instructionTxt.text = instruction;
    }
}
