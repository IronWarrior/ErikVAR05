using UnityEngine;

public class LocalAndWorldDirections : MonoBehaviour
{
    public Vector3 Forward;

    private void Update()
    {
        Forward = transform.forward;

        // Shorthand for this.
        Forward = transform.TransformDirection(Vector3.forward);
        // ...or this
        Forward = transform.rotation * Vector3.forward;

        transform.position += transform.forward * Time.deltaTime;
    }
}
