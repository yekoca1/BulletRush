using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : Controller
{
    [SerializeField] private PlayerController player;
    [SerializeField] private ParticleSystem deadPartical;
    private float enemyLife = 3;
    

    void Start()
    {
        
                
    }
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
            enemyLife --;
            if(enemyLife == 0)
            {
                gameObject.SetActive(false);
                other.gameObject.SetActive(false);
                var ParticleSystem = Instantiate(deadPartical, transform.position, Quaternion.identity);
                ParticleSystem.transform.localScale = Vector3.one*Random.Range(0.1f, 0.2f);
                player.decreaseBar();
            }
        }
    }
}

