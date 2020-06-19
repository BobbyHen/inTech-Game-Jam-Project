using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject laserPrefab;
    private AudioSource weaponAudio;
    public AudioClip laserShot;


    private void Start()
    {
        weaponAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Shooting Logic
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        weaponAudio.PlayOneShot(laserShot, .25f);
    }
}
