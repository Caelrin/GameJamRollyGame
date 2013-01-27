using UnityEngine;
using System.Collections;

public class PointAdd : MonoBehaviour
{

    public Material scored_mat;
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
                    GameObject.FindGameObjectWithTag("Score").GetComponent<PlayerScore>().AddPoints(score_valueL);
                    other.GetComponent<ScoreValue>().score_calc = true;
					
					bool levelComplete = true;
                    Debug.Log(levelComplete);

					GameObject[] pointsInLevel = GameObject.FindGameObjectsWithTag ("Point");
					foreach(GameObject point in pointsInLevel) {
						if(! point.GetComponent<ScoreValue>().score_calc) {
							levelComplete = false;
						}
					}
					if(levelComplete)
					{
					    GameObject.FindGameObjectWithTag("Gate").animation["open"].speed = 1.0f;
						GameObject.FindGameObjectWithTag("Gate").animation.Play();
					}
                }
            }
	    }


	}
}
