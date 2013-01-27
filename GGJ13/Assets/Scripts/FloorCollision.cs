using UnityEngine;
using System.Collections;

public class FloorCollision : MonoBehaviour
{
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
			Vector3 afterHitVelocity = CollisionHelper.GetVelocityAfterCollision (normal, temp);

			collider.GetComponent<Movement>().velocity = afterHitVelocity;
			
			Vector3 diffToPos = (Vector3.Scale(collider.GetComponent<Transform>().localScale /2, normal));
			Vector3 onObjectPos = origin - diffToPos;
			
			if(onObjectPos.y > collider.GetComponent<Movement>().position.y) {
				collider.GetComponent<Movement>().position = onObjectPos;
				collider.GetComponent<Transform>().localPosition = onObjectPos
					+ new Vector3(0,collider.GetComponent<Movement>().modulation/2,0);	
			}
		}
	}

	
}
