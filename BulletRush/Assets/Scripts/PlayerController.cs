using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField] private TouchController input;
    [SerializeField] private ShootController shootController;
    void FixedUpdate()
    {
        var par = new Vector3(input.direction.x, 0, input.direction.y);
        move(par);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Death();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Enemy"))
        {
            var direction = other.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized; //normalize edilmeli
            shootController.Shoot(direction, transform.position);
            transform.LookAt(other.transform); 
        }
    }
    private void Death()
    {
        Time.timeScale = 0;
    }
}

