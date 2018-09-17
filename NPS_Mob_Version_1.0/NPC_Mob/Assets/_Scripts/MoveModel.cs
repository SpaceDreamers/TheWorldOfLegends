using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ContrallerMove
{

    public class MoveModel : MonoBehaviour
    {


        public Transform target; // Обєкт, за яким буде рухатися персонаж
        public int distance;     // Дистанція до цілі, перейшовши яку персонаж зупиняється
        NavMeshAgent navMesh;    // Штучний інтелект

        private float timeToStop; // Завдяки цій змінній обєкт буде зупинятися не зразу як перейде дистанцію


        void Start()
        {
            timeToStop = 1;
            navMesh = GetComponent<NavMeshAgent>(); // Присвоюємо обєкту navMesh, NavMeshAgent обєкту, на якого кинутий скрипт
        }

        void Update()
        {
            // Чек дистанції для зупинки
            if (Vector3.Distance(target.transform.position, transform.position) < distance)
            {
                if (timeToStop < 0)
                {
                    navMesh.GetComponent<NavMeshAgent>().enabled = false; // Вимикаємо AI
                    gameObject.GetComponent<Animator>().Play("Stay");     // Включаємо анімацію Stay
                }
                else timeToStop -= Time.deltaTime;
            }
            else
            {
                navMesh.GetComponent<NavMeshAgent>().enabled = true;  // Вмикаэмо AI
                gameObject.GetComponent<Animator>().Play("Walk");     // Включаємо анімацію Walk
                navMesh.SetDestination(target.position);              // В якості цілі виберажмо позицію відповідного обєкту
                timeToStop = 2;

            }
        }
    }
}
