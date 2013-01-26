using UnityEngine;
using System.Collections;

public class FloorCollision : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
    {
		Collide (collision);
    }
	
	void OnCollisionStay(Collision collision)
    {
		Collide (collision);
	}

	void Collide (Collision collision)
	{
		Collider collider = collision.collider;
		
		if (collider.gameObject.name == "Player")
		{
			Vector3 origin = new Vector3(0,0,0);
			Vector3 normal = new Vector3(0,0,0);
			int length = collision.contacts.Length;
			foreach (ContactPoint contact in collision.contacts) {
				origin += contact.point/length;
				normal += contact.normal/length;
			}
			
			
			Vector3 temp = collider.GetComponent<Movement>().getVelocity();
			Vector3 velNormal = temp.normalized;
			float mag = 1f;
			Vector3 afterBounceVector = new Vector3();
			afterBounceVector.y = temp.y + (normal.y * temp.y) + (temp.x * normal.x) + (temp.z * normal.z);
			afterBounceVector.x = temp.x - (normal.x * mag);
			afterBounceVector.z = temp.z - (normal.z * mag);

			collider.GetComponent<Movement>().velocity = afterBounceVector;
			
			Vector3 diffToPos = (Vector3.Scale(collider.GetComponent<Transform>().localScale /2, normal));
			Vector3 onObjectPos = origin - diffToPos;
			
			collider.GetComponent<Transform>().localPosition = onObjectPos;			
		}
	}
}