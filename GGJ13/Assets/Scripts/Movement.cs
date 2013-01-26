using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public GameObject player;
    public float movespeed;
    public Vector3 velocity = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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



	    player.transform.localPosition += velocity;
    }

    public Vector3 getVelocity()
    {
        return velocity;
    }
}

