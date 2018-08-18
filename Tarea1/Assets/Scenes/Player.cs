using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float velocidad;
    private Vector3 jump = new Vector3(0.0f, 1000.0f, 0.0f);
    private int score = 0;
    private int currentTargetScore = 0;
    public Text displayScore;

    private float tiltAngle = 0.0f;
    private float smooth = 5.0f;
    private Quaternion target;

    private float h, v;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        this.h = Input.GetAxis("Horizontal");
        this.v = Input.GetAxis("Vertical");

        transform.Translate(h * this.velocidad * Time.deltaTime,
            0,
            v * this.velocidad * Time.deltaTime,
            Space.Self);
        
        if (Input.GetKeyDown("space") && GetComponent<Rigidbody>().transform.position.y < 2.5f) {
            GetComponent<Rigidbody>().AddForce(this.jump);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * this.smooth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "ScoreBottom" && this.currentTargetScore == 0 || other.transform.name == "ScoreTop" && this.currentTargetScore == 1) {
            this.score += 20;
            this.tiltAngle = this.currentTargetScore * -180;
            this.currentTargetScore = (this.currentTargetScore + 1) % 2;
            this.target = Quaternion.Euler(0, this.tiltAngle, 0);
        }
        else if(other.transform.name != "ScoreBottom" && other.transform.name != "ScoreTop")
        {
            // Collision with enemy
            GetComponent<AudioSource>().Play();
            this.score -= 5;
        }
        this.displayScore.text = "Score: " + this.score;
    }
}
