using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetColor : MonoBehaviour
{
    //ÇªÇÍÇºÇÍ255Ç™è„å¿
    [SerializeField] private int R = 0;
    [SerializeField] private int G = 0;
    [SerializeField] private int B = 0;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color =new Color(R, G, B, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
