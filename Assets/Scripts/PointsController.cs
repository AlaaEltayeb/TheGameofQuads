using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private int score = 0;
    private Color currentColor;

    [SerializeField] private TextMeshProUGUI pointsText;

    void Start()
    {
        GameManager.Instance.OnAnyQuadClicked += CalculateScore;
        GameManager.Instance.OnSelectedColorChanged += ChangeSelectedColor;
    }

    private void ChangeSelectedColor(Color color)
    {
        currentColor = color;
    }

    private void CalculateScore(Color color)
    {
        if (currentColor == color)
        {
            score++;
        }
        else
        {
            score--;
        }

        pointsText.text = $"Points:   {score}";
    }
}
