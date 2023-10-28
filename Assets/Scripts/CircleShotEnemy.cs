using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShotEnemy : EnemyMove
{
    private float ySpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public override void Update()
    {
        base.Update();
        base.MoveDirection(MoveDirectionType.Bottom);
    }
}
