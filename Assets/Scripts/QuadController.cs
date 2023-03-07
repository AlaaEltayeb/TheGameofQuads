using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class QuadController : MonoBehaviour
{
    public static Action<Color> OnAnyQuadClicked;

    enum QuadState
    {
        Off = 0,
        Red = 1,
        Green = 2
    }

    [Serializable]
    struct Struct_StateColor
    {
        public QuadState state;
        public Color color;
    }

    private Color selectedColor;
    private QuadState selectedQuadState;

    private const int quadStateMin = 0;
    private int quadStateMax = 3;

    private const float changeStateWaitTimer = 1.0f;

    [SerializeField] private MeshRenderer quadVisualRenderer;
    [SerializeField] private List<Struct_StateColor> stateMaterialsList;

    private void Start()
    {
        GetNewState();
        ChangeMaterialColor();

        StartCoroutine(GetNewQuadState());

        quadStateMax = stateMaterialsList.Count;
    }

    private void OnDestroy()
    {
        OnAnyQuadClicked = null;
    }

    private void OnMouseDown()
    {
        if (selectedQuadState != QuadState.Off)
        {
            OnAnyQuadClicked?.Invoke(selectedColor);

            selectedQuadState = QuadState.Off;
            ChangeMaterialColor();
        }
    }

    private IEnumerator GetNewQuadState()
    {
        yield return new WaitForSeconds(changeStateWaitTimer);

        GetNewState();
        ChangeMaterialColor();

        StartCoroutine(GetNewQuadState());
    }

    private void GetNewState()
    {
        int randomStateInt = Random.Range(quadStateMin, quadStateMax);
        selectedQuadState = (QuadState)randomStateInt;
    }

    private void ChangeMaterialColor()
    {
        selectedColor = stateMaterialsList.Find(stateMaterial => stateMaterial.state == selectedQuadState).color;
        quadVisualRenderer.material.color = selectedColor;
    }
}
