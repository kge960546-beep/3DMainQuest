using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    Clear,
}
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

    public GameState State { get; private set; } = GameState.Playing;
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
        SetState(GameState.Playing);
    }
    void Update()
    {
        if (spwd == null) return;

        if(score != null)
        {
           score.text = $"Score : {scoreCount} / {spwd.spawnCount}";
        }
        if (State == GameState.Playing && scoreCount >= spwd.spawnCount)
        {
            SetState(GameState.Clear);
        }
    }
    public void SetState(GameState newState)
    {
        State = newState;

        switch(State)
        {
            case GameState.Playing:
                Time.timeScale = 1.0f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameClear.gameObject.SetActive(false);
                reStart.gameObject.SetActive(false);
                exitGame.gameObject.SetActive(false);
                break;

            case GameState.Clear:
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                gameClear.gameObject.SetActive(true);
                reStart.gameObject.SetActive(true);
                exitGame.gameObject.SetActive(true);
                break;
        }
    }
    public void DisplayScore(int curscore)
    {
        scoreCount += curscore;              
    }   
    public void ReStart()
    {
        Time.timeScale = 1.0f;        
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
       Application.Quit();
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
