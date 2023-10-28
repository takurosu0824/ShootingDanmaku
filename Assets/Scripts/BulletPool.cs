using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    public GameObject pooledObject;
    public GameObject enemyPooledObject;

    private int pooledAmount = 30;
    private int enemyPooledAmount = 30;

    List<GameObject> pooledObjects;
    List<GameObject> enemyPooledObjects;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̒e�̐���
        CreateObjectPoole(pooledObject, pooledAmount, ref pooledObjects);

       //�G�l�~�[�̒e�̐���
        CreateObjectPoole(enemyPooledObject, enemyPooledAmount, ref enemyPooledObjects);

      /*  pooledObjects = new List<GameObject>();
        for (int i = 0;i<pooledAmount;i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
      */
    }

    //�I�u�W�F�N�g�v�[���̏����ݒ�
    private void CreateObjectPoole(GameObject prefab, int amount, ref List<GameObject> pooledObjs )
    {
        pooledObjs = new List<GameObject>();
        for (int i = 0; i< amount; i++)
        {
            GameObject obj = (GameObject)Instantiate(prefab);
            obj.SetActive(false);
            pooledObjs.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0;i<pooledObjects.Count;i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;
    }


    public GameObject GetEnemyPooledObject()
    {
        for (int i = 0; i < enemyPooledObjects.Count; i++)
        {
            if (!enemyPooledObjects[i].activeInHierarchy)
            {
                return enemyPooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(enemyPooledObject);
        obj.SetActive(false);
        enemyPooledObjects.Add(obj);

        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
