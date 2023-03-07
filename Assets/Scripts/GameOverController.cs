using System;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI pointText;

    private int points;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        ServiceLocator.Get<TimeController>().OnTimeOut += ShowGameOver;
        ServiceLocator.Get<PointsController>().OnPointsChanged += SetPoints;
        
        SetPointsText();
    }

    private void ShowGameOver()
    {
        SetPointsText();
        gameOverScreen.SetActive(true);
    }

    private void SetPoints(int points)
    {
        this.points = points;
    }

    private void SetPointsText()
    {
        pointText.text = $"Points:   {points}";
    }
}
