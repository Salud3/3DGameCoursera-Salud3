using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAS : MonoBehaviour
{
    public float range;
    public float speed;
    public enum ElevatorType { Arriba, Derecha, Enfrente, izquierda };
    public ElevatorType movimiento;
    Vector3 initialPosition;

    public bool childs;

    public delegate void Child();
    public static event Child OnChild;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void SumSp()
    {
        speed += 0.1f;
    }
    public void ResSp()
    {
        speed -= 0.1f;
        if (speed < 0f) speed = 1f;

    }

    void Update()
    {
        if (movimiento == ElevatorType.Arriba)
        {
            transform.position = new Vector3(initialPosition.x, initialPosition.y + Mathf.Sin(Time.fixedTime * speed) * range, initialPosition.z);
        }
        if (movimiento == ElevatorType.Derecha)
        {
            transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z + Mathf.Sin(Time.fixedTime * speed) * range);
        }
        if (movimiento == ElevatorType.izquierda)
        {
            transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z - Mathf.Sin(Time.fixedTime * speed) * range);
        }
        if (movimiento == ElevatorType.Enfrente)
        {
            transform.position = new Vector3(initialPosition.x + Mathf.Sin(Time.fixedTime * speed) * range, initialPosition.y, initialPosition.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            other.transform.parent = this.transform;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {

            other.transform.parent = null;
        }
    }

}
