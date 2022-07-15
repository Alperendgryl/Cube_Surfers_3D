using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sideSpeed;

    [SerializeField] private float rightL;
    [SerializeField] private float leftL;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Collecter collecter;
  
    void Update()
    {
        if (gameManager.canMove)
        {
            float horizontalSpeed = Input.GetAxis("Horizontal") * sideSpeed * Time.deltaTime; //get horizontal input
            transform.Translate(horizontalSpeed, 0f, 0f); //x,y,z speed

            if (transform.position.x >= rightL) transform.position = new Vector3(rightL, transform.position.y, transform.position.z); //right limit
            if (transform.position.x <= leftL) transform.position = new Vector3(leftL, transform.position.y, transform.position.z); //left limit
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstacles") && collecter.cubeHeight == 0)
        {
            gameManager.Hit();
            audioSource.Play();
            ShakeController._isShake = true;
        }
    }
}
