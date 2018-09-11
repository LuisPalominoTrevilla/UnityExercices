using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Transform spawn;
    public GameObject coin;
    public GameObject original;
    public Transform bullet_spawn;
    public GameObject bullet;
    private IEnumerator ie;
    private Coroutine c;
    private int life;
    public Text score;

	// Use this for initialization
	void Start () {
        this.ie = spawnEnemies();
        this.c = StartCoroutine(ie);
        this.life = 10;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate<GameObject>(this.bullet, this.bullet_spawn.position, this.transform.rotation);
        }

        transform.Translate(h*Time.deltaTime*5, 0, v*Time.deltaTime*5, Space.World);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy(Clone)")
        {
            this.life--;
            this.updateLife();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cylinder")
        {
            Destroy(other.gameObject);
            this.life--;
            this.updateLife();
        }else if (other.gameObject.name == "Coin(Clone)")
        {
            Destroy(other.gameObject);
            this.life++;
            this.updateLife();
        }
    }

    private void updateLife()
    {
        this.score.text = "Life: " + this.life;
    }

    public void handleSlide(float val)
    {
        print(val);
    }

    IEnumerator spawnEnemies()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            Instantiate<GameObject>(original, spawn.position, original.transform.rotation);
            Instantiate<GameObject>(this.coin, spawn.position, this.coin.transform.rotation);
            Instantiate<GameObject>(this.coin, spawn.position, this.coin.transform.rotation);
        }
    }
}
