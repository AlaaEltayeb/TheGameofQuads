using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float timer = 0;
    private float gameTime = 30;

    [SerializeField] private TextMeshProUGUI timeText;

    private void Start()
    {
        timer = gameTime;
        StartCoroutine(RunGameTimer());
    }

    private IEnumerator RunGameTimer()
    {
        bool isTimeOut = false;

        while (!isTimeOut)
        {
            timer -= Time.deltaTime;
            timeText.text = $"Timer: {(int)timer}";

            isTimeOut = timer < 0;
            yield return null;
        }

        Debug.Log("Game Ended");
    }
}
