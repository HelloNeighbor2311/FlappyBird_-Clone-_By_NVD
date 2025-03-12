using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameplayController : Singleton<GameplayController>
{
    public GameObject LooseScene, FirstScene;
    public TMP_Text score;
    public int scoreIndex = 0;
    public bool isReady;

    public PlayerController playerController;
    public HandleSpawnPipe spawnPipe;
    public AudioManager Audio;
    public Button btnStart, btnRetry, btnQuit;
    private void Awake()
    {
        Instance = this;
        btnStart.onClick.AddListener(HandlePlay);

    }
    public void Init()
    {
        score.text = 0.ToString();
        scoreIndex = 0;
        btnRetry.onClick.AddListener(HandleRetry);
        btnQuit.onClick.AddListener(HandleQuit);
    }
    private void Update()
    {
        UpdateScore();
    }
    public void LoosePopUp()
    {
        Audio.playAudio(Audio.death);
        LooseScene.SetActive(true);
        Time.timeScale = 0f;
    }
    void UpdateScore()
    {
        score.text = scoreIndex.ToString();
    }
    public void HandleRetry()
    {
        playerController.ReturnPos();
        playerController.Init();
        LooseScene.SetActive(false);
        spawnPipe.Clear();
        Time.timeScale = 1f;

    }
    public void HandlePlay()
    {
        FirstScene.SetActive(false);
        playerController.Init();
        spawnPipe.Clear();
        spawnPipe.Init();
        Init();
        Time.timeScale = 1f;
    }
    public void HandleQuit()
    {
       Application.Quit();
    }
}
