using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionEnemy : EnemyShotPattern
{
    private EnemyGenInfo enemyGenInfo_;

    void EnemyGenInfoInit()
    {
        enemyGenInfo_.enemyDirectionType = MoveDirectionType.NO_MOVE;
        enemyGenInfo_.firstSpeed = 0;
        enemyGenInfo_.secondSpeed = 0;
        enemyGenInfo_.shotPattern = ShotScriptList.Count;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
