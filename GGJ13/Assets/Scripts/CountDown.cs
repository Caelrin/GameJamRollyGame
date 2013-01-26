using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour
{

    public GUIText countDown;
    private float xOffset = 20.0f;
    public float mins = 1;
    public float seconds = 5;

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

        if (seconds == 0 && mins > 0) {
            mins = 0;
            seconds = 60;
        }

        if (seconds < 9.5)
        {
            countDown.text = mins.ToString() + " : 0" + seconds.ToString("F0");
        }
        else
        {
            countDown.text = mins.ToString() + " : " + seconds.ToString("F0");
        }

    }
}
