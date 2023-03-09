using UnityEngine;
using TMPro;

public class SceneDemoGameplayUI : MonoBehaviour
{
    public TextMeshProUGUI usernameText;

    private void Start()
    {
        // There is one of these out there, created in the menu scene!
        SceneDemoAppData appData = FindObjectOfType<SceneDemoAppData>();

        usernameText.text = appData.Username;
    }
}
