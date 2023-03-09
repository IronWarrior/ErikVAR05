using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public Button transitionButton;
    public TMP_InputField usernameInput;

    private void Start()
    {
        transitionButton.onClick.AddListener(() => DoSceneTransition());
    }

    private void Update()
    {
        FindObjectOfType<SceneDemoAppData>().Username = usernameInput.text;
    }

    private void DoSceneTransition()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
