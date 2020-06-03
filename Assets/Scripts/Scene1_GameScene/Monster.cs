// 몬스터의 공격 동작 코드 + 몬스터 HP

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Monster : MonoBehaviour
{
    public Material lv1;
    public Material lv2;
    public Material lv3;
    private Material mat;

    GameObject resultWindow_monster;
    Text resultTxt_monster;
    Button resultBtn_monster;
    Text result;

    GameObject cam;
    Animator anim;

    public GameObject weaponPrefab;
    public Sprite winImg;
    Image winResultImg;

    float timer = 10f;       //몬스터 공격 주기 시간 5초(레벨 따라 다름)

    enum MonsterState { Idle, Attacking, Attacked }
    int state = (int)MonsterState.Idle;             //몬스터 현재 상태

    public GameObject BarPrefab;//monster hp
    protected Image Bar;
    protected Image BarFilled;

    public GameObject hpText;

    string monsterName;
    float monsterHP = Singleton.Instance.monsterHP;

    bool isNewMonster;

    Scrollbar expBar;

    private void Awake()
    {
        cam = GameObject.Find("ARCamera");
        anim = gameObject.GetComponent<Animator>();

        resultWindow_monster = GameObject.Find("Canvas/Result Window");     //SetActive(false)는 Player에서
        resultBtn_monster = GameObject.Find("Canvas/Result Window/closeBtn").GetComponent<Button>();
        result = GameObject.Find("Canvas/Result Window/result").GetComponent<Text>();
        resultBtn_monster.onClick.AddListener(CloseBtnClicked);
        winResultImg = GameObject.Find("Result Window/Image").GetComponent<Image>();
    }
    private void Start()
    {
        Bar = Instantiate(BarPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        BarFilled = new List<Image>(Bar.GetComponentsInChildren<Image>()).Find(Image => Image != Bar);

        BarFilled.fillAmount = 1.0f;

        expBar = GameObject.Find("HPbar/HPBar").GetComponent<Scrollbar>();

        string name = gameObject.name.ToString();
        string[] monName = name.Split('(');
        monsterName = monName[0];
    }
    void Update()
    {
        transform.LookAt(cam.transform.position);

        if (Singleton.Instance.sawTutorial == true)
        {
            Timer();
            if (state == (int)MonsterState.Idle)
            {    //대기 상태일 때
                 //Idle animation
            }

            Bar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.5f, 0));

            Singleton.Instance.distance = transform.position.z - cam.transform.position.z;
        }
    }

    //timer 초마다 사용자 공격
    void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 10f;
            state = (int)MonsterState.Attacking;
            StartCoroutine(Attack());
        }
    }

    //사용자 공격
    IEnumerator Attack()
    {
        anim.SetTrigger("Attack");          //공격 애니메이션

        yield return new WaitForSeconds(2f);

        Instantiate(weaponPrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)      //Attacked
    {
        if (other.gameObject.CompareTag("marble"))
        {
            state = (int)MonsterState.Attacked;

            float damage;

            anim.SetTrigger("Hurt");        //공격 받았을 때의 애니메이션 실행

            mat = other.GetComponent<MeshRenderer>().material;

            //공격받은 구슬에 따라 다른 데미지 적용
            if (mat.name == "lv1marble (Instance)") damage = 10.0f;
            else if (mat.name == "lv2marble (Instance)") damage = 20.0f;
            else if (mat.name == "lv3marble (Instance)") damage = 40.0f;
            else damage = 10.0f;

            monsterAttacked(damage);
            Singleton.Instance.isDirUp = true;
            Singleton.Instance.changedAmount = (-damage);
            Vector3 position = Camera.main.ScreenToWorldPoint(Bar.transform.position);
            position.x = Random.Range(position.x - .1f, position.x + .1f);
            position.y += .1f;
            Instantiate(hpText, position, Quaternion.identity);

            Destroy(other.gameObject);

            state = (int)MonsterState.Idle;
        }
    }

    void monsterAttacked(float damage)
    {
        //몬스터 체력 바 감소
        if (monsterHP > damage)
        {
            monsterHP -= damage;
            BarFilled.fillAmount = monsterHP / 100;
        }
        else
        {          //사용자가 이김
            monsterHP = 0;
            BarFilled.fillAmount = 0.0f;
            Win();
        }
    }

    //사용자가 이겼을 때
    void Win()
    {
        Destroy(Bar);
        Singleton.Instance.done = true;     //Player.cs에 게임이 끝났음을 알려줌
        //Time.timeScale = 0;
        //경험치 증가
        Singleton.Instance.exp += 100;

        //도감 추가
        StartCoroutine(InsertMonster(monsterName));

        //구슬 추가
        ObjectInteractions obj = new ObjectInteractions();
        int marble1 = 0, marble2 = 0, marble3 = 0;
        int randomCount;
        switch (Singleton.Instance.level)
        {
            case 1:
                randomCount = 3;
                break;
            case 2:
                randomCount = 5;
                break;
            case 3:
                randomCount = 6;
                break;
            default:
                randomCount = 7;
                break;
        }
        for (int i = 0; i < randomCount; i++)     //구슬 n개 랜덤으로 뽑음
        {
            switch (obj.GetRandomValue())
            {
                case 1:
                    marble1++;
                    break;
                case 2:
                    marble2++;
                    break;
                case 3:
                    marble3++;
                    break;
            }
        }
        StartCoroutine(IncMarbleCount(marble1, marble2, marble3));

        winResultImg.sprite = winImg;
        winResultImg.rectTransform.localPosition = new Vector3(0, 247, 0);
        winResultImg.rectTransform.localScale = new Vector3(12.136f, 12.136f, 12.136f);

        result.rectTransform.localPosition = new Vector3(330f, 356f, 0f);

        result.text += "경험치 " + 100;
        if (marble1 != 0) result.text += "\n레벨1 구슬 " + marble1 + " 개";
        if (marble2 != 0) result.text += "\n레벨2 구슬 " + marble2 + " 개";
        if (marble3 != 0) result.text += "\n레벨3 구슬 " + marble3 + " 개";

        resultWindow_monster.SetActive(true);           //결과창
    }

    //메인씬으로 이동
    void CloseBtnClicked()
    {
        SceneManager.LoadScene("Scene00_Main");
    }
    
    IEnumerator IncMarbleCount(int lv1, int lv2, int lv3)
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID.ToString());
        wwwForm.AddField("marble1", lv1);
        wwwForm.AddField("marble2", lv2);
        wwwForm.AddField("marble3", lv3);

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/marbles_increase_gameResult.php", wwwForm);
        yield return www.SendWebRequest();
    }

    IEnumerator InsertMonster(string name)
    {
        string monster = "monster" + Singleton.Instance.monsternumber;
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID);
        wwwForm.AddField("monster", name);

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/monsters_checkAndInsert.php", wwwForm);
        yield return www.SendWebRequest();

        string t = www.downloadHandler.text;
        if (t == "false") isNewMonster = true;
        else isNewMonster = false;
    }
}