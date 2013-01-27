using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{

    public GameObject score_obj;
    public List<GameObject> level_list;
    public GameObject player;
    private GameObject cur_level;
    private int level_index;
    public Vector3 startPOS;

    void Start()
    {
        startPOS = player.transform.position;
        cur_level = level_list[0];
        level_index = 0;

    }


   public void LoadLevel() {

       if (level_list.Count > level_index+1)
       {
           level_index++;
       }
       cur_level.SetActiveRecursively(false);
        level_list[level_index].SetActiveRecursively(true);
        cur_level = level_list[level_index];
       Debug.Log("MOVE PLAYER");
       player.GetComponent<Movement>().resetPOS(startPOS);

       GameObject.FindGameObjectWithTag("Gate").animation["open"].speed = -1.0f;
       GameObject.FindGameObjectWithTag("Gate").animation.Play();


   }
}
