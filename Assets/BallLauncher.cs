using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] GameObject objectA;
    [SerializeField] Rigidbody rgb;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        GameObject a = Instantiate(objectA);
        a.transform.position = this.gameObject.transform.position + new Vector3(0,.5f);
        rgb = objectA.GetComponent<Rigidbody>();
        rgb.isKinematic = true;
        

    }



}
