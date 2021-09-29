using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System;

public class ChangeScene : MonoBehaviour
{
    private int _sceneBuildIndex;

    private void Start()
    {
        _sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene()
    {
        StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);
        switch(_sceneBuildIndex)
        {
            case 0: SceneManager.LoadScene(1);
            break;

            case 1: SceneManager.LoadScene(2);
            break;

            case 2: SceneManager.LoadScene(0);
            break;
        }
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}
