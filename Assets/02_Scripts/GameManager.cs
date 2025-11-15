using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private SpawnWeeds spwd;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI weedUi;

    [Header("UI")]
    [SerializeField] private Transform gameClear;
    [SerializeField] private Transform reStart;
    [SerializeField] private Transform exitGame;
    [SerializeField] private Transform startGame;

    private int scoreCount = 0;
    private bool clearGame;

    private void Awake()
    {        
        if(Instance == null)
        {
            Instance = this;            
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        clearGame = false;

        gameClear.gameObject.SetActive(false);
        reStart.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);      
    }
    void Update()
    {
        if(score != null)
        {
           score.text = $"Score : {scoreCount} / {spwd.spawnCount}";
        }
        if (scoreCount >= spwd.spawnCount)
        {
            clearGame = true;
            ClearGame();
        }
    }
    public void DisplayScore(int curscore)
    {
        scoreCount += curscore;              
    }   
    public void ReStart()
    {
        Time.timeScale = 1.0f;
        clearGame = false;
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
       Application.Quit();
    }   
    private void ClearGame()
    {
        gameClear.gameObject.SetActive(true);
        reStart.gameObject.SetActive(true);
        exitGame.gameObject.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ShowWeedUI()
    {
        if (weedUi == null) return;

        weedUi.gameObject.SetActive(true);
        weedUi.text = "Press the E key";
    }
    public void HideWeedUI()
    {
        if (weedUi == null) return;
        weedUi.gameObject.SetActive(false);


    }
}
