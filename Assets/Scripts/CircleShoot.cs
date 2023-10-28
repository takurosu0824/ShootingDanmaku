using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShoot : MonoBehaviour
{
    private int numberObBullets = 12; //発射する玉の数
    private float bulletSpeed = 2.0f; //弾の速度
    private float shotCooldown = 2.0f; //発射のクールタイム
    private float lastShotTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastShotTime + shotCooldown)
        {
            CircleShootBullets();
            lastShotTime = Time.time;
        }
    }

    void CircleShootBullets()
    {
        for (int i = 0; i < numberObBullets; i++)
        {
            float angle = (360f / numberObBullets) * i;
            Vector3 direction = Quaternion.Euler(0, 0, angle) * transform.up;
            GameObject bullet = BulletPool.Instance.GetEnemyPooledObject();

            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.SetActive(true);
            if(rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }

        }
    }
}
