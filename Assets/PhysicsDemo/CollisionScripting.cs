using UnityEngine;

public class CollisionScripting : MonoBehaviour
{
    // When the object this script is attached to collides
    // with either another rigidbody OR a static collider
    // (static collider = game object with a collider but no rigidbody, you
    // can actually move these around if you want to.)
    // (This object needs a rigidbody attached)

    // OnHit in UE
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Break();

        Debug.DrawRay(collision.GetContact(0).point, collision.impulse * 5, Color.cyan, 1);
        Debug.DrawRay(collision.GetContact(0).point, collision.GetContact(0).normal * 5, Color.blue, 1);
    }

    // OnBeginActorOverlap (?) in UE
    // Called when two objects collide and at least one has a trigger,
    // and at least one has a rigidbody.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered!!");
    }
}
