using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rigBod;

    [SerializeField] float thrustForce = 1150f;
    [SerializeField] float rotForce = 150f;

    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust(Time.deltaTime);
        ProcessRotation(Time.deltaTime);
    }



    void ProcessThrust(float deltaTime)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space");
            rigBod.AddRelativeForce(Vector3.up * thrustForce * deltaTime);
        }
    }

    void ProcessRotation(float deltaTime)
    {
        bool turnLeft = Input.GetKey(KeyCode.A);
        bool turnRight = Input.GetKey(KeyCode.D);

        if (turnLeft && !turnRight)
        {
            ApplyRotation(rotForce * deltaTime);
        }
      else if (turnRight && !turnLeft)
        {
            ApplyRotation(-rotForce * deltaTime);
        }
    }

    private void ApplyRotation(float forceTimeMultiplier)
    {
        // Freezing rotation so we can control manually
        rigBod.freezeRotation = true;

        transform.Rotate(Vector3.forward * forceTimeMultiplier);

        rigBod.freezeRotation = false;
    }
}
