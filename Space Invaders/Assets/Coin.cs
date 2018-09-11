using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Translate(Random.value * 20 - 10, 0, 8, Space.World);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, -4 * Time.deltaTime, Space.World);
	}
}
