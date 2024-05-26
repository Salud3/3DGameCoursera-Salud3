using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBall : MonoBehaviour
{
    [SerializeField]BallController ballController;
    public Material material;

    void OnCollisionEnter(Collision collision)
    {
		Debug.Log("a");
        if (collision.gameObject.CompareTag("Player"))
        {
            ballController.function();
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("a");
            ballController.function();
        }
    }

}
