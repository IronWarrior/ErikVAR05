using TMPro;
using UnityEngine;


// public - ???
// class - ???
// GuessingGame - Name of the *script*
// :
// MonoBehaviour - Indicates this file is a C# script.
public class GuessingGame : MonoBehaviour
{
    // A reference to the Text object
    public TextMeshProUGUI textGameObject;
    public TMP_InputField inputFieldGameObject;

    // public - indicates Unity can refer to this function in the editor,
    // such as to trigger when a button is pressed.
    public void MyFunction()
    {
        textGameObject.text = "Hello " + inputFieldGameObject.text + " how are you doing?";

        // Function call to print to the console.
        // Debug.Log(inputFieldGameObject.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
