using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	
	private bool isGameOver;
	public GUITexture fadeToBlack;
	public GUIText finalScore;
	public float faderate;
    public bool fadeBegin = false;
	private float scoreAtGameEnd;	
	private float xOffset = 20.0f;
	
	// Use this for initialization
	void Start () {
		fadeToBlack.pixelInset = new Rect(0,0, Screen.width, Screen.height);
		isGameOver = false;
		finalScore.pixelOffset = new Vector2(xOffset, Screen.height - xOffset);
	    finalScore.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(isGameOver) {
			if (fadeBegin) {
	            fadeToBlack.gameObject.SetActiveRecursively(true);
	            fadeToBlack.color += new Color(0, 0, 0, faderate * Time.deltaTime);
	            if (fadeToBlack.color.a > .9) {            
					fadeBegin = false;
	            }
	        }
			if(!fadeBegin && Input.anyKeyDown) {
				Application.LoadLevel(0);
			}
		}
	}
	
	public void EndGame() {
		//if(isGameOver = false) {
			GameObject timer = GameObject.FindGameObjectWithTag("Timer");
            timer.SetActiveRecursively(false);
			//timer.gameObject.SetActive(false);
			GameObject score = GameObject.FindGameObjectWithTag("Score");
			scoreAtGameEnd = score.GetComponent<PlayerScore>().GetScore();
            score.SetActiveRecursively(false);
			//score.gameObject.SetActive(false);
			finalScore.text = "Game Over\nTotalScore: " + ((int)scoreAtGameEnd).ToString();
			isGameOver = true;
			fadeBegin =  true;
		//}
	}
}
