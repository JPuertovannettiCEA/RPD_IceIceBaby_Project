using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    private int _sceneBuildIndex;

    [SerializeField]
    private GameObject _Text;
    
    [SerializeField]
    private GameObject _credits;

    private void Start()
    {
        _sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadScene(_Text);
        }
    }

    public void LoadScene(GameObject _button)
    {
        if(_button.gameObject.CompareTag("Credits"))
        {
            _credits.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _credits.SetActive(false);
            }
        }
        if(_button.gameObject.CompareTag("Exit"))
        {
            OnExitPressed();
        }
        if(_button.gameObject.CompareTag("Start"))
        {
            StartCoroutine(WaitForSceneLoad());
        }
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
