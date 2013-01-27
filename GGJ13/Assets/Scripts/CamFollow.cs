using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public GameObject target;
	public GameObject thisCamera;
	
    void Update()
    {
		Vector3 diffVector = transform.position - 
			(target.GetComponent<Transform>().position - new Vector3(0, target.GetComponent<Movement>().modulation, 0));
		Vector3 moveVector = (new Vector3(0, 30, -50) - diffVector) / 30;
		CapCameraBound (diffVector, ref moveVector);
		transform.position += moveVector;
		
        transform.LookAt(target.GetComponent<Transform>());
  
    }

	void CapCameraBound (Vector3 diffVector, ref Vector3 moveVector)
	{
		if(diffVector.z > -30) {
    		moveVector.z = -30 - diffVector.z;
    	}
		if(diffVector.z < -100) {
    		moveVector.z *= 2;
    	}
		if(diffVector.x < -50 || diffVector.z < 50) {
    		moveVector.x *= 2 ;
    	}
	}
}
