/*
 * 사용자의 화면 터치를 매 프레임마다 감지하고
 * 구슬 혹은 아이템을 클릭했다면
 * 해당 구슬 또는 아이템을 얻었다는 창을 보여준다.
 * 
 * 화면의 상단에서 오브젝트를 클릭하면 더 걸으라는 메시지를 2초 동안 띄운다.
 * 구슬 삭제하기 전에 사용자에게 구슬을 지급한다.
 * 
 * 인벤토리 창 업데이트 및 활성화(line 207~)
 */

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectInteractions : MonoBehaviour
{
    private GameObject popup, current_marble, current_item;
    private Text title, info, num1, num2, num3, n1, n2;
    private Image image;
    private bool isMarble;                  //클릭한 오브젝트가 구슬인지 아이템인지 정보 저장
    private GameObject monster01, monster02, monster03, monster04, monster05;
    private Button closeBtn;


    private GameObject toast;
    private Text text;

    private Animator anim;
    private GameObject obj;

    public GameObject inventory;
    public GameObject monsterdictionary;
    private Text marble1, marble2, marble3, potion, shield;

    private void Awake()
    {
        popup = GameObject.Find("Canvas/ObjectPopUpView");
        //image = popup.transform.GetChild(0).gameObject.GetComponent<Image>();
        image = GameObject.Find("Canvas/ObjectPopUpView/earnedObjectImg").GetComponent<Image>();       //획득 오브젝트 이미지
        info = GameObject.Find("Canvas/ObjectPopUpView/infoTxt").GetComponent<Text>();                 //획득 문구
        closeBtn = GameObject.Find("Canvas/ObjectPopUpView/closeBtn").GetComponent<Button>();

        toast = GameObject.Find("Canvas/Toast");
        text = GameObject.Find("Canvas/Toast/toastMsg").GetComponent<Text>();

        //inventory = GameObject.Find("Canvas/InventoryPopUpView");
        //monsterdictionary = GameObject.Find("MonsterDictionary");

        marble1 = GameObject.Find("marbleCount1").GetComponent<Text>();
        marble2 = GameObject.Find("marbleCount2").GetComponent<Text>();
        marble3 = GameObject.Find("marbleCount3").GetComponent<Text>();

        potion = GameObject.Find("potionCount").GetComponent<Text>();
        shield = GameObject.Find("shieldCount").GetComponent<Text>();

        closeBtn.onClick.AddListener(()=>ClosePopup(popup));
        
        inventory.SetActive(false);
        monsterdictionary.SetActive(false);
    }

    void Start()
    {
        popup.SetActive(false);
        toast.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began)         //사용자 터치 감지
        {
            //Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))                   //오브젝트 터치 감지
            {
                if (Input.mousePosition.y >= (Screen.height * 0.4) && Input.mousePosition.y <= (Screen.height * 0.5)/* || Input.GetTouch(0).position.y >= (Screen.height * 0.4))*/ && !raycastHit.collider.CompareTag("doorCollider")) {    //사용자가 화면의 1/2 위에서 터치할 때 동작
                    StartCoroutine(ShowToast("조금만 더 걸어보세요", 2.5f));    //2.5초 동안 사용자에게 더 걸으라는 메시지를 띄운다
                    return;
                }
                if (raycastHit.collider.CompareTag("marble"))           //구슬 터치
                {
                    obj = raycastHit.collider.gameObject;
                    anim = obj.GetComponent<Animator>();
                    StartCoroutine(GetMarble());
                    Debug.Log("marble");
                }
                else if (raycastHit.collider.CompareTag("item"))         //아이템 터치
                {
                    obj = raycastHit.collider.gameObject;
                    anim = obj.GetComponent<Animator>();
                    StartCoroutine(GetItem());
                    Debug.Log("item");
                }
                else if (raycastHit.collider.CompareTag("monster")) // 몬스터 터치했을 시
                {
                    Singleton.Instance.Monster = 1;
                    SceneManager.LoadScene("Scene01_MonsterAR");//씬 전환
                }
            }
        }
    }

    void SetPopUpView(string tag, string str, string name, Sprite img, string color)
    {
        if (tag == "marble")                                                         //구슬 수정 창
        {
            info.text = "레벨 " + str + " 구슬을 얻었습니다!";
            StartCoroutine(IncMarbleCount(str));
        }
        else
        {
            if (str == "비타민")
            {
                info.text = str + "을 얻었습니다!";
                StartCoroutine(IncItemCount("potion"));
            }
            else
            {
                info.text = str + "를 얻었습니다!";
                StartCoroutine(IncItemCount("shield"));
            }
        }

        image.sprite = img;
        
        toast.SetActive(false);
        popup.SetActive(true);
    }
    
    IEnumerator ShowToast(string msg, float duration)       //토스트 메시지
    {
        text.text = msg;
        toast.SetActive(true);

        float count = 0;
        while (count < duration)            //duration초 동안 메시지 보여줌
        {
            count += Time.deltaTime;
            yield return null;
        }
        
        toast.SetActive(false);
    }

    IEnumerator GetMarble()
    {
        Debug.Log("setActive");
        anim.SetTrigger("Active");  //애니메이션 재생

        yield return new WaitForSeconds(3);     //3초 기다리기
        
        switch(GetRandomValue())
        {
            case 1:
                SetPopUpView("marble", "1", "user", Resources.Load<Sprite>("Images/Level1"), "red");
                break;
            case 2:
                SetPopUpView("marble", "2", "user", Resources.Load<Sprite>("Images/Level2"), "green");
                break;
            case 3:
                SetPopUpView("marble", "3", "user", Resources.Load<Sprite>("Images/Level3"), "blue");
                break;
            default:
                SetPopUpView("marble", "1", "user", Resources.Load<Sprite>("Images/Level1"), "red");
                break;
        }
        Destroy(obj);            //오브젝트 삭제
    }

    public int GetRandomValue()            //랜덤 레벨 정하기(나올 확률: Lv1 > Lv2 > Lv3)
    {
        float rand = Random.value;
        if (rand <= .5f) return 1;
        else if (rand <= .8f) return 2;
        else return 3;
    }

    IEnumerator GetItem()
    {
        anim.SetTrigger("Active");  //애니메이션 재생

        yield return new WaitForSeconds(3);     //3초 기다리기

        float rand = Random.value;

        if(rand <= .5f)
            SetPopUpView("item", "비타민", "user", Resources.Load<Sprite>("Images/vitamin"), "");
        else
            SetPopUpView("item", "쉴드", "user", Resources.Load<Sprite>("Images/shield"), "");

        Destroy(obj);            //오브젝트 삭제
    }

    IEnumerator IncMarbleCount(string level)
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID.ToString());
        wwwForm.AddField("marble", "lv"+level);

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/marbles_increase.php", wwwForm);

        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        string t = www.downloadHandler.text;
        Debug.Log("IncMarbleCount" + t);
    }

    IEnumerator IncItemCount(string item)
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID.ToString());
        wwwForm.AddField("item", item);

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/items_increase.php", wwwForm);

        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        string t = www.downloadHandler.text;
        Debug.Log("IncItemCount" + t);
    }

    IEnumerator GetMarbleCount()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/marbles_retrieve.php", wwwForm))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            string t = www.downloadHandler.text;
            string[] value = t.Split('*');
            Debug.Log(t);

            yield return marble1.text = value[0];
            yield return marble2.text = value[1];
            yield return marble3.text = value[2];
        }
    }

    IEnumerator GetItemCount()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/items_retrieve.php", wwwForm))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            string t = www.downloadHandler.text;
            string[] value = t.Split('*');

            Debug.Log("아이템" + t);
            yield return potion.text = value[0];
            yield return shield.text = value[1];
        }
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);

        StartCoroutine(GetMarbleCount());
        StartCoroutine(GetItemCount());
        Debug.Log("open");
    }

    public void OpenMonsterDictionary()
    {
        monsterdictionary.SetActive(true);
    }

    void ClosePopup(GameObject view)
    {
        view.SetActive(false);
    }
}