using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        ServiceLocator.Get<TimeController>().OnTimeOut += ShowGameOver;
    }

    private void OnDisable()
    {
        ServiceLocator.Get<TimeController>().OnTimeOut -= ShowGameOver;
    }

    private void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
