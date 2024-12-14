using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript Instance {get; private set;}
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    private int score =0;
    private int highScore, prevHighScore;
    private float comboTimer = 0f; 
    [SerializeField] private float comboKillBonus = 2f;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the instance
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        prevHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScore = prevHighScore;
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        comboTimer += Time.deltaTime;
        if(score>highScore)
        {
            highScore = score;
        }
        scoreText.text = $"Score: {score}\n High Score: {highScore}";
        
    }

    void UpdateScoreText()
    {
        if(highScore>0)
        {
            scoreText.text = $"Score: {score}\n High Score {highScore}";
        }
        else
        {
            scoreText.text = $"Score: {score}";
        }
        
    }

    public void GameEnded()
    {
        Debug.Log($"GameEnded message from ScoreScript");
        if(score > prevHighScore)
        {
            prevHighScore = score;
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            Debug.Log($"High Score Loaded: {highScore}");
        }
        score = 0;
        UpdateScoreText(); 
    }

    public void AddScoreMonsterKilled()
    {
        score += Mathf.RoundToInt(1f + comboKillBonus / Mathf.Max(comboTimer, 0.1f));;
        comboTimer = 0f;
    }
}
