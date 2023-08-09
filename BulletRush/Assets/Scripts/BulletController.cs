using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 movement;
    public void Fire(Vector3 direction)
    {
        //Debug.Log(direction.magnitude);
        movement = direction*speed*Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {
        transform.position += movement;
    }
}
