using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private TextMeshProUGUI pointsText;
    
    void Start()
    {
        GameManager.Instance.OnAnyQuadClicked += CalculateScore;
    }

    private void CalculateScore(Color color)
    {
        score++;
        pointsText.text = $"Points:   {score}";

        Debug.Log(color);
    }
}
