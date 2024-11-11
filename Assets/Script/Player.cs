using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    private Camera Camera;

    [SerializeField]
    private GameObject Neck;
    [SerializeField]
    private Transform shootpoint;
    [SerializeField]
    private GameObject bulletPrefab;
    public GameObject particleEffect; // ÆÄÆ¼Å¬ ÀÌÆåÆ® ÇÁ¸®ÆÕ

    public int bulletSpeed = 10;

    [SerializeField]
    private bool canShoot;

    private void Awake()
    {
        canShoot = true;
        Camera = Camera.main;
        
    }
    private void Update()
    {
        Aim();
    }

    void Aim()
    {
        Vector2 mousPos = (Vector2)Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousPos - (Vector2)transform.position;

        Neck.transform.right = dir.normalized;
    }

    void OnAttack(InputValue value)
    {
        if (canShoot)
        {
            canShoot = false;
            AudioManger.instance.PlaySfx(AudioManger.Sfx.Shoot);

            Vector2 mousPos = (Vector2)Camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mousPos - (Vector2)transform.position;

            //Instantiate(particleEffect, shootpoint.position, shootpoint.rotation);


            Neck.transform.right = dir.normalized;

            Debug.Log("pew");
            GameObject bullet = Instantiate(bulletPrefab, shootpoint.position, shootpoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = dir * bulletSpeed;

            StartCoroutine(WaitSec());
        }


        IEnumerator WaitSec()
        {
            yield return new WaitForSeconds(0.2f);
            canShoot = true;
        }
    }

    
}
