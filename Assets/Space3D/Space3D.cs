using UnityEngine;

public class Space3D : MonoBehaviour
{
    public Vector3 position;
    public Vector3 eulerRotation;
    public Vector3 localScale;

    //struct Position
    //{
    //    public Vector3 p;
    //}

    private void Update()
    {
        Transform t = GetComponent<Transform>();

        // Transform t = transform;
        // Transform t = gameObject.transform;

        //Vector3 position = t.position;
        //Vector3 rotation = t.eulerAngles;
        //Vector3 scale = t.localScale;
        
        // This means "set the WORLD position" of this transform
        t.position = position;

        // Rotation is weird!
        t.eulerAngles = eulerRotation;
        t.localScale = localScale;
    }
}
