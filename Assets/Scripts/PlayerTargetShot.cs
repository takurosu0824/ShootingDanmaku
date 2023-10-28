using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetShot : MonoBehaviour
{
    private float bulletSpeed = 1f;//�e�̑��x
    private float shotCooldown = 1.5f;//���˂̃N�[���_�E������
    private float lastShotTime = 0;

    private Transform playerTransform; //�v���C���[�̈ʒu

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if(Time.time > lastShotTime + shotCooldown)
        {
            PlayerShootBullet();
            lastShotTime = Time.time;
        }
    }

    private void PlayerShootBullet()
    {
        //�e�̕������v���C���[�̕����ɐݒ�
        Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;

        //�e���擾
        GameObject bullet = BulletPool.Instance.GetEnemyPooledObject();

        //�e�̈ʒu�𔭎ˈʒu�ɐݒ�
        bullet.transform.position = transform.position;
        bullet.SetActive(true);

        //�e�ɑ��x��^����
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            rb.velocity = directionToPlayer * bulletSpeed; 
        }
    }
}
