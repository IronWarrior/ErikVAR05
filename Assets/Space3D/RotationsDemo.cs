using UnityEngine;

public class RotationsDemo : MonoBehaviour
{
    public float x, y, z, w;

    public Vector3 euler;

    // public Quaternion rotation;

    private void Update()
    {
        Quaternion q = new Quaternion(x, y, z, w);

        // transform.eulerAngles = euler;
        // shorthand for:
        // transform.rotation = Quaternion.Euler(euler.x, euler.y, euler.z);

        transform.Rotate(euler);
    }
}
