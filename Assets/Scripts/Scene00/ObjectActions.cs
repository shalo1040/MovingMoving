/*
 * 사용자의 화면 터치를 매 프레임마다 감지하고
 * 구슬 혹은 아이템을 클릭했다면
 * 해당 구슬 또는 아이템을 얻었다는 창을 보여준다.
 * 
 * 화면의 상단에서 오브젝트를 클릭하면 더 걸으라는 메시지를 2초 동안 띄운다.
 * 구슬 삭제하기 전에 사용자에게 구슬을 지급한다.
 */
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectActions : MonoBehaviour
{
    private GameObject popup, current_marble, current_item;
    private Text title, info, num1, num2, num3, n1, n2;
    private Image image;
    private bool isMarble;                  //클릭한 오브젝트가 구슬인지 아이템인지 정보 저장
    private GameObject monster01, monster02, monster03, monster04, monster05;

    private Image toastBackground;
    private Text text;

    private void Awake()
    {
        popup = GameObject.Find("Canvas/ObjectPopUpView");

        //title = GameObject.Find("Canvas/ObjectPopUpView/objectTitle").GetComponent<Text>();            //획득 알림 텍스트
        image = GameObject.Find("Canvas/ObjectPopUpView/earnedObjectImg").GetComponent<Image>();       //획득 오브젝트 이미지
        info = GameObject.Find("Canvas/ObjectPopUpView/currentInfo").GetComponent<Text>();             //사용자 이름(인벤토리 현황)
        
        //toastBackground = GameObject.Find("toastBackground").GetComponent<Image>();
        //text = GameObject.Find("toastMsg").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
        //current_marble.SetActive(false);
        //current_item.SetActive(false);

        /*toastBackground.enabled = false;
        text.enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)         //사용자 터치 감지, 창이 열려있지 않을 때만 실행
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))                   //오브젝트 터치 감지
            {
                if (raycastHit.collider.CompareTag("marble"))           //구슬 터치
                {
                    isMarble = true;

                    /*if (Input.GetTouch(0).position.y >= (Screen.height * 0.8))    //사용자가 화면의 4/5 아래 위치에서 터치할 때 동작
                    {
                        StartCoroutine(ShowToast("조금만 더 걸어보세요", 2.5f));    //2.5초 동안 사용자에게 더 걸으라는 메시지를 띄운다
                    }*/
                    //else
                    //{
                        switch (raycastHit.collider.gameObject.name)
                        {
                            case "itembox_blue(Clone)":
                                SetObject("marble", "파란", "user", Resources.Load<Sprite>("Images/marblebox_blue"), "marble01");      //값 변경
                                break;
                            case "itembox_green(Clone)":
                                SetObject("marble", "초록", "user", Resources.Load<Sprite>("Images/marblebox_green"), "marble02");
                                break;
                            case "itembox_red(Clone)":
                                SetObject("marble", "빨간", "user", Resources.Load<Sprite>("Images/marblebox_red"), "marble03");
                                break;
                            default:
                                break;
                        }

                        //toastBackground.enabled = false;                        //아이템 창 나올 땐 토스트 메시지 안나오게 함
                        //text.enabled = false;

                        //popup.SetActive(true);
                        //current_marble.SetActive(true);
                        Destroy(raycastHit.collider.gameObject);            //오브젝트 삭제
                    //}
                }
                else if (raycastHit.collider.CompareTag("item"))         //아이템 터치
                {
                    isMarble = false;

                    /*if (Input.GetTouch(0).position.y >= (Screen.height * 0.8))    //사용자가 화면의 4/5 아래 위치에서 터치할 때 동작
                    {
                        StartCoroutine(ShowToast("조금만 더 걸어보세요", 2.5f));    //2.5초 동안 사용자에게 더 걸으라는 메시지를 띄운다
                    }
                    else
                    {*/
                        switch (raycastHit.collider.gameObject.name)
                        {
                            case "itembox(Clone)":
                                SetObject("", "물약", "user", Resources.Load<Sprite>("Images/marblebox_blue"), "item01");  //값 변경
                                break;
                            /*case "item02(Clone)":
                                SetObject("", "쉴드", "user", Resources.Load<Sprite>("Images/red"), "item02");
                                break;*/
                            default:
                                break;
                        }

                        //toastBackground.enabled = false;                        //아이템 창 나올 땐 토스트 메시지 안나오게 함
                        //text.enabled = false;

                        popup.SetActive(true);
                        //current_item.SetActive(true);
                        Destroy(raycastHit.collider.gameObject);              //오브젝트 삭제
                    //}
                }

                else if(raycastHit.collider.CompareTag("monster")) // 몬스터 터치했을 시
                {
                    isMarble = false;

                    switch (raycastHit.collider.gameObject.name)
                        {
                            case "monster01(Clone)":
                                Singleton.Instance.Monster = 1;
                                SceneManager.LoadScene("Scene01_MonsterAR");//씬 전환
                                break;
                            case "monster02(Clone)":
                                Singleton.Instance.Monster = 2;
                                SceneManager.LoadScene("Scene01_MonsterAR");//씬 전환
                                break;
                            case "monster03(Clone)":
                                Singleton.Instance.Monster = 3;
                                SceneManager.LoadScene("Scene01_MonsterAR");//씬 전환
                                break;
                            case "monster04(Clone)":
                                Singleton.Instance.Monster = 4;
                                SceneManager.LoadScene("Scene01_MonsterAR");//씬 전환
                                break;
                            case "monster05(Clone)":
                                Singleton.Instance.Monster = 5;
                                SceneManager.LoadScene("Scene01_MonsterAR");//씬 전환
                                break;
                            default:
                                break;
                        }

                }
            }
        }
    }

    void SetObject(string tag, string str, string name, Sprite img, string obj)     
    {
        if(tag == "marble")                                                         //구슬 수정 창
        {
            info.text = str + "구슬을 얻었습니다!";
            image.sprite = img;
            StartCoroutine(GetMarbleCount(obj));                //받은 구슬 수++ && 구슬 정보 가져옴
        }
        else
        {
            if (str == "물약") { info.text = str + "을 얻었습니다!"; }
            else { info.text = str + "를 얻었습니다!"; }
            
            image.sprite = img;
            StartCoroutine(GetItemCount(obj));                   //받은 아이템 수++ && 아이템 정보 가져옴
        }
        popup.SetActive(true);
    }

    IEnumerator UpdateMarbleCount(string obj)
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", "1");
        wwwForm.AddField("object", obj);

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodori/marbles_update.php", wwwForm);
        
        yield return www.SendWebRequest();
    }

    IEnumerator UpdateItemCount(string obj)
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", "1");
        wwwForm.AddField("object", obj);

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodori/items_update.php", wwwForm);
        
        yield return www.SendWebRequest();
    }

    IEnumerator GetMarbleCount(string obj)
    {
        yield return StartCoroutine(UpdateMarbleCount(obj));

        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", "1");

        using (UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodori/marbles_retrieve.php", wwwForm))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            string t = www.downloadHandler.text;
            string[] value = t.Split('*');

            yield return num1.text = value[0] + " 개";
            yield return num2.text = value[1] + " 개";
            yield return num3.text = value[2] + " 개";
        }
    }

    IEnumerator GetItemCount(string obj)
    {
        yield return StartCoroutine(UpdateItemCount(obj));

        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", "1");
        using (UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodori/items_retrieve.php", wwwForm))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            string t = www.downloadHandler.text;
            string[] value = t.Split('*');

            yield return n1.text = value[0] + " 개";
            yield return n2.text = value[1] + " 개";
        }


    }

    public void OnClosedClicked()           //확인 버튼 클릭했을 때, 구슬인지 아이템인지 확인하고 해당 창 닫기
    {   
        popup.SetActive(false);
    }
    
    IEnumerator ShowToast(string msg, float duration)       //토스트 메시지
    {
        text.text = msg;
        text.enabled = true;
        toastBackground.enabled = true;
        Color background = new Color(toastBackground.color.r, toastBackground.color.g, toastBackground.color.b);

        yield return fadeInAndOut(text.color, background, true);      //0.5초 동안 페이드인

        float count = 0;
        while (count < duration)            //duration초 동안 메시지 보여줌
        {
            count += Time.deltaTime;
            yield return null;
        }

        yield return fadeInAndOut(text.color, background, false);     //0.5초 동안 페이드아웃

        text.enabled = false;
        toastBackground.enabled = false;
    }

    IEnumerator fadeInAndOut(Color text, Color background, bool fadeIn)        //페이드인 페이드아웃 효과
    {
        if(fadeIn)
        {
            for (float i = 0f; i <= 1; i+=0.3f)
            {
                text = new Color(1, 1, 1, i);
                background = new Color(background.r, background.g, background.b, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 1; i >= 0f; i -= 0.3f)
            {
                text = new Color(1, 1, 1, i);
                background = new Color(background.r, background.g, background.b, i);
                yield return null;
            }
        }
    }
}