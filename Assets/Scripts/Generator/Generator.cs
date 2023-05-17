using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameManager gameManager;

    [Header("Obstacle")]
    public GameObject[] obstacles;
    public float obstacleTimeDiff = 5f;
    private float obstacleConstant;

    [Header("Coins")]
    public GameObject[] coins;
    public float coinsTimeDiff = 4f;
    private float coinsConstant;

    [Header("Collectable Cubes")]
    public GameObject[] cubes;
    public float cubesTimeDiff = 3f;
    private float cubesConstant;

    [Header("Background Objects")]
    public GameObject[] backgroundObjects;
    public float backgroundObjectsTimeDiff = 10f;
    private float backgroundObjectsConstant;
    public Transform minPos, maxPos;

    void Start()
    {
        obstacleConstant = obstacleTimeDiff;
        coinsConstant = coinsTimeDiff;
        cubesConstant = cubesTimeDiff;
        backgroundObjectsConstant = backgroundObjectsTimeDiff;
    }


    void Update()
    {
        ObstacleGenerator();
        CoinGenerator();
        CollectableCubeGenerator();
        BackgroundObjectGenerator();
    }

    private void ObstacleGenerator()
    {
        if (GameManager._canMove)
        {
            obstacleConstant -= Time.deltaTime;

            if (obstacleConstant <= 0)
            {
                int random = Random.Range(0, obstacles.Length);
                Instantiate(obstacles[random], transform.position, Quaternion.identity);
                obstacleConstant = Random.Range(obstacleTimeDiff / 4, obstacleTimeDiff);
            }
        }
    }

    private void CoinGenerator()
    {
        if (GameManager._canMove)
        {
            coinsConstant -= Time.deltaTime;

            if (coinsConstant <= 0)
            {
                int random = Random.Range(0, coins.Length);
                int randomPos = Random.Range(-3, 3);

                Instantiate(coins[random], new Vector3(randomPos, transform.position.y, transform.position.z), Quaternion.identity);
                coinsConstant = Random.Range(coinsTimeDiff * 0.5f, coinsTimeDiff * 1.25f);
            }
        }
    }

    private void CollectableCubeGenerator()
    {
        if (GameManager._canMove)
        {
            cubesConstant -= Time.deltaTime;

            if (cubesConstant <= 0)
            {
                int random = Random.Range(0, cubes.Length);


                Instantiate(cubes[random], new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                cubesConstant = Random.Range(cubesTimeDiff * 0.5f, cubesTimeDiff * 1.25f);
            }
        }
    }

    private void BackgroundObjectGenerator()
    {
        if (GameManager._canMove)
        {
            backgroundObjectsConstant -= Time.deltaTime;

            if (backgroundObjectsConstant <= 0)
            {
                int random = Random.Range(0, backgroundObjects.Length);
                float randomPos = Random.Range(minPos.transform.position.x, maxPos.transform.position.x);

                Instantiate(backgroundObjects[random], new Vector3(randomPos, 0f, transform.position.z), Quaternion.identity);
                backgroundObjectsConstant = Random.Range(backgroundObjectsTimeDiff * 0.5f, backgroundObjectsTimeDiff * 1.25f);
            }
        }
    }
}
