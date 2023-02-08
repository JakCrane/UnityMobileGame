using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    int score = 0;
    [SerializeField] TextMeshProUGUI scoreCounter;

    void Update() 
    {
        scoreCounter.text = score.ToString();
    }

    public void IncrementScore(int i)
    {
        score += i;
    }

    public int GetScore()
    {
        return score;
    }
}
