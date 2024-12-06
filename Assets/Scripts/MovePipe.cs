using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;

    private void Update()
    {
        if (!GameManager.Instance._gameStarted) return; // ��Ϸδ��ʼʱ���ƶ��ܵ�

        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
