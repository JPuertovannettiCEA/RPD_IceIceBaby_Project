using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    #region Timer Variables
    [SerializeField]
    public float timer;

    [SerializeField]
    private TMP_Text _timerText;
 
    #endregion

    //This variable is for when the spiky cubes spawns
    private float _timeBetweenSpawns = 20f; //Seconds

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        _timerText.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //This condition is to indicate when there will be a spawn happening
        if (timer % _timeBetweenSpawns > 1) //Spawn Condition
        {
            _timeBetweenSpawns = 0f;
            //Debug.Log("Somethin happens here");
            //Instantiate(objectwhatever, position, Quaternion.identity);
        }

        DisplayTime(timer);

        void DisplayTime(float timeToDisplay)
        {
            if(timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            else if(timeToDisplay > 0)
            {
                timeToDisplay += 1;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if(timer <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }

}
