using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource sound;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip fail;
    [SerializeField] private AudioClip finish;
    
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        sound.PlayOneShot(shoot);
    }

    public void Fail()
    {
        sound.PlayOneShot(fail);
    }

    public void Finish()
    {
        sound.PlayOneShot(finish);
    }
}