using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField] private TouchController input;
    [SerializeField] private ShootController shootController;
    private List<Transform> enemies = new List<Transform>();

    public MyGameManager gameManager;
    private bool isLookingEnemy;


    void Start()
    {
        gameManager = FindObjectOfType<MyGameManager>();
        isLookingEnemy = false;
    }
    void FixedUpdate()
    {
        var par = new Vector3(input.direction.x, 0, input.direction.y);
        move(par);

        if (Input.GetMouseButtonDown(0) && !isLookingEnemy) // Sol tıklama tuşu ile tıklama kontrolü || düşmana bakmadığı zamanlarda olması için bir bool yapıldı ama tam olmuyor
        {
            // Fare tıklamasının dünya koordinatlarına dönüştürülmesi
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(targetPosition);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            gameManager.Death();
        }
        if(collision.transform.CompareTag("Engel"))
        {
            gameObject.SetActive(false);
            gameManager.Death();
        }
        if(collision.transform.CompareTag("End"))
        {
            gameManager.Win();            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Enemy"))
        {
            if(!enemies.Contains(other.transform))
            {
                enemies.Add(other.transform);
            }
            AutoShoot();
            /*var direction = other.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized; //normalize edilmeli
            shootController.Shoot(direction, transform.position);
            transform.LookAt(other.transform);*/ 
        }
    }
    private bool isShooting;
    public void AutoShoot()
    {
        IEnumerator Do()
        {
            while(enemies.Count > 0)
            {   
                var enemy = enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized; //normalize edilmeli
                shootController.Shoot(direction, transform.position);
                transform.LookAt(enemy.transform);
                enemies.RemoveAt(0);
                yield return new WaitForSeconds(shootController.delay);
                isLookingEnemy = true;
            }
            isShooting = false;
            isLookingEnemy = false;
        }
        if(!isShooting)
        {
            isShooting = true;
            StartCoroutine(Do());
            
        }
    }
    
}

