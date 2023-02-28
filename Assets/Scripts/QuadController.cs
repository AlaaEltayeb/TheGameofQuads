using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class QuadController : MonoBehaviour
{
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

    private Color currentColor;
    private QuadState currentQuadState;

    private const int quadStateMin = 0;
    private int quadStateMax = 3;

    private const float changeStateWaitTimer = 1.0f;

    [SerializeField] private MeshRenderer quadVisualRenderer;
    [SerializeField] private List<Struct_StateColor> stateMaterialsList;

    private void Start()
    {
        StartCoroutine(GetNewQuadState());

        quadStateMax = stateMaterialsList.Count;
    }

    private void OnMouseDown()
    {
        Debug.Log("You Hit Me " + name);
        if (currentQuadState != QuadState.Off)
        {
            currentQuadState = QuadState.Off;
            ChangeMaterial();
            
            GameManager.Instance.OnAnyQuadClicked?.Invoke(currentColor);
        }
    }

    private IEnumerator GetNewQuadState()
    {
        yield return new WaitForSeconds(changeStateWaitTimer);

        int randomStateInt = Random.Range(quadStateMin, quadStateMax);
        currentQuadState = (QuadState)randomStateInt;
        ChangeMaterial();

        StartCoroutine(GetNewQuadState());
    }

    private void ChangeMaterial()
    {
        currentColor = stateMaterialsList.Find(stateMaterial => stateMaterial.state == currentQuadState).color;
        quadVisualRenderer.material.color = currentColor;
    }
}
