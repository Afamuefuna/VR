using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.UIManager.Animators;
using Doozy.Runtime.UIManager.Containers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;
    [SerializeField] private UIContainer _uiContainer;
    [SerializeField] private UIView loadingView;
    [SerializeField] private bool isBoxC;
    [SerializeField] private Text instructionText;
    
    void Start()
    {
        _particleSystem = gameObject.transform.parent.GetChild(1).GetComponent<ParticleSystem>();
        _audioSource = transform.parent.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            _particleSystem.Play();
            _audioSource.Play();
            _uiContainer.Show();

            if (isBoxC)
            {
                Invoke(nameof(loadingView), 4);
                Invoke(nameof(Reset), 6);
            }

            UserInterfaceManager.hasDropped = true;
            instructionText.text = "Sphere on a box!";
        }
    }

    public void LoadImage()
    {
        if(loadingView == null)
            return;
        
        loadingView.Show();
    }

    public void Reset()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            LoadImage();
            yield return null;
        }

        if (loadingView != null)
        {
            loadingView.InstantHide();
        }
    }
}
