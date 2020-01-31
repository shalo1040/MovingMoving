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

public class ObjectInteractions : MonoBehaviour
{
    private GameObject popup, current_marble, current_item;
    private Text title, info, num1, num2, num3, n1, n2;
    private Image image;
    private bool isMarble;                  //클릭한 오브젝트가 구슬인지 아이템인지 정보 저장
    private GameObject monster01, monster02, monster03, monster04, monster05;

    private Image toast;
    private Text text;

    private void Awake()
    {
        popup = GameObject.Find("Canvas/ObjectPopUpView");
        image = GameObject.Find("Canvas/ObjectPopUpView/earnedObjectImg").GetComponent<Image>();       //획득 오브젝트 이미지
        info = GameObject.Find("Canvas/ObjectPopUpView/infoTxt").GetComponent<Text>();                 //획득 문구


        toast = GameObject.Find("Canvas/Toast").GetComponent<Image>();
        text = GameObject.Find("Canvas/Toast/toastMsg").GetComponent<Text>();

        popup.SetActive(false);
        toast.enabled = false;
        text.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)         //사용자 터치 감지
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            
            if (Physics.Raycast(raycast, out raycastHit))                   //오브젝트 터치 감지
            {
                if (Input.GetTouch(0).position.y >= (Screen.height * 0.5))    //사용자가 화면의 1/2 위에서 터치할 때 동작
                    StartCoroutine(ShowToast("조금만 더 걸어보세요", 2.5f));    //2.5초 동안 사용자에게 더 걸으라는 메시지를 띄운다
                else if (raycastHit.collider.CompareTag("marble"))           //구슬 터치
                {
                    switch (raycastHit.collider.gameObject.name)
                    {
                        case "itembox(Clone)":
                            SetObject("marble", "초록", "user", Resources.Load<Sprite>("Images/marblebox_green"));      //test
                            break;
                        case "itembox_blue(Clone)":
                            SetObject("marble", "파란", "user", Resources.Load<Sprite>("Images/marblebox_blue"));      //값 변경
                            break;
                        case "itembox_green(Clone)":
                            SetObject("marble", "초록", "user", Resources.Load<Sprite>("Images/marblebox_green"));
                            break;
                        case "itembox_red(Clone)":
                            SetObject("marble", "빨간", "user", Resources.Load<Sprite>("Images/marblebox_red"));
                            break;
                        default:
                            break;
                    }
                    Destroy(raycastHit.collider.gameObject);            //오브젝트 삭제
                }
                else if (raycastHit.collider.CompareTag("item"))         //아이템 터치
                {
                    switch (raycastHit.collider.gameObject.name)
                    {
                        case "itembox(Clone)":
                            SetObject("", "물약", "user", Resources.Load<Sprite>("Images/marblebox_red"));  //값 변경
                            break;
                        /*case "item02(Clone)":
                            SetObject("", "쉴드", "user", Resources.Load<Sprite>("Images/red"));
                            break;*/
                        default:
                            break;
                    }
                    Destroy(raycastHit.collider.gameObject);              //오브젝트 삭제
                }
                else if (raycastHit.collider.CompareTag("monster")) // 몬스터 터치했을 시
                {
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

    void SetObject(string tag, string str, string name, Sprite img)
    {
        if (tag == "marble")                                                         //구슬 수정 창
            info.text = str + "구슬을 얻었습니다!";
        else
        {
            if (str == "물약") { info.text = str + "을 얻었습니다!"; }
            else { info.text = str + "를 얻었습니다!"; }
        }

        image.sprite = img;

        text.enabled = false;
        toast.enabled = false;

        popup.SetActive(true);
    }
    
    IEnumerator ShowToast(string msg, float duration)       //토스트 메시지
    {
        text.text = msg;
        text.enabled = true;
        toast.enabled = true;

        float count = 0;
        while (count < duration)            //duration초 동안 메시지 보여줌
        {
            count += Time.deltaTime;
            yield return null;
        }

        text.enabled = false;
        toast.enabled = false;
    }
}