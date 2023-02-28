using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionController : MonoBehaviour
{
    private const float changeStateWaitTimer = 1.0f;

    private const int colorSelectionMin = 0;
    private int colorSelectionMax = 2;

    [SerializeField] private Image quadColorToHit;
    [SerializeField] private List<Color> colorsList;

    private void Start()
    {
        StartCoroutine(GetNewColor());

        colorSelectionMax = colorsList.Count;
    }

    private IEnumerator GetNewColor()
    {
        yield return new WaitForSeconds(changeStateWaitTimer);

        int randomColorInt = Random.Range(colorSelectionMin, colorSelectionMax);
        quadColorToHit.color = colorsList[randomColorInt];

        StartCoroutine(GetNewColor());
    }
}
