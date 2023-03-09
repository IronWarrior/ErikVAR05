using UnityEngine;

public class SceneDemoAppBootstrap : MonoBehaviour
{
    public SceneDemoAppData appDataPrefab;

    private void Awake()
    {
        // This is called "dependency injection"--instead of
        // placing the things we need in our scenes, we *give*
        // the things we need to our scenes.
        // "A $20 term for a $1 idea"

        // Does an AppData already exist?
        if (FindObjectOfType<SceneDemoAppData>() == null)
        {
            // If not, create one.
            Instantiate(appDataPrefab);
        }

        Destroy(gameObject);
    }
}
