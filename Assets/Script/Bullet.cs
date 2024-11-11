using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int Damage;

    public Rigidbody2D rb;
    //public int bulletSpeed = 10;

    private void Awake()
    {
       
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        StartCoroutine(DestroyBulllet());
    }

    IEnumerator DestroyBulllet()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
