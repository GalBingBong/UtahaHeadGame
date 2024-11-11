using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameObject player; // 플레이어의 Transform
    public float speed = 5f; // 괴물의 이동 속도
    public int Health;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        // 플레이어의 위치로 향하는 방향 벡터 계산
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // 괴물을 플레이어 방향으로 이동
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
