using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TouchController input;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed;
    public void move(Vector3 direction)
    {
        rigidbody.velocity = direction*speed*Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var par = new Vector3(input.direction.x, 0, input.direction.y);
        move(par);
    }
}

