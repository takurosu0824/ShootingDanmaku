using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoShoot : MonoBehaviour
{
    private float bulletSpeed = 1f; //’e‚Ì‘¬“x
    private float shootRote = 0.3f; //”­Ë‚ÌŠÔ
    private float spiralAngle = 30f; //‰QŠª‚Ì‘¬“x

    private float timeSinceLastShoot = 0f;
    private float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShoot += Time.deltaTime;
        if (timeSinceLastShoot > shootRote)
        {
            TornadoBulletShoot();
            timeSinceLastShoot = 0f;
        }
    }

    private void TornadoBulletShoot()
    {
        //’e‚ğæ“¾
        GameObject bullet = BulletPool.Instance.GetEnemyPooledObject();

        //’e‚ÌˆÊ’u‚ğ”­ËˆÊ’u‚Éİ’è
        bullet.transform.position = transform.position;

        //‚½‚Ü‚É‘¬“x‚ğ—^‚¦‚é
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad),
            Mathf.Sin(currentAngle * Mathf.Deg2Rad));

        bullet.SetActive(true);
        if(rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        // Ÿ‚Ì’e‚É‘Î‚µ‚ÄŠp“x‚ğ•ÏX
        currentAngle += spiralAngle;

    }
}
