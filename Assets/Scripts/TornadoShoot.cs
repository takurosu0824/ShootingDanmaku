using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoShoot : MonoBehaviour
{
    private float bulletSpeed = 1f; //弾の速度
    private float shootRote = 0.3f; //発射の時間
    private float spiralAngle = 30f; //渦巻の速度

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
        //弾を取得
        GameObject bullet = BulletPool.Instance.GetEnemyPooledObject();

        //弾の位置を発射位置に設定
        bullet.transform.position = transform.position;

        //たまに速度を与える
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad),
            Mathf.Sin(currentAngle * Mathf.Deg2Rad));

        bullet.SetActive(true);
        if(rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        // 次の弾に対して角度を変更
        currentAngle += spiralAngle;

    }
}
