using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameplayUI _gameplayUI;

    [SerializeField]
    private GameObject _instructions;

    public GameObject continueButton;
    public GameObject instructionsButton;
    public GameObject exitButton;
    public GameObject exitTopButton;
    public EventSystem _eventSystem;

    private bool _isPaused;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        _isPaused = true;
    }

    /**private void OnDisable()
    {
        _isPaused = false;
    }**/

    /**private void Update()
    {
        if(_isPaused == true)
        {
            exitTopButton.SetActive(false);
        }
    }**/

    public void OnContinuePressed()
    {
        _gameplayUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnInstructionsPressed()
    {
        _instructions.SetActive(true);
        continueButton.SetActive(false);
        instructionsButton.SetActive(false);
        exitButton.SetActive(false);
        exitTopButton.SetActive(true);
        _eventSystem.SetSelectedGameObject(exitTopButton);
    }

    public void ExitTopPressed()
    {
        _instructions.SetActive(false);
        continueButton.SetActive(true);
        instructionsButton.SetActive(true);
        exitButton.SetActive(true);
        exitTopButton.SetActive(false);
        _eventSystem.SetSelectedGameObject(instructionsButton);
    }

    public void OnQuitPressed()
    {
        SceneManager.LoadScene(0);
    }
}
