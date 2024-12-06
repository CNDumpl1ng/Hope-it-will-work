using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gameOverCanvas; // ��Ϸ��������
    [SerializeField] private GameObject _startMenuCanvas; // ��ʼ�˵�����
    [SerializeField] private GameObject _winCanvas; // ʤ������
    [SerializeField] private int _winScore = 3; // Ĭ������Ϊ 10


    public bool _gameStarted = false; // �����Ϸ�Ƿ�ʼ
    private int _score = 0; // ��ǰ�÷�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _winScore = 2; // Enforce win score
        Time.timeScale = 0f; // ��Ϸ����ʱ��ͣ
    }

    public void StartGame()
    {
        _gameStarted = true; // �����Ϸ�ѿ�ʼ
        _startMenuCanvas.SetActive(false); // ���ؿ�ʼ�˵�
        Time.timeScale = 1.0f; // �ָ�ʱ������
        _score = 0; // ���õ÷�
        FindObjectOfType<FlyBehaviour>()?.OnGameStart();
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true); // ��ʾ��Ϸ��������
        Time.timeScale = 0f; // ��ͣ��Ϸ
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ���¼��س���
    }

    // ���ӷ���
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


    // ʤ���߼�
    private void WinGame()
    {
        _gameStarted = false; // ֹͣ��Ϸ
        Time.timeScale = 0f; // ��ͣʱ������
        _winCanvas.SetActive(true); // ��ʾʤ������
    }
}
