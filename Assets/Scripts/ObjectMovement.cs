using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    //public float deleteThreshold;
    void Update()
    {
        moveObjects();
    }
    private void moveObjects()
    {
        if (GameManager._canMove) // Start & Stop
        {
            transform.position -= new Vector3(0f, 0f, GameManager._worldSpeed  * Time.deltaTime); //Remove 0 from X, 0 from Y and movespeed * time from Z axis.
        }

        if (transform.position.z < GameObject.Find("DeletionThreshold").transform.position.z) //
        {
            Destroy(gameObject);
        }
    }
}
