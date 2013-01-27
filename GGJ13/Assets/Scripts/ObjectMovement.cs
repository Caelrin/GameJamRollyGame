using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour
{


    public float PointValue;
    private Vector3 lastKnownPos;
    // Use this for initialization
    private void Start()
    {
        lastKnownPos = transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 currPos = transform.localPosition;
        Vector3 diff = currPos - lastKnownPos;
        float magnitudeOfDiff = diff.magnitude;
        if (currPos.y > -5)
        {
            if (magnitudeOfDiff > 0)
            {
                GameObject score = GameObject.FindGameObjectWithTag("Score");
                score.GetComponent<PlayerScore>().AddPoints(magnitudeOfDiff*PointValue);
            }
        }
        lastKnownPos = currPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>().PlayOneShot(
                GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundFXHandler>().hit);
        }
    }


}
