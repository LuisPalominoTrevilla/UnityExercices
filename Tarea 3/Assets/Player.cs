using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float velocity;
    public Camera cam;
    public GameObject bullet;
    public Transform gun;
    public Animator animator;
	// Use this for initialization
	void Start () {
        this.velocity = 3.5f;
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        this.transform.Translate(h * this.velocity * Time.deltaTime, 0, v * this.velocity * Time.deltaTime, Space.World);

        if (Mathf.Abs(h) > .01 || Mathf.Abs(v) > .01)
        {
            this.animator.SetBool("Moving", true);
        }
        else
        {
            this.animator.SetBool("Moving", false);
        }

        Ray ray = this.cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
        if (Physics.Raycast(ray, out hit2))
        {
            Vector3 Distance = -this.transform.position + hit2.point;
            Distance.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Distance), .7f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray rayitito = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayitito, out hit))
            {
                this.gun.transform.LookAt(hit.point);
                Instantiate<GameObject>(bullet, this.gun.position, this.gun.rotation);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CanonBall(Clone)")
        {
            this.animator.SetTrigger("wasHit");
            StartCoroutine(this.stunned());
        }
    }

    IEnumerator stunned()
    {
        yield return new WaitForSeconds(1);
        this.animator.ResetTrigger("wasHit");
    }

}
