using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSeeker : MonoBehaviour
{
    public Transform myTarget;
    public float maxSpeed = 5f;
    public float speedIncrease = 6f;
    public Vector3 velocity;
    public int damping = 8;

    // Update is called once per frame
    void Update()
    { 
        // move me
        velocity = (myTarget.position - transform.position).normalized * maxSpeed;
        transform.position += velocity * Time.deltaTime;

        // face my target
        //transform.LookAt(myTarget);
        //float targetAngle = newOrientation(transform.rotation.eulerAngles.y, velocity);
        //transform.eulerAngles = new Vector3(0, targetAngle, 0);

        // Determine which direction to rotate towards
        Vector3 targetDirection = myTarget.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = 1f * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void OnTriggerEnter()
    {
        transform.position += velocity * speedIncrease * Time.deltaTime;/*
        if (maxSpeed > 0)
            transform.rotation = Quaternion.LookRotation(transform.position -
                myTarget.position);
        else
            transform.rotation = Quaternion.Inverse(transform.rotation);*/
    }

}