using UnityEngine;

public class SceneDemoAppData : MonoBehaviour
{
    public string Username = "Default";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
