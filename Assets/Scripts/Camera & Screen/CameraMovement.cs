using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime); //camera, follow main cube with t.dt speed
    }
}
