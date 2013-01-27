using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour
{

    public GUITexture fade;
    public float faderate = .025f;
    public bool fadeBegin = false;
    public bool fadeOut = false;
    public GameObject level_loader;
	public GameObject player;

    void Start()
    {
        fade.pixelInset = new Rect(0,0, Screen.width, Screen.height);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
			bool levelComplete = LevelHelper.IsLevelComplete();
			if(levelComplete &! fadeBegin) {
                Debug.Log("LOAD NEXT LEVEL");
				fadeBegin = true;
				GameObject timer = GameObject.FindGameObjectWithTag("Timer");
				timer.GetComponent<CountDown>().AddTime(15);
				player.GetComponent<Movement>().hasControl = false;
			}
				
        }
    }

    void Update()
    {
        if (fadeBegin) {
            Debug.Log("faded STARTED");
            fade.gameObject.SetActiveRecursively(true);
            fade.color += new Color(0, 0, 0, faderate * Time.deltaTime);
            if (fade.color.a > .9) {
				level_loader.GetComponent<LevelLoader>().LoadLevel();
                fadeOut = true;                
				fadeBegin = false;
            }
        } else if (fadeOut) {
            fade.color -= new Color(0,0,0, faderate * Time.deltaTime);
			if(fade.color.a <= 0f) {
				player.GetComponent<Movement>().hasControl = true;
				fadeOut = false;
			}
        }
    }

}
