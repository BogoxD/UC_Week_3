using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;
    void Start()
    {
        DetectCollisionsX.collectBall += UpdateScore;
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    private void OnDisable()
    {
        DetectCollisionsX.collectBall -= UpdateScore;
    }
}
