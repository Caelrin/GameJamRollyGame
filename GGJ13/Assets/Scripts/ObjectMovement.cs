using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour {
	
	
	public float PointValue;
	private Vector3 lastKnownPos;
	public GameObject thisObject;
	// Use this for initialization
	void Start () {
		lastKnownPos = thisObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currPos = thisObject.transform.localPosition;
		Vector3 diff = currPos - lastKnownPos;
		float magnitudeOfDiff = diff.magnitude;
		if(currPos.y > -5) {
			if(magnitudeOfDiff > 0) {
				GameObject score = GameObject.FindGameObjectWithTag("Score");
				score.GetComponent<PlayerScore>().AddPoints(magnitudeOfDiff * PointValue);
			}
		}
		lastKnownPos = currPos;
	}
}
