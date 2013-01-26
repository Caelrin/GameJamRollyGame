using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public Transform target;

    void Update()
    {
        transform.LookAt(target);
  
    }

}
