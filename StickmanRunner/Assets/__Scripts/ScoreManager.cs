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
            //get high score value from player preferences - adopted from https://unity3d.com/de/learn/tutorials/topics/scripting/high-score-playerprefs
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
        
        //if users score is higher than the current high score
        if (scoreValue > highScoreValue) 
        {
            //set new high score to high score value
            highScoreValue = scoreValue;

            //Keep high score value in player preferences even if game is exited - adopted from https://unity3d.com/de/learn/tutorials/topics/scripting/high-score-playerprefs
            PlayerPrefs.SetFloat("HighScore", highScoreValue);
        }

        //set Text values in unity to score increase
        score.text = "Score: " + Mathf.Round(scoreValue);
        highScore.text = "Score: " + Mathf.Round(highScoreValue);
    }
}
