using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.UIManager.Containers;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
   [SerializeField]private UIView mainView;
   [SerializeField]private bool hasPickedSphere = false;
   
   public void ObjectPicked()
   {
      if(hasPickedSphere)
         return;

      hasPickedSphere = true;
      
      mainView.Show();
   }
}
