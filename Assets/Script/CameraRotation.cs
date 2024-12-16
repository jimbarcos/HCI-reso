using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation

    void Update()
    {
        float x_axis = transform.eulerAngles.x;

        // Normalize x_axis to handle rotations beyond 360 degrees
        if (x_axis > 180f) x_axis -= 360f;

        // Check if W or S is pressed
        if (Input.GetKey(KeyCode.W))
        {
            // Rotate downwards around the x-axis only within the allowed range
            if (x_axis >= -10f && x_axis < 20f) // Stop at exactly 50
            {
                transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

                if (x_axis > 50f) // Prevent exceeding 90
                {
                    Vector3 clampedRotation = transform.eulerAngles;
                    clampedRotation.x = 50f;
                    transform.eulerAngles = clampedRotation;
                }
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Rotate upwards around the x-axis only within the allowed range
            if (x_axis >= 0f && x_axis <= 90f)
            {
                transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
            }
        }

    }
}
