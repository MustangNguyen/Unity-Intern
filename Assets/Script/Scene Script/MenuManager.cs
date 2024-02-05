using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image pauseScreen;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;
    public void OnPauseButtonClick(){
        pauseScreen.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void OnResumeButtonClick(){
        pauseScreen.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
    public void OnQuitButtonClick(){
        Application.Quit();
        Debug.Log("Application is closed");
    }
}
