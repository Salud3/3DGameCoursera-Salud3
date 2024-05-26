using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody rgb;
    public Collider col;
    public Transform Destination;

    void Start()
    {
        Destination = GameObject.Find("Destiny").GetComponent<Transform>();
        rgb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        MakeGhost(true);
    }

    void MakeGhost(bool state)
    {
        if (state)
        {
            rgb.isKinematic = true;
            col.enabled = false;
        }
        else
        {
            rgb.isKinematic = false;
            col.enabled = true;
        }
    }

    void ResetRigidbody()
    {
        rgb.velocity = Vector3.zero;
        rgb.angularVelocity = Vector3.zero;
        rgb.drag = 0f;
        rgb.inertiaTensorRotation = Quaternion.identity;
        rgb.ResetInertiaTensor();
    }

    void Movement()
    {

        Vector3 vel = Destination.position - transform.position;
        vel.Normalize();
        transform.position += vel.normalized.normalized/2;

    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position,Destination.position)>2)
        {
            Movement();
        }
        else
        {

            Destroy(this.gameObject);
        }

    
    }
}
