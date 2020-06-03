/*
 * 사용자의 현재 걸음 수값이 변동함에 따라 구슬/아이템/몬스터가 화면에 나타난다.
 * 구슬: 40 걸음
 * 아이템: 85 걸음
 * 몬스터: 100 걸음
 * 문: 500걸음
 */
using UnityEngine;
using System.Linq;

public class GenerateAndMoveObjects : MonoBehaviour
{
    private int currentSteps, marbleSteps, itemSteps, monsterSteps , doorSteps;
    private int newMarbleStep, newItemStep, newMonsterStep,newDoorStep;
    private int random;
    private float randomX;
    private Vector3 pos;
    private bool isObjExist;

    private int marbleLimit = 40;                            //구슬 기준 걸음 수 10
    private int itemLimit = 70; //35
    private int monsterLimit = 138;//25
    private int doorLimit = 49;

    public GameObject doorPrefab;

    public GameObject[] marblePrefabs;                 //구슬 오브젝트
    public GameObject[] itemPrefabs;
    public GameObject[] monsterPrefabs;

    private GameObject[] marble;
    private GameObject[] item;
    private GameObject[] monster;
    private GameObject[] objects;
    private GameObject[] door;


    public GameObject target;
    Vector3 targetPos;
    
    float rotateSpeed = 2f;

    private void Start()
    {
        targetPos = target.transform.position;
    }
    void Update()
    {
        currentSteps = Singleton.Instance.step;     //현재 걸음수

        marbleSteps = currentSteps % marbleLimit;
        itemSteps = currentSteps % itemLimit;
        monsterSteps = currentSteps % monsterLimit;
        doorSteps = currentSteps % doorLimit;


        if (currentSteps > 0 && (newMarbleStep != currentSteps) && marbleSteps == 0)    //구슬 생성 조건
        {
            newMarbleStep = currentSteps;
            random = Random.Range(0, marblePrefabs.Length-1);           //구슬 종류 뽑고
            Instantiate(marblePrefabs[random], RandomPos(), Quaternion.identity);       //씬에 구슬 생성
            OnClick1();    //진동으로 오브젝트 생성 알림
        }

        if (currentSteps > 0 && (newItemStep != currentSteps) && itemSteps == 0)         //아이템 생성 조건
        {
            newItemStep = currentSteps;
            random = Random.Range(0, itemPrefabs.Length-1);
            Instantiate(itemPrefabs[random], RandomPos(), Quaternion.identity);
            OnClick1();    //진동으로 오브젝트 생성 알림
        }

        if (currentSteps > 0 && (newMonsterStep != currentSteps) && monsterSteps == 0)      //몬스터 생성 조건
        {
            newMonsterStep = currentSteps;
            random = Random.Range(0, monsterPrefabs.Length-1);
            Instantiate(monsterPrefabs[random], RandomPos(), Quaternion.identity);
            OnClick2();    //진동으로 오브젝트 생성 알림
        }
        if (currentSteps > 0 && (newDoorStep != currentSteps) && doorSteps == 0) //문 생성 조건
        {
            if(Singleton.Instance.door != 4)
            {
                newDoorStep = currentSteps;
                Instantiate(doorPrefab, new Vector3(0f, -.1f, -0.625f), Quaternion.identity);
                OnClick3();
            }         
        }
    }

    private void FixedUpdate()
    {
        marble = GameObject.FindGameObjectsWithTag("marble");
        item = GameObject.FindGameObjectsWithTag("item");
        monster = GameObject.FindGameObjectsWithTag("monster");
        door = GameObject.FindGameObjectsWithTag("door");
        
        objects = marble.Concat(item.Concat(monster.Concat(door).ToArray()).ToArray()).ToArray();

        if (Singleton.Instance.isWalking == true)
        {
            foreach (GameObject o in objects)
            {
                o.transform.RotateAround(targetPos, Vector3.left, rotateSpeed * Time.deltaTime);        //이동
                o.transform.rotation = Quaternion.Euler(0, 180 ,0);
            }
        }
    }

    Vector3 RandomPos()                                 //임의의 위치 잡는다
    {
        randomX = Random.Range(-0.05f, 0.06f);
        pos = new Vector3(randomX, -0.3f, -0.625f);
        return pos;
    }

    public void OnClick1() //아이템 나올 시 진동
    {
        Vibration.Vibrate((long)200);
    }

    public void OnClick2() // 몬스터 나올 시 진동
    {
        long[] pattern = new long[4];
        pattern[0] = 500;//0.5초 쉬기
        pattern[1] = 500; //0.5초울리기
        pattern[2] = 500;
        pattern[3] = 500;

        Vibration.Vibrate(pattern, -1);//반복 해제
    }

    public void OnClick3() // 문 나올 시 진동
    {
        long[] pattern = new long[4];
        pattern[0] = 500;
        pattern[1] = 2000;
        pattern[2] = 500;
        pattern[3] = 2000;

        Vibration.Vibrate(pattern, -1);//반복 해제
    }
}