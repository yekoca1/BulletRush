using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

     [SerializeField] private float speed;
    public void move(Vector3 direction)
    {
        rigidbody.velocity = direction*speed*Time.fixedDeltaTime;
    }
}
