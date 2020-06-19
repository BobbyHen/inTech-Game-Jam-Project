using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class DroneScript : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    public GameObject drone;

    private AudioSource droneAudio;

    public AudioClip droneHit;

    public AudioClip droneDestroyed;

    void Start()
    {
        droneAudio = GetComponent<AudioSource>();
    }    

    public void TakeDamage (int damage)
    {
        health -= damage;

        droneAudio.PlayOneShot(droneHit, .75f);
        
        if ( health <= 0)
        {

            Die();
            
        }
    }

    void Die()
    {
        Debug.Log("Explosion");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        

        Destroy(gameObject);
        Destroy(drone);
    }



   
}
