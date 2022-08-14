using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    Rigidbody rb;
    public GameObject effect;
    public float speed;
    bool start;
    bool gOver;


    public float fall;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "collects")
        {
            GameObject part = Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(part, 1.0f);
            ScoreManager.instance.DiamondScore();

        }
    }

	void Start () {
        start = false;
        gOver = false;
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if (!start)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                start = true;

                GameManager.instance.on();
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f))
        {
            gOver = true;
            rb.velocity = new Vector3(0, -fall, 0);
            Destroy(gameObject, 1.0f);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.off();
        }

        if (Input.GetMouseButtonDown(0) && !gOver)
        {
            ChangePosition();
            ScoreManager.instance.IncrementScore();
        }
	}

    void ChangePosition()
    {
        if (rb.velocity.z > 0)
            rb.velocity = new Vector3(speed, 0, 0);
        else if (rb.velocity.x > 0)
            rb.velocity = new Vector3(0, 0, speed);
    }

    
}
