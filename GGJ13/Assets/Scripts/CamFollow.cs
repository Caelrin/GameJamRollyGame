using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public GameObject target;
	public GameObject thisCamera;
	private float goalY;
	
	void Start() {
		goalY = 40;
	}
	
    void Update()
    {
		if(target.GetComponent<Movement>().position.z < -80) {
			goalY = 150;
		} else { 
			goalY = 40;
		}
		Vector3 diffVector = transform.position - 
			(target.GetComponent<Movement>().position);
		Vector3 moveVector = (new Vector3(0, goalY, -80) - diffVector) / 30;
		CapCameraBound (diffVector, ref moveVector);
		transform.position += moveVector;
		
		
        transform.LookAt(target.GetComponent<Movement>().position);
  
    }

	void CapCameraBound (Vector3 diffVector, ref Vector3 moveVector)
	{
		if(diffVector.z > -40) {
    		moveVector.z = -40 - diffVector.z;
    	}
		if(diffVector.z < -250) {
    		moveVector.z *= 2;
    	}
		if(diffVector.x < -50 || diffVector.z < 50) {
    		moveVector.x *= 2 ;
    	}
	}
}
