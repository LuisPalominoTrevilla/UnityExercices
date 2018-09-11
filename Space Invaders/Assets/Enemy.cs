using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private int life;

    public GameObject bullet;
    public Transform bullet_position;
    private IEnumerator ie;
    private Coroutine c;

    // Use this for initialization
    void Start () {
        this.life = 3;
        transform.Translate(Random.value * 20 - 10, 0, 8, Space.World);
        this.ie = shoot();
        this.c = StartCoroutine(this.ie);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, -2 * Time.deltaTime, Space.World);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy the bullet
        if(other.gameObject.name == "UserBullet(Clone)")
        {
            Destroy(other.gameObject);
            if (this.life == 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.life--;
            }
        }
    }

    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            Instantiate<GameObject>(this.bullet, this.bullet_position.position, this.bullet.transform.rotation);
        }
    }
}
