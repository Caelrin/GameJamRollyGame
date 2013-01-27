using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public GameObject target;
	public GameObject thisCamera;
	
    void Update()
    {
		Vector3 diffVector = transform.position - 
			(target.GetComponent<Movement>().position);// - new Vector3(0, target.GetComponent<Movement>().modulation/2, 0));
		Vector3 moveVector = (new Vector3(0, 40, -80) - diffVector) / 30;
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
