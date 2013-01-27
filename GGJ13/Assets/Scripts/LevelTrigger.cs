using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour
{

    public GUITexture fade;
    public float faderate = .025f;
    public bool fadeBegin = false;
    public bool fadeOut = false;

    void Start()
    {
        fade.pixelInset = new Rect(0,0, Screen.width, Screen.height);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
			bool levelComplete = LevelHelper.IsLevelComplete();
			if(levelComplete) {
				fadeBegin = true;   
			}
				
        }
    }

    void Update()
    {
        if (fadeBegin) {
            fade.gameObject.SetActiveRecursively(true);
            fade.color += new Color(0, 0, 0, faderate * Time.deltaTime);
            if (fade.color.a > .9) {
                fadeOut = true;                
				fadeBegin = false;
            }
        } else if (fadeOut) {
            fade.color -= new Color(0,0,0, faderate * Time.deltaTime);
			if(fade.color.a <= 0f) {
				fadeOut = false;
			}
        }
    }

}
