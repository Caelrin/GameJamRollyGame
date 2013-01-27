using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour
{

    public GUIText countDown;
    private float xOffset = 20.0f;
    public float seconds = 70;

    void Start() {

        countDown.pixelOffset = new Vector2(Screen.width- (xOffset * 10), Screen.height - xOffset);

    }

    void Update() {
        if (seconds > 0.25) {
            seconds -= (1*Time.deltaTime);

        }
        if (seconds < 0.25) {
            seconds = 0.0f;
        }

        float renderMin = ((int)seconds / 60);
		float renderSeconds = seconds % 60;
        if (renderSeconds < 9.5)
        {
            countDown.text = renderMin.ToString() + " : 0" + renderSeconds.ToString("F0");
        }
        else
        {
            countDown.text = renderMin.ToString() + " : " + renderSeconds.ToString("F0");
        }

    }
	
	public void AddTime(int numSeconds) {
		seconds += 15;
	}
}
