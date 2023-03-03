using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsDemo : MonoBehaviour
{
    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.centerOfMass = Vector3.zero;

        // Assign a velocity in "units per second"
        // "units", not "meters", since Unity is units agnostic
        // (this means it doesn't assign a specific unit, like
        // inches or meters).
        // rigidbody.velocity = Vector3.down;

        // Assign an angular velocity in radians per second.
        // 1 radian = who cares,
        // 180 degrees = pi radians
        // 360 degrees = 2 * pi radians
        // rigidbody.angularVelocity = Vector3.right * 360 * Mathf.Deg2Rad;

        // Unity assumes you are multiplying by delta time.
        // So this is appropriate for forces that are applied
        // continuously, or over many frames.
        rigidbody.AddForce(Vector3.forward);

        // Otherwise, do this:
        rigidbody.AddForce(Vector3.forward, ForceMode.Impulse);

        // Torques are "angular" forces
        // Torques are affected by the "inertia tensor", rather than the mass.
        // This is the distribution of the mass throughout the object, kind of.
        // rigidbody.AddTorque(Vector3.one)
    }
}
