using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public int score = 0;

    public void IncrementScore()
    {
        score++;
    }
    
    public void DecrementScore()
    {
        score--;
    }
}
