using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecter : MonoBehaviour
{
    public GameObject player;
    public int cubeHeight = 0;

    void Update()
    {
        player.transform.position = new Vector3(transform.position.x, cubeHeight + 1f, transform.position.z); // when cubes collected, increase the height of the main cube. Only Y axis, others will be same!
        this.transform.localPosition = new Vector3(0f, -cubeHeight, 0f); //if cube height increases, collecter cube should be at the bottom. Relative to the parent!
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Collectable") && other.gameObject.GetComponent<CollectableObjects>().getIsCollected() == false)
        {
            cubeHeight++;
            other.gameObject.GetComponent<CollectableObjects>().setIsCollected(); // prevent "collect" issues
            other.gameObject.GetComponent<CollectableObjects>().setIndex(cubeHeight); //set the height of the cube, check how many cubes?
            other.gameObject.transform.parent = player.transform; //set new cube's parent as main cube
        }
        if (other.gameObject.tag.Equals("Coin"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().coinsTotal++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("Obstacles") && cubeHeight == 0)
        {
            FindObjectOfType<GameManager>().canMove = false;
            ShakeController._isShake = true;
        }
    }

    public void DecreaseCubeHeight()
    {
        cubeHeight--;
    }
}
