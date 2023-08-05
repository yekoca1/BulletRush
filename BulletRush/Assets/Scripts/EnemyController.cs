using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField] private PlayerController player;
    void FixedUpdate()
    {
        var delta = -transform.position + player.transform.position;
        delta.y = 0;
        var par = delta.normalized;;
        move(par);
        transform.LookAt(player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}

