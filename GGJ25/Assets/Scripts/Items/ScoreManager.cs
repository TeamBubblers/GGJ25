using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField]
    public TMP_Text myTextMeshProText;
    public int score = 0;
    //public Text scoreText;

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
        if(myTextMeshProText != null)
        {
            //scoreText.text = score.ToString();
            myTextMeshProText.text = score.ToString();
            Debug.Log(score);
        }
    }
}
