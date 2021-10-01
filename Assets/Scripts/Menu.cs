using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject creditsButton;
    public GameObject exitButton;
    public GameObject instructionsButton;
    public GameObject exitTopButton;
    public EventSystem _eventSystem;

    [SerializeField]
    private GameObject _credits;

    [SerializeField]
    private GameObject _instructions;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }


    public void StartPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsPressed()
    {
        _credits.SetActive(true);
        startButton.SetActive(false);
        creditsButton.SetActive(false);
        exitButton.SetActive(false);
        instructionsButton.SetActive(false);
        exitTopButton.SetActive(true);
        _eventSystem.SetSelectedGameObject(exitTopButton);
    }

    public void ExitTopPressed()
    {
        _credits.SetActive(false);
        _instructions.SetActive(false);
        startButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        instructionsButton.SetActive(true);
        exitTopButton.SetActive(false);
        _eventSystem.SetSelectedGameObject(startButton);
    }

    public void InstructionsPressed()
    {
        _instructions.SetActive(true);
        startButton.SetActive(false);
        creditsButton.SetActive(false);
        exitButton.SetActive(false);
        instructionsButton.SetActive(false);
        exitTopButton.SetActive(true);
        _eventSystem.SetSelectedGameObject(exitTopButton);
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
