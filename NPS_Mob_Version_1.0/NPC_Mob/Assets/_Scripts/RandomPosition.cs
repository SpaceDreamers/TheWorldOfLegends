using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPosition : MonoBehaviour
{

    public Transform MobPos;    // Позиця моба, відносно якої буде здійснюватися генерування точки
    public float MaxTime;       // Максимальний час,через який генерується точка
    public float MaxDistance;   // Максимальна дистанція, на якій може згенеруватися точка
    private float randPlusTime; // Час, через який генерується точка
    private float nowTime;      // Час, який пройшов від попередньої генерації точки


    void Start()
    {
        randPlusTime = Random.Range(MaxTime / 5, MaxTime);
        nowTime = 0;
        MaxDistance /= 2;
    }


    void Update()
    {

        if (nowTime < randPlusTime)
            
        {
            nowTime += Time.deltaTime;
        }
        else
        {
            nowTime = 0;
            transform.position = new Vector3(MobPos.transform.position.x + Random.Range(-MaxDistance, MaxDistance),
                transform.position.y, MobPos.transform.position.z + Random.Range(-MaxDistance, MaxDistance));
            randPlusTime = Random.Range(MaxTime / 10, MaxTime);
        }


    }
}
