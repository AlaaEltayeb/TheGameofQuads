using System;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public Action<int> OnPointsChanged;

    private int points = 0;
    private Color selectedColor;

    [SerializeField] private TextMeshProUGUI pointsText;

    private void Awake()
    {
        ServiceLocator.Add(this);
    }

    private void OnEnable()
    {
        QuadController.OnAnyQuadClicked += CalculatePoints;
        ServiceLocator.Get<ColorSelectionController>().OnSelectedColorChanged += ChangeSelectedColor;
    }

    private void OnDestroy()
    {
        OnPointsChanged = null;
        ServiceLocator.Remove(this);
    }

    private void ChangeSelectedColor(Color color)
    {
        selectedColor = color;
    }

    private void CalculatePoints(Color color)
    {
        if (selectedColor == color)
        {
            points++;
        }
        else
        {
            points--;
        }

        pointsText.text = $"Points:   {points}";

        OnPointsChanged?.Invoke(points);
    }
}
