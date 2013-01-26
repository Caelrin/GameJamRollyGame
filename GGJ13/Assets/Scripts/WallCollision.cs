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
			
			if (bounce_back)
            {
                Vector3 temp = collider.GetComponent<Movement>().getVelocity();
				Vector3 velNormal = temp.normalized;
				float mag = temp.magnitude;
				Vector3 afterBounceVector = (velNormal - (2 * normal)).normalized * mag/2;
                collider.GetComponent<Movement>().velocity = afterBounceVector;
				collider.GetComponent<Transform>().localPosition -= normal * .1f;
            }
            else
            {
                collider.GetComponent<Movement>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }


    }
	
	
}
