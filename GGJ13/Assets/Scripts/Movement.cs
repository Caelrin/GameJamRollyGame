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
		gravity = .05f;
		modulation = 0f;
		position = player.transform.localPosition;
		hasControl = true;
	}
	
	void Update () {
		modulation = Mathf.Sin(Time.time * 10) / 3;
		float diameter = ballSize + modulation;
		
		Debug.Log("Has Control" + hasControl);
		//if(hasControl) {
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
			
			velocity.y -= gravity;
		    
		//}
		
		position += velocity;
		
        if (Input.GetKey(KeyCode.E))
        {
          // scaleBall();
            GameObject.FindGameObjectWithTag("Gate").animation["open"].speed = -1;
                GameObject.FindGameObjectWithTag("Gate").animation.Play();

            Debug.Log("CALLING CLOSE");
        }
		
		player.transform.localScale = new Vector3(diameter, diameter, diameter);
		MoveToCurrentPost();
	}
	
	private void MoveToCurrentPost() {
		player.transform.localPosition = position - new Vector3(0, modulation/2, 0);
	}

    public Vector3 getVelocity()
    {
        return velocity;
    }

    public void resetPOS(Vector3 startPOS)
    {
        position = startPOS;
        MoveToCurrentPost();
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

