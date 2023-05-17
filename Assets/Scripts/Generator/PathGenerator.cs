using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] pathObjects;

    public Transform thresholdPoint;
    public float pathObjectDiff;

    void Update()
    {
        Generator();
    }

    private void Generator()
    {
        if (transform.position.z < thresholdPoint.position.z)
        {
            int random = Random.Range(0, pathObjects.Length);
            Instantiate(pathObjects[random], transform.position, transform.rotation);
            transform.position += new Vector3(0f, 0f, pathObjectDiff);
        }
    }
}
