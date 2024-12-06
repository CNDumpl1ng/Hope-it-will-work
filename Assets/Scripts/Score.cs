using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 确保只有玩家触发计分
        {
            GameManager.Instance.AddScore();
        }
    }
}
