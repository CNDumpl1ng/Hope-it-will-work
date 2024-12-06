using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gameOverCanvas; // 游戏结束画布
    [SerializeField] private GameObject _startMenuCanvas; // 开始菜单画布
    [SerializeField] private GameObject _winCanvas; // 胜利画布
    [SerializeField] private int _winScore = 3; // 默认设置为 10


    public bool _gameStarted = false; // 标记游戏是否开始
    private int _score = 0; // 当前得分

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _winScore = 2; // Enforce win score
        Time.timeScale = 0f; // 游戏启动时暂停
    }

    public void StartGame()
    {
        _gameStarted = true; // 标记游戏已开始
        _startMenuCanvas.SetActive(false); // 隐藏开始菜单
        Time.timeScale = 1.0f; // 恢复时间流动
        _score = 0; // 重置得分
        FindObjectOfType<FlyBehaviour>()?.OnGameStart();
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true); // 显示游戏结束画布
        Time.timeScale = 0f; // 暂停游戏
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 重新加载场景
    }

    // 增加分数
    public void AddScore()
    {
        if (!_gameStarted) return;

        _score++;
        Debug.Log($"Current Score: {_score}, Target Score: {_winScore}");

        if (_score >= _winScore)
        {
            Debug.Log("Win condition met!");
            WinGame();
        }
    }


    // 胜利逻辑
    private void WinGame()
    {
        _gameStarted = false; // 停止游戏
        Time.timeScale = 0f; // 暂停时间流动
        _winCanvas.SetActive(true); // 显示胜利画布
    }
}
