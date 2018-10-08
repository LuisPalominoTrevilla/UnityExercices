using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject bullet;
	// Use this for initialization
	void Start () {
        StartCoroutine(this.shoot());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            float x = Random.Range(-11f, 7);
            float y = .2f;
            float z = Random.Range(-20f, 1);
            this.transform.LookAt(new Vector3(x,y,z));
            Instantiate<GameObject>(this.bullet, this.transform.position, this.transform.rotation);
        }
    }
}
