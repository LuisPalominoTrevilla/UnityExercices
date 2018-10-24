using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour {
    private Enemy enemy;
	// Use this for initialization
	void Start () {
        this.enemy = gameObject.GetComponent<Enemy>();
        StartCoroutine(this.checkDistance());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(enemy.path[enemy.curr_node].transform);
        transform.Translate(0, 0, 3 * Time.deltaTime);
    }

    IEnumerator checkDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (Vector3.Distance(transform.position, enemy.path[enemy.curr_node].transform.position) < .3f)
            {
                enemy.curr_node += 1;
                enemy.curr_node %= enemy.path.Count;
            }
        }
    }
}
