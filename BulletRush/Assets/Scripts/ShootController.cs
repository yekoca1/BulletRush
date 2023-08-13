using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    
    public float delay;

    public SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void Shoot(Vector3 direction, Vector3 position)  // sadece kurşun yaratır
    {
        var bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.Fire(direction);
        soundManager.Shoot();
    }
}
