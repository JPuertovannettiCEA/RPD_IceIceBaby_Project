using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameplayUI _gameplayUI;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void OnContinuePressed()
    {
        _gameplayUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnQuitPressed()
    {
        SceneManager.LoadScene(0);
    }
}
