using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody2D laserRb;
    // Start is called before the first frame update
    void Start()
    {
        laserRb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        DroneScript enemy = hitInfo.GetComponent<DroneScript>();

        if(enemy !=null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }


}
