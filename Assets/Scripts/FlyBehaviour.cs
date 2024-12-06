using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0; // 禁用重力，直到游戏开始
    }

    private void Update()
    {
        if (!GameManager.Instance._gameStarted) return; // 游戏未开始时不处理输入

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.velocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance._gameStarted) return; // 游戏未开始时不处理旋转

        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }

    public void OnGameStart()
    {
        _rb.gravityScale = 0.65f; // 游戏开始时启用重力
    }
}
