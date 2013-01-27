using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{

    public GameObject score_obj;
    public List<GameObject> level_list;
    private GameObject cur_level;
    private int level_index;

    void Start()
    {
        cur_level = level_list[0];
        level_index = 0;

    }

    void Update() {
        


    }

   public void LoadLevel() {

        level_index++;
        cur_level.SetActiveRecursively(false);
        level_list[level_index].SetActiveRecursively(true);
        cur_level = level_list[level_index];

    }
}
