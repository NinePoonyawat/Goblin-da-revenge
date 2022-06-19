using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMap : MonoBehaviour
{
    private bool isAlreadyTrigger = false;
    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && !isAlreadyTrigger)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isAlreadyTrigger = true;
                SceneHandler.instance.Load("ChapterOneMap");
            }
        }
    }
}
