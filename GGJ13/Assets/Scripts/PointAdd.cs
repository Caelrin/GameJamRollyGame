using UnityEngine;
using System.Collections;

public class PointAdd : MonoBehaviour
{

    public Material scored_mat;
    public GameObject score_object;
    public int score_valueL;

	void OnTriggerEnter(Collider other)
	{
	    if (other.gameObject.name == "Points")
	    {
	        other.GetComponent<MeshRenderer>().material = scored_mat;

            if(other.GetComponent<ScoreValue>())
            {
                score_valueL = other.GetComponent<ScoreValue>().score_value;
                if (!other.GetComponent<ScoreValue>().score_calc)
                {
                    score_object.GetComponent<PlayerScore>().AddPoints(score_valueL);
                    other.GetComponent<ScoreValue>().score_calc = true;
                }
            }
	    }


	}
}
