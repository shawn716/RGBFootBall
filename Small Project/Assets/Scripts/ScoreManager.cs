using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int point;
    public int count;
    public TextMeshProUGUI highestScoreText;
    public TextMeshProUGUI scoreCounterText;

    private void Awake()
    {
        BallMovement.BallPickedUp += RunScore;
        scoreCounterText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        point = 1;
        count = 0;
        highestScoreText.text = PlayerPrefs.GetInt("HighestScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounterText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("HighestScore", 0))
        {
            PlayerPrefs.SetInt("HighestScore", score);
        }

    }

    void RunScore()
    {
        count++;
        score += point;

        if (count % 5 == 0)
        {
            point++;
        }

    }

    public static void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //PlayerPrefs.DeleteAll();
        
    }

   
}
