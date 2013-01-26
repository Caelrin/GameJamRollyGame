using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public GameObject player;
    public GameObject main_camera;
    public GameObject score_obj;
    public float movespeed;
    public Vector3 velocity = new Vector3(0,0,0);
	public float ballSize;
	public float gravity;

	void Start () {
		gravity = .05f;
	}
	
	void Update () {
	
        if (Input.GetKey(KeyCode.D))
        {
           velocity += new Vector3(movespeed*Time.deltaTime, 0, 0);
        }

	    if (Input.GetKey(KeyCode.A))
	    {
            velocity -= new Vector3(movespeed * Time.deltaTime, 0, 0);
	    }
	    if (Input.GetKey(KeyCode.W))
	    {
            velocity += new Vector3(0,0, movespeed * Time.deltaTime );
	    }
         if (Input.GetKey(KeyCode.S))
	    {
            velocity -= new Vector3(0,0, movespeed * Time.deltaTime );
	    }

        if (Input.GetKey(KeyCode.E))
        {
           scaleBall();
        }
		
		
		if(velocity.y <= 0.5 ) {
			velocity *= .995f;
		}
		
		velocity.y -= gravity;
		
		float modulation = Mathf.Sin(Time.time * 10) / 3;
		float diameter = ballSize;// + modulation;
	    player.transform.localScale = new Vector3(diameter, diameter, diameter);
	    player.transform.localPosition += velocity;
	    
	}

    public Vector3 getVelocity()
    {
        return velocity;
    }

    public void scaleBall()
    {
        if (ballSize > 2f) {
            ballSize -= .05f;
            player.transform.localPosition += new Vector3(0,-.05f,0);
            
        }

    }
}

