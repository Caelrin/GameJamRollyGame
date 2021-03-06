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
	public float modulation;
	public Vector3 position;
	public bool hasControl;

	void Start () {
		gravity = .1f;
		modulation = 0f;
		position = player.transform.localPosition;
		hasControl = true;
	}
	
	void Update () {
		modulation = Mathf.Sin(Time.time * 10) / 3;
		float diameter = ballSize + modulation;
		
		if(hasControl) {
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
			
			if(velocity.y <= 0.5 ) {
				velocity *= .995f;
			}
			
			RaycastHit hit;
			if(Physics.Linecast(position, position - new Vector3(0, diameter + gravity, 0), out hit)) {
				if(hit.collider.gameObject.name == "floor") {
					velocity = CollisionHelper.GetVelocityAfterCollision(hit.normal * -1, velocity);	
				} else {
					velocity.y -= gravity;
				}
			} else {
				velocity.y -= gravity;
			}
			
				
			
		    position += velocity;
		}
		
		player.transform.localScale = new Vector3(diameter, diameter, diameter);
		player.transform.localPosition = position - new Vector3(0, modulation, 0);
	}


    public Vector3 getVelocity()
    {
        return velocity;
    }

    public void resetPOS(Vector3 startPOS)
    {
        position = startPOS;
  		velocity = new Vector3(0,0,0);
    }

    public IEnumerator DelayPOS(Vector3 startPOS)
    {
        yield return new WaitForSeconds(.3f);
        position = startPOS;
    }

    public void scaleBall()
    {
        if (ballSize > 2f) {
            ballSize -= .05f;
            player.transform.localPosition += new Vector3(0,-.05f,0);
            
        }

    }
}

