/*
    몬스터 랜덤값으로 출력하기
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    // private Vector3 MonsterPos;
    
    private int random;
    public GameObject[] levelOneMonsters;
    public GameObject[] levelTwoMonsters;
    public GameObject[] levelThreeMonsters;
    public GameObject[] bonusMonsters;
    public GameObject cube;
    private float x, y, z;

    void Start()
    {
        x = cube.transform.position.x;
        y = cube.transform.position.y;
        z = cube.transform.position.z;

        if(Singleton.Instance.bonusmonster == false)
        {
            switch (Singleton.Instance.level)
            {
                case 1:
                    Appear(levelOneMonsters);
                    break;
                case 2:
                    Appear(levelTwoMonsters);
                    break;
                case 3:
                    Appear(levelThreeMonsters);
                    break;
                default:
                    Appear(levelThreeMonsters);
                    break;
            }
        }

        else 
        {
            Appear(bonusMonsters);
            Singleton.Instance.onBonusMonster = false;
        }
    }
    
    public void Appear(GameObject[] monsterPrefabs)
    {  
        random = Random.Range(0, monsterPrefabs.Length);
        
        Instantiate(monsterPrefabs[random], new Vector3 (x, y, z), Quaternion.identity);//회전은 없으닌깐 기본값
        Debug.Log("몬스터는 " + random); 
        Singleton.Instance.monsternumber = random;
        Debug.Log("몬스터는 " + Singleton.Instance.monsternumber); 

        cube.SetActive(false);
        Singleton.Instance.bonusmonster = false;
    }
}
