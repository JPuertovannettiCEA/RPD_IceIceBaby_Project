using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class FinalScore : MonoBehaviour
{
    public GameObject returnMainMenuButton;
    public GameObject playAgain;

    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private TMP_Text _finalMessage;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController._win == true)
        {
            _finalMessage.text = "You survived! You can eat happy now!";
            _scoreText.text = "Final Fish Score: " + PlayerController._score.ToString(); 
        }
        else
        {
            _finalMessage.text = "Too bad! Better luck next time!";
            _scoreText.text = "Final Fish Score: " + PlayerController._score.ToString(); 
        }

    }

    public void LoadPlayAgainPressed()
    {
        WaitForPlayAgainLoad();
    }

    public void ReturnPressed()
    {
        WaitForReturnLoad();
    }

    private IEnumerator WaitForPlayAgainLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    private IEnumerator WaitForReturnLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

}
