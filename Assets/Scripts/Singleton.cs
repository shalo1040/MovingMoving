using UnityEngine;

public class Singleton
{
    private static Singleton instance = null;

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
    public int sceneNumber = 1;
    //Main scene
    public bool panel = true; // 사용자가 걸음수를 지정했을땐 패널이 생성되지 않음
    public int range; // 다른 씬이나 다른 스크립트에서 변수 선언을 안해도 쓸 수 있음, 목표걸음
    public int step; // 현재 걸음수
    public bool isWalking = false;//걷는지 안걷는지를 체크

    public int Monster = 0; //ar 화면에서 나올 몬스터를 결정하는 역할을 함

    public int exp = 100;     //사용자 경험치
    public int level = 1; //사용자 레벨
    public int userID = 2;
    public bool watchedLoading = false;
    public bool onBonusMonster = false;

    //AR scene
    public float fullHP = 100;  //사용자 레벨에 따른 전체 hp
    public float userHP = 100;  //사용자 hp
    public bool onItem = false; //사용자가 아이템 사용하고 있는지 여부
    public Vector3 target;         //사용자 타겟 방향

    public bool done = false;       //게임 종료 여부
    public float monsterHP = 100; //몬스터 hp
    public float damage = 50f;      //10f
    public float distance;      //사용자와 몬스터 사이의 거리

    public string marble = "lv1";
    public bool bonusmonster = false;
    public int monsternumber = 20; //현재 어떤 몬스터가 나타났는지를 앎

    public bool sawTutorial = false;

    public bool monster0 = false;
    public bool monster1 = false;
    public bool monster2 = false;
    public bool monster3 = false;
    public bool monster4 = false;

    public bool monster5 = false;
    public bool monster6 = false;
    public bool monster7 = false;
    public bool monster8 = false;
    public bool monster9 = false;
    public bool monster10 = false;
    public bool monster11 = false;
    public bool monster12 = false;
    public bool monster13 = false;
    public bool monster14 = false;
    public bool monster15 = false;

    public int door = 0;

    public bool isDirUp = true;
    public float changedAmount;

}