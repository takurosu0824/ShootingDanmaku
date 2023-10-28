using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //敵が表示できる範囲
    const float DESTROY_TOP_LINE = 10.0f;
    const float DESTROY_RIGHT_LINE = 8.0f;
    const float DESTROY_LEFT_LINE = -8.0f;
    const float DESTROY_BOTTOM_LINE = -10.0f;

   

    private void DestroyEnemy()
    {
        if(this.transform.position.x > DESTROY_RIGHT_LINE ||
           this.transform.position.x < DESTROY_LEFT_LINE ||
           this.transform.position.y > DESTROY_TOP_LINE ||
           this.transform.position.y > DESTROY_BOTTOM_LINE )
        {
            Destroy(this.gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public virtual void Update()
    {
        DestroyEnemy();
    }

    public struct EnemyGenInfo
    {
        public MoveDirectionType enemyDirectionType; // Enemyの方向
        public float firstSpeed; // スピードを1種類のみ設定する場合に利用
        public float secondSpeed; //スピードを2種類設定する場合に利用(firstSpeedはx軸、secondSpeedはy軸)
        public int shotPattern; // 攻撃パターン : 配列に設定する番号を格納する
    }

    //methodをチェックする。-1 : エラー、0 : 引数1つ, 1 : 引数2つ、2 : 引数3つ
    public int CheckMethod(EnemyGenInfo enemyGenInfo)
    {
        if(enemyGenInfo.enemyDirectionType == MoveDirectionType.NO_MOVE)
        {
            //エラー
            Debug.Log("方向を指定してください");
            return -1;
        }

        int methodNO = 0;

        if (enemyGenInfo.firstSpeed != 0)
        {
            methodNO++;
            if(enemyGenInfo.secondSpeed != 0)
            {
                methodNO++;
            }
        }

        return methodNO;
    }

    public enum MoveDirectionType
    {
        TOP,    //上方向
        RIGHT,  // 右方向
        BOTTOM,  //下方向
        LEFT,   //左方向
        TOP_RIGHT, //  右上方向
        BOTTOM_RIGHT,  //  右下方向
        TOP_LEFT,   //左上方向
        BOTTOM_LEFT,   //左下方向
        NO_MOVE,    //移動しない
    }

    private void Move(float xSpeed, float ySpeed)
    {
        transform.position += new Vector3(Time.deltaTime * xSpeed, Time.deltaTime * ySpeed, 0);
    }

    // MoveDirectionTypeにより進ませる方向(vector2)を返却する
    private Vector2 GetDirectionVector(MoveDirectionType directionType)
    {
        Vector2 direction = Vector2.zero;
        switch (directionType)
        {
            case MoveDirectionType.TOP:
                //上に移動
                direction = new Vector2(0, 1);
                break;
            case MoveDirectionType.RIGHT:
                //右に移動
                direction = new Vector2(1, 0);
                break;
            case MoveDirectionType.BOTTOM:
                //下に移動
                direction = new Vector2(0, -1);
                break;
            case MoveDirectionType.LEFT:
                //左に移動
                direction = new Vector2(-1, 0);
                break;
            case MoveDirectionType.TOP_RIGHT:
                //右上に移動
                direction = new Vector2(1, 1);
                break;
            case MoveDirectionType.BOTTOM_RIGHT:
                //右下に移動
                direction = new Vector2(1, -1);
                break;
            case MoveDirectionType.TOP_LEFT:
                //左上に移動
                direction = new Vector2(-1, 1);
                break;
            case MoveDirectionType.BOTTOM_LEFT:
                //左下に移動
                direction = new Vector2(-1, -1);
                break;
            case MoveDirectionType.NO_MOVE:
                //移動しないにに移動
                direction = Vector2.zero;
                break;
            default:
                Debug.Log("Error:MoveDirectionType定義値以外");
                break;
        }

        return direction;
    }

    public virtual void MoveDirection(MoveDirectionType moveDirectionType)
    {
        //引数のmoveDirectionTypeによる方向を取得
        Vector2 direction = GetDirectionVector(moveDirectionType);

        //移動
        Move(direction.x, direction.y);
    }

    //キャラクターに移動させる (スピードは、引数に指定した値になる)
    public virtual void MoveDirection(MoveDirectionType moveDirectionType, float speed)
    {
        //引数のmoveDirectionTypeによる方向を取得
        Vector2 direction = GetDirectionVector(moveDirectionType);

        //引数の値を絶対値にする
        float absSpeed = Mathf.Abs(speed);

        //移動
        Move(direction.x * absSpeed ,direction.y * absSpeed);
    }


    //キャラクターに移動させる(スピードは、x軸、y軸にそれぞれ指定できる)

    public virtual void MoveDirection(MoveDirectionType moveDirectionType, float xSpeed, float ySpeed)
    {
        //引数のmoveDirectionTypeによる方向を取得
        Vector2 direction = GetDirectionVector(moveDirectionType);

        //引数の値を絶対値にする
        float absXSpeed = Mathf.Abs(xSpeed);
        float absYSpeed = Mathf.Abs(ySpeed);

        //移動
        Move(direction.x * absXSpeed, direction.y * absYSpeed);
    }

}

