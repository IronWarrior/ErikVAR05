using UnityEngine;

public class FallProblem : MonoBehaviour
{
    public float zRotation;
    public float rotationDifference;

    public float rotationDifferenceFromUp;

    private float initialZRotation;

    private void Start()
    {
        initialZRotation = transform.eulerAngles.z;
    }

    private void Update()
    {
        bool hasFallen = false;

        // Set hasFallen to true or false based on whether the pin
        // has "fallen".
        zRotation = transform.eulerAngles.z;
        rotationDifference = zRotation - initialZRotation;

        if (rotationDifference > 180)
            rotationDifference = 360 - rotationDifference;

        if (rotationDifference > 45)
        {
            // hasFallen = true;
        }

        Debug.DrawRay(transform.position, Vector3.up * 4, Color.blue);
        Debug.DrawRay(transform.position, transform.up * 4, Color.blue);

        rotationDifferenceFromUp = Vector3.Angle(Vector3.up, transform.up);

        if (rotationDifferenceFromUp > 45)
        {
            hasFallen = true;
        }

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = hasFallen ? Color.red : Color.green;
        }
    }
}
