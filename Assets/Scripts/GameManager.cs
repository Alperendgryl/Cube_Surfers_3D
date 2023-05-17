using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool canMove;
    public static bool _canMove;

    [SerializeField] private GameObject deletionThreshold;
    public static GameObject _deletionThreshold;

    private bool coinHitFrame;
    private bool gameStarded;

    [Header("SetActive")]
    [SerializeField] private GameObject[] ActiveStart;
    [SerializeField] private GameObject[] ActiveEnd;
    [SerializeField] private GameObject DeathPanel;

    [Header("UI")]
    [SerializeField] private TMP_Text scoreTXT;
    private float score;

    [SerializeField] private TMP_Text bestScoreTXT;
    [SerializeField] private TMP_Text NewBestScoreTXT;
    [SerializeField] private TMP_Text endScoreTXT;
    private float bestScore;

    public TMP_Text coinsTXT;
    public TMP_Text endCoinsTXT;
    [HideInInspector] public int coinsTotal;
    private int coinsCollectedPerGame;

    [Header("Speed")]
    [SerializeField] private float worldSpeed;
    public static float _worldSpeed;

    [SerializeField] private float IncreaseSpeedTimeDiff;
    [SerializeField] private float speedMultiplier;
    public static float _speedMultiplier;

    private float Counter;
    private int continueCounter;

    public void Start()
    {
        WhileStart();
    }
    public void Update()
    {
        Score();
        IncreaseSpeed();
        WhileUpdate();
        LosePanel();
    }
    private void LosePanel()
    {
        if (score > bestScore)
        {
            bestScore = score;
            NewBestScoreTXT.text = "NEW BEST SCORE";
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
        bestScoreTXT.text = ((int)bestScore).ToString();
        endScoreTXT.text = ((int)score).ToString();
        endCoinsTXT.text = ((int)coinsCollectedPerGame).ToString();
    }
    private void WhileUpdate()
    {
        coinsTotal = PlayerPrefs.GetInt("Coin");
        bestScore = PlayerPrefs.GetFloat("BestScore");

        _canMove = canMove;
        _worldSpeed = worldSpeed;
        _deletionThreshold = deletionThreshold;
        _speedMultiplier = speedMultiplier;

        coinHitFrame = false;

        coinsTXT.text = coinsTotal.ToString();
    }
    private void WhileStart()
    {
        Counter = IncreaseSpeedTimeDiff;
        coinsCollectedPerGame = 0;
        continueCounter = 0;
    }
    public void GameStarts()
    {
        if (!gameStarded) //Input.GetMouseButtonDown(0) && 
        {
            canMove = true;
            gameStarded = true;

            for (int i = 0; i < ActiveStart.Length; i++)
            {
                ActiveStart[i].SetActive(false);
            }
        }
    }
    private void IncreaseSpeed()
    {
        if (canMove)
        {
            Counter -= Time.deltaTime;

            if (Counter <= 0)
            {
                Counter = IncreaseSpeedTimeDiff;
                worldSpeed *= speedMultiplier;
            }
        }
    }
    public void Hit()
    {
        canMove = false;
        StartCoroutine(GameEnd());
    }
    private IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < ActiveEnd.Length; i++)
        {
            ActiveEnd[i].SetActive(false);
        }
        DeathPanel.SetActive(true);
    }
    public void CoinCollected()
    {
        if (!coinHitFrame)
        {
            coinsTotal += 1;
            coinsCollectedPerGame += 1;
            coinHitFrame = true;
            PlayerPrefs.SetInt("Coin", coinsTotal);
        }
    }
    private void Score()
    {
        if (canMove)
        {
            score += Time.deltaTime * worldSpeed;
            scoreTXT.text = ((int)score).ToString();
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
