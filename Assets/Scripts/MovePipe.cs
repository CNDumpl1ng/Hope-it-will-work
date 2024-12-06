using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;

    private void Update()
    {
        if (!GameManager.Instance._gameStarted) return; // 游戏未开始时不移动管道

        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
