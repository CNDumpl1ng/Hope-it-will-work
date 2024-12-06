using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab; // 管道预制体
    [SerializeField] private float _spawnInterval = 2f; // 管道生成间隔
    [SerializeField] private float _heightRange = 2f; // 管道随机高度范围

    private float _timer = 0f;

    private void Update()
    {
        // 游戏未开始时不生成管道
        if (!GameManager.Instance._gameStarted) return;

        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            SpawnPipe();
            _timer = 0f; // 重置计时器
        }
    }

    private void SpawnPipe()
    {
        float randomHeight = Random.Range(-_heightRange, _heightRange);
        Vector3 spawnPos = transform.position + new Vector3(0, randomHeight, 0);
        Instantiate(_pipePrefab, spawnPos, Quaternion.identity);
    }
}
