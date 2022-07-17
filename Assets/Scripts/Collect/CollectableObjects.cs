using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    Collecter collecter;
    bool isCollected;
    int index;

    private void Start()
    {
        collecter = GameObject.Find("Collecter").GetComponent<Collecter>();
        isCollected = false;
    }

    private void Update()
    {
        if (isCollected && transform.parent != null) // if it is collected and has parent
        {
            transform.localPosition = new Vector3(0f, -index, 0f); //set the collected cube's position.

            if(transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstacles"))
        {
            collecter.DecreaseCubeHeight();
            transform.parent = null; //after collision lost its parent
            gameObject.AddComponent<ObjectMovement>();
            GetComponent<BoxCollider>().enabled = false; //to prevent issues
            other.gameObject.GetComponent<BoxCollider>().enabled = false; //to prevent multiple collisions.
        }
    }
    public bool getIsCollected()
    {
        return isCollected;
    }

    public void setIsCollected()
    {
        this.isCollected = true;
    }

    public void setIndex(int index)
    {
        this.index = index;
    }

    public int getIndex()
    {
        return index;
    }
}
