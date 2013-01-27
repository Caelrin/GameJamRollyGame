using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    public GUIText gui_score;
    public GameObject Level_obj;
    public float score;
    private float xOffset = 20.0f;
	// Use this for initialization
	void Start ()
	{
	    gui_score.pixelOffset = new Vector2(xOffset, Screen.height - xOffset);
	    gui_score.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	    gui_score.text = ((int)score).ToString();
	}

    public void AddPoints(float points) {
        score += points;
        
    }
	
	public float GetScore() {
		return score;
	}
}
