using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : EnemyShotPattern
{

    const float RIGHT_MOVE_LIMIT = 1.5f;
    const float LEFT_MOVE_LIMIT = -1.5f;

    private bool rightMoveFlag = false;
    private float bossMoveSpeed = 1.0f;

    private float shotChangeTime = 5.0f;
    public float currentTime = 0;
    public int currentShotIndex = 0;



    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rightMoveFlag = true;

        ActiveScriptByIndex(currentShotIndex);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        currentTime += Time.deltaTime;

        if (shotChangeTime <= currentTime)
        {
            UpdateScriptIndex();
            ActiveScriptByIndex(currentShotIndex);
            currentTime = 0;
        }
    }


    BossMove();

}

protected void UpdateScriptIndex()
{
    currentShotIndex = (currentShotIndex + 1) % ShotScriptList.Count;
}


private void BossMove()
    {

        if(transform.position.x > RIGHT_MOVE_LIMIT)
        {
            //RIGHT_MOVE_LIMIT���E�Ɉړ�������ArightMoveFlag��false�ɂ���
            rightMoveFlag = false;
        }
         else if (transform.position.x < LEFT_MOVE_LIMIT)
        {
            //LEFT_MOVE_LIMIT��荶�Ɉړ�������AleftMoveFlag��false�ɂ���
            rightMoveFlag = true;
        }
        else
        {
            //�������Ȃ�
        }

        //���E�Ɉړ�������
        
            if(rightMoveFlag )
            {
                base.MoveDirection(MoveDirectionType.RIGHT);
            }
            else
            {
                base.MoveDirection(MoveDirectionType.LEFT);
        }
        
    }


}
