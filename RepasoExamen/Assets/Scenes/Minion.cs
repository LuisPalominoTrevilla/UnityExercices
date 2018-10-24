using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

    public GameObject player;
    private float followSpeed;
	// Use this for initialization
	void Start () {
        this.followSpeed = 2.1f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = player.transform.position;
        target.y = 0;
        transform.LookAt(target);
        float distance = Vector3.Distance(transform.position, this.player.transform.position);
        if (distance > 3)
        {
            transform.Translate(0, 0, this.followSpeed * Time.deltaTime);
        }
	}

    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
