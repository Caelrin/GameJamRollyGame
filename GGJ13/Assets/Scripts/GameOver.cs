using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	
	private bool isGameOver = false;
	public GameObject fadeToBlack;
	public GameObject finalScore;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isGameOver) {
		}
	}
	
	public void EndGame() {
		isGameOver = true;
	}
}
