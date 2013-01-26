using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour
{

    public float velocity_set;
    public bool bounce_back;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");

        if (other.gameObject.name == "Player")
        {
            Debug.Log("Collision in velocity zeroed");

            if (bounce_back)
            {
                Vector3 temp = other.GetComponent<Movement>().getVelocity();
                other.GetComponent<Movement>().velocity = -temp/2;
            }
            else
            {

                other.GetComponent<Movement>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }


    }
}
