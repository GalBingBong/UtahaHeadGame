using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameObject player; // �÷��̾��� Transform
    public float speed = 5f; // ������ �̵� �ӵ�
    public int Health;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        // �÷��̾��� ��ġ�� ���ϴ� ���� ���� ���
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // ������ �÷��̾� �������� �̵�
        transform.position += direction * speed * Time.deltaTime;

        if (Health <= 0 || !GameManager.instance.gameLive)
        {
            Destroy(gameObject);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) 
        {
            AudioManger.instance.PlaySfx(AudioManger.Sfx.Hit);
            Health -= 1;
            GameManager.instance.Point += 10;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            GameManager.instance.StopGame();
        }
    }
}
