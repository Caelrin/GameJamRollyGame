using System;
using UnityEngine;

public class LevelHelper
{
	public static bool IsLevelComplete() {
		bool levelComplete = true;
		GameObject[] pointsInLevel = GameObject.FindGameObjectsWithTag ("Point");
		foreach(GameObject point in pointsInLevel) {
			if(! point.GetComponent<ScoreValue>().score_calc) {
				levelComplete = false;
			}
		}
		return levelComplete;
	}
}


