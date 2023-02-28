using UnityEngine;
using UnityEngine.UI;

public class SceneButtonController : MonoBehaviour
{
    [SerializeField] private SceneLoader.Scenes scene;
    [SerializeField] private Button mainMenuButton;

    void Start()
    {
        mainMenuButton.onClick.AddListener(() => SceneLoader.Load(scene));
    }
}
