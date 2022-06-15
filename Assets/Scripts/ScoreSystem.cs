using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    public const string highScoreKey = "HighScore";

    bool shouldCount = true;
    float scoreMultiplier = 1;
    float scoreAmount = 0;

    void Update()
    {
        if (!shouldCount) { return; }

        scoreAmount += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(scoreAmount).ToString(); 
    }

    public void StartTimer()
    {
        shouldCount = true;
    }

    public int StopScoreCount()
    {
        shouldCount = false;
        scoreText.text = string.Empty;

        return Mathf.FloorToInt(scoreAmount);
    }

    void OnDisable()
    {
        int currentHighScore = PlayerPrefs.GetInt(highScoreKey, 0);

        if (scoreAmount > currentHighScore)
        {
            PlayerPrefs.SetInt(highScoreKey, Mathf.FloorToInt(scoreAmount));
        }
    }

}
