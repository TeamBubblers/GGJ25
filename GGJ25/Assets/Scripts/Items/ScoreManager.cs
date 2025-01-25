using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if(scoreText != null)
        {
            scoreText.text = score.ToString();
            Debug.Log(score);
        }
    }
}
