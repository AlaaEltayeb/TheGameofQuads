using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class ColorSelectionController : MonoBehaviour
{
    public Action<Color> OnSelectedColorChanged;

    private const float changeStateWaitTimer = 1.0f;

    private const int colorSelectionMin = 0;
    private int colorSelectionMax = 2;

    private Color selectedColor;

    [SerializeField] private Image quadColorToHit;
    [SerializeField] private List<Color> colorsList;

    private void Awake()
    {
        ServiceLocator.Add(this);
    }

    private void Start()
    {
        ChangeSelectedColor();

        StartCoroutine(GetNewColor());

        colorSelectionMax = colorsList.Count;
    }

    private void OnDisable()
    {
        ServiceLocator.Remove(this);
    }

    private IEnumerator GetNewColor()
    {
        yield return new WaitForSeconds(changeStateWaitTimer);

        ChangeSelectedColor();

        StartCoroutine(GetNewColor());
    }

    private void ChangeSelectedColor()
    {
        int randomColorInt = Random.Range(colorSelectionMin, colorSelectionMax);

        selectedColor = colorsList[randomColorInt];
        quadColorToHit.color = selectedColor;

        OnSelectedColorChanged?.Invoke(selectedColor);
    }
}
