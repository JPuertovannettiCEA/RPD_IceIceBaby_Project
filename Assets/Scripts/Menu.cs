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

    [SerializeField]
    private GameObject _credits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsPressed()
    {
        _credits.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _credits.SetActive(false);
        }
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
