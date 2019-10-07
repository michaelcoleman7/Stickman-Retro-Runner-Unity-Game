using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    public Text highScore;

    public float scoreValue;
    public float highScoreValue;

    public float pointIncrease;

    public bool increaseScore;  

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore")) 
        {
            highScoreValue = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseScore) 
        {
            //Increase score per frame - adopted from https://answers.unity.com/questions/1357802/increase-score-per-frame.html
            scoreValue += pointIncrease * Time.deltaTime;
        }
        
        if (scoreValue > highScoreValue) 
        {
            //set new high score to high score value
            highScoreValue = scoreValue;

            PlayerPrefs.SetFloat("HighScore", highScoreValue);
        }
        score.text = "Score: " + Mathf.Round(scoreValue);
    }
}
