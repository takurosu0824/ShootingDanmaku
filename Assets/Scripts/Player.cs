using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// �萔
    /// </summary>

    const float UP_MOVE_LIMIT = 4.8f;
    const float DOWN_MOVE_LIMIT = -4.8f;
    const float RIGHT_MOVE_LIMIT = 2.6f;
    const float LEFT_MOVE_LIMIT = -2.6f;
    [SerializeField] private float SHOT_TIME = 0.1f;

    /// <summary>
    /// �ϐ�
    /// </summary>

    [SerializeField] private float speed = 2.0f;

    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 15f;

    //���ˎ���
    private float shotTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        shotTime = SHOT_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAction();
    }

    void PlayerAction()
    {
        PlayerMove();

        if(ShotTimer())
        {
            Fire();
        }
    }

    //���ˎ���
    bool ShotTimer()
    {
        bool shotFlag = false;

        shotTime -= Time.deltaTime;

        if(shotTime <= 0)
        {
            shotTime = SHOT_TIME;
            shotFlag = true;
        }

        return shotFlag;
    }

    void Fire()
    {
        GameObject bullet = BulletPool.Instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, bulletSpeed);
        }
    }

    //�v���C���[�̈ړ�
    void PlayerMove()
    {
        //��
        if(this.transform.position.y < UP_MOVE_LIMIT)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }

        //��
        if (this.transform.position.y > DOWN_MOVE_LIMIT)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }

        //�E
        if (this.transform.position.x < RIGHT_MOVE_LIMIT)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }

        //��
        if (this.transform.position.x > LEFT_MOVE_LIMIT)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }

    }
}
