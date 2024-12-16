using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBoundary : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.position = rb.position - collision.contacts[0].normal * 0.1f; // Push object back slightly
            }
        }
    }
}
