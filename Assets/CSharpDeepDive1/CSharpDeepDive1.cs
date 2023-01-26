using UnityEngine;
using System.Collections.Generic;

public class CSharpDeepDive1 : MonoBehaviour
{
    public List<GameObject> listOfObjects;

    public GameObject sphere;

    // Runs when "this object" is created.
    // "this object" = the Game Object that this script is attached to.
    // "script" = script, monobehaviour, component, behaviour
    // More specifically, a script is a C# class that inherits from MonoBehaviour.
    private void Awake()
    {
        for (int i = 0; i < listOfObjects.Count; i++)
        {
            listOfObjects[i].name = "List Element!";
        }

        // sphere.name = "Erik's *Worst* Sphere";

        // "branches" or "conditionals"
        // all fit under the category of "flow control"
        //if (sphere.name == "Erik")
        //{
        //    Debug.Log("True!");
        //}
        //else
        //{
        //    Debug.Log("False!");
        //}

        //Transform t = sphere.GetComponent<Transform>();

        //t.position = new Vector3(0, 5, 0);
        //t.eulerAngles = new Vector3(0, 45, 0);
    }
}
