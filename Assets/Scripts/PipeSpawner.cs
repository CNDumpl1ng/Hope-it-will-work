using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab; // �ܵ�Ԥ����
    [SerializeField] private float _spawnInterval = 2f; // �ܵ����ɼ��
    [SerializeField] private float _heightRange = 2f; // �ܵ�����߶ȷ�Χ

    private float _timer = 0f;

    private void Update()
    {
        // ��Ϸδ��ʼʱ�����ɹܵ�
        if (!GameManager.Instance._gameStarted) return;

        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            SpawnPipe();
            _timer = 0f; // ���ü�ʱ��
        }
    }

    private void SpawnPipe()
    {
        float randomHeight = Random.Range(-_heightRange, _heightRange);
        Vector3 spawnPos = transform.position + new Vector3(0, randomHeight, 0);
        Instantiate(_pipePrefab, spawnPos, Quaternion.identity);
    }
}
