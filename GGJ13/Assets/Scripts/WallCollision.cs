using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour
{
    public bool bounce_back;
	

    void OnCollisionEnter(Collision collision)
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
			
			float mag = 1.5f;
			
			Vector3 playerVelocity = collider.GetComponent<Movement>().getVelocity();
			Vector3 velNormal = playerVelocity.normalized;
			Vector3 afterHitVelocity = new Vector3();
			afterHitVelocity.y = (velNormal.y - (2 * normal.y)) * mag;//playerVelocity.y + (normal.y * playerVelocity.y) + (playerVelocity.x * normal.x) + (playerVelocity.z * normal.z);
			afterHitVelocity.x = (velNormal.x - (2 * normal.x)) * mag;
			afterHitVelocity.z = (velNormal.z - (2 * normal.z)) * mag;
			
			collider.GetComponent<Movement>().velocity = afterHitVelocity;
			
			Vector3 diffToPos = (Vector3.Scale(collider.GetComponent<Transform>().localScale /2, normal));
			Vector3 onObjectPos = origin - diffToPos;
			collider.GetComponent<Movement>().position = onObjectPos;
			float modulation = collider.GetComponent<Movement>().modulation/2;
			collider.GetComponent<Transform>().localPosition = onObjectPos + 
				Vector3.Scale(new Vector3(modulation,modulation,modulation), normal);	
            
        }


    }
	
	
}
