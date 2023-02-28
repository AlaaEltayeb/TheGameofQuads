using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public Action OnTimeOut;

    private float timer = 0;
    private float gameTime = 5;

    [SerializeField] private TextMeshProUGUI timeText;

    private void Awake()
    {
        ServiceLocator.Add(this);
    }

    private void Start()
    {
        timer = gameTime;
        Time.timeScale = 1.0f;
        StartCoroutine(RunGameTimer());
    }

    private void OnDisable()
    {
        ServiceLocator.Remove(this);
    }

    private IEnumerator RunGameTimer()
    {
        bool isTimeOut = false;

        while (!isTimeOut)
        {
            timer -= Time.deltaTime;
            timeText.text = $"Timer: {(int)timer}";

            isTimeOut = timer <= 0;
            yield return null;
        }

        Time.timeScale = 0f;
        OnTimeOut?.Invoke();
    }
}
