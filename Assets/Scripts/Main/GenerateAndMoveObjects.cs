/*
 * 사용자의 현재 걸음 수값이 변동함에 따라 구슬/아이템/몬스터가 화면에 나타난다.
 * 구슬: 40 걸음
 * 아이템: 85 걸음
 * 몬스터: 100 걸음
 */
using UnityEngine;
using System.Linq;

public class GenerateAndMoveObjects : MonoBehaviour
{
    private int currentSteps, marbleSteps, itemSteps, monsterSteps;
    private int newMarbleStep, newItemStep, newMonsterStep = -1;
    private int random;
    private float randomX;
    private Vector3 pos;
    private bool isObjExist;

    private int marbleLimit = 10;                            //구슬 기준 걸음 수
    private int itemLimit = 35;
    private int monsterLimit = 25;

    public GameObject[] marblePrefabs;                 //구슬 오브젝트
    public GameObject[] itemPrefabs;
    public GameObject[] monsterPrefabs;

    private GameObject[] marble;
    private GameObject[] item;
    private GameObject[] monster;
    private GameObject[] objects;
   
    public GameObject target;
    
    float rotateSpeed = 2f;
    
    
    void Update()
    {
        currentSteps = Singleton.Instance.step;     //현재 걸음수

        marbleSteps = currentSteps % marbleLimit;
        itemSteps = currentSteps % itemLimit;
        monsterSteps = currentSteps % monsterLimit;

        if (currentSteps > 0 && (newMarbleStep != currentSteps) && marbleSteps == 0)    //구슬 생성 조건
        {
            newMarbleStep = currentSteps;
            random = Random.Range(0, marblePrefabs.Length-1);           //구슬 종류 뽑고
            Instantiate(marblePrefabs[random], RandomPos(), Quaternion.identity);       //씬에 구슬 생성
            Handheld.Vibrate();    //진동으로 오브젝트 생성 알림
        }

        if (currentSteps > 0 && (newItemStep != currentSteps) && itemSteps == 0)         //아이템 생성 조건
        {
            newItemStep = currentSteps;
            random = Random.Range(0, itemPrefabs.Length-1);
            Instantiate(itemPrefabs[random], RandomPos(), Quaternion.identity);
            Handheld.Vibrate();    //진동으로 오브젝트 생성 알림
        }

        if (currentSteps > 0 && (newMonsterStep != currentSteps) && monsterSteps == 0)      //몬스터 생성 조건
        {
            newMonsterStep = currentSteps;
            random = Random.Range(0, monsterPrefabs.Length-1);
            Instantiate(monsterPrefabs[random], RandomPos(), Quaternion.identity);
            Handheld.Vibrate();    //진동으로 오브젝트 생성 알림
        }
    }

    private void FixedUpdate()
    {
        marble = GameObject.FindGameObjectsWithTag("marble");
        item = GameObject.FindGameObjectsWithTag("item");
        monster = GameObject.FindGameObjectsWithTag("monster");

        objects = marble.Concat(item.Concat(monster).ToArray()).ToArray();
        
        if (Singleton.Instance.isWalking == true)
        {
            foreach (GameObject o in objects)
                o.transform.RotateAround(target.transform.position, Vector3.left, rotateSpeed * Time.deltaTime);        //이동
        }
    }

    Vector3 RandomPos()                                 //임의의 위치 잡는다
    {
        randomX = Random.Range(-0.05f, 0.06f);
        pos = new Vector3(randomX, -0.43f, -0.673f);
        return pos;
    }
}