using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // ȷ��ֻ����Ҵ����Ʒ�
        {
            GameManager.Instance.AddScore();
        }
    }
}
