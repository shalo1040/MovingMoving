/*
씬00에서 터치한 몬스터를 씬01 ar 화면으로 불러오는 역할
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAR : MonoBehaviour
{
    private GameObject monster01, monster02, monster03, monster04, monster05;
    private Vector3 pos;

    public GameObject monster;

    [SerializeField]
    private GameObject[] monsterPrefabs;


    // Update is called once per frame
    void Update()
    {
        if (Singleton.Instance.Monster == 1)
        {
            monster = monster01;
        }

        else if (Singleton.Instance.Monster == 2)
        {
            monster = monster02;
        }

        else if (Singleton.Instance.Monster == 3)
        {
            monster = monster03;
        }

        else if (Singleton.Instance.Monster == 4)
        {
            monster = monster04;
        }

        else if (Singleton.Instance.Monster == 5)
        {
            monster = monster05;
        }

        SetMonster();
    }

    void SetMonster()
    {
        pos = new Vector3(0, -0.2884f, 1.0232f);
        Instantiate(monster, pos, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
    }
}
