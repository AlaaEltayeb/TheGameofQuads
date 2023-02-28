using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private int score = 0;
    private Color selectedColor;

    [SerializeField] private TextMeshProUGUI pointsText;

    private void OnEnable()
    {
        QuadController.OnAnyQuadClicked += CalculatePoints;
        ServiceLocator.Get<ColorSelectionController>().OnSelectedColorChanged += ChangeSelectedColor;
    }

    private void OnDisable()
    {
        QuadController.OnAnyQuadClicked -= CalculatePoints;
        ServiceLocator.Get<ColorSelectionController>().OnSelectedColorChanged -= ChangeSelectedColor;
    }

    private void ChangeSelectedColor(Color color)
    {
        selectedColor = color;
    }

    private void CalculatePoints(Color color)
    {
        if (selectedColor == color)
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
