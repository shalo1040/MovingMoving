/*
구슬 종류 바꾸기 + 구슬 날라가기
*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MarbleChange : MonoBehaviour
{
    private GameObject marble;
    public GameObject marblePrefab;
    public Material lv1,lv2,lv3;
    private Text lv1marblecount,lv2marblecount,lv3marblecount;
    private int intlv1marble,intlv2marble,intlv3marble;
    private GameObject toast;
    private Text text;
    private Button lv1btn,lv2btn,lv3btn;
    Vector3 dir;
    
    private void Awake() 
    {
        marble = GameObject.Find("marble");
        toast = GameObject.Find("Canvas/Toast");
        text = GameObject.Find("Canvas/Toast/ToastMsg").GetComponent<Text>();
        lv1marblecount = GameObject.Find("Canvas/marbleBtn1/lv1").GetComponent<Text>();
        lv2marblecount = GameObject.Find("Canvas/marbleBtn2/lv2").GetComponent<Text>();
        lv3marblecount = GameObject.Find("Canvas/marbleBtn3/lv3").GetComponent<Text>();
        lv1btn = GameObject.Find("Canvas/marbleBtn1").GetComponent<Button>();
        lv2btn = GameObject.Find("Canvas/marbleBtn2").GetComponent<Button>();
        lv3btn = GameObject.Find("Canvas/marbleBtn3").GetComponent<Button>();
    }
    void Start()
    {
        toast.SetActive(false);
        marble.SetActive(false);

    }

    public void Lv1()
    {
        marblePrefab.GetComponent<MeshRenderer>().material = lv1;
        Singleton.Instance.marble = "lv1";
        Debug.Log("lv1marble");
        StartCoroutine(Lv1Marble());
    }

    public void Lv2()
    {
        marblePrefab.GetComponent<MeshRenderer>().material = lv2;
        Singleton.Instance.marble = "lv2";
        Debug.Log("lv2marble");
        StartCoroutine(Lv2Marble());
    }

    public void Lv3()
    {
        marblePrefab.GetComponent<MeshRenderer>().material = lv3;
        Singleton.Instance.marble = "lv3";
        Debug.Log("lv3marble");
        StartCoroutine(Lv3Marble());
    }

    IEnumerator Lv1Marble()
    {
        int.TryParse(lv1marblecount.text, out intlv1marble);

        Vector3 lv1point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 lv1btnPos = new Vector2();

        lv1btnPos.x = lv1btn.transform.position.x;
        lv1btnPos.y = lv1btn.transform.position.y;
        lv1point = Camera.main.ScreenToWorldPoint(new Vector3(lv1btnPos.x,lv1btnPos.y, .21f));
        
        //무슨 레벨의 구슬의 0개라면 토스트 메세지 띄우기 else 색깔 바꾸기
        if(intlv1marble == 0)
        {
            StartCoroutine(ShowToast("level1 구슬이 없습니다.", 2.5f)); 
            yield return "intlv1marble == 0";
        }

        else
        {
            Singleton.Instance.target = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Singleton.Instance.distance));
            Instantiate(marblePrefab, lv1point, Quaternion.identity);
        }
    }

    IEnumerator Lv2Marble()
    {
        int.TryParse(lv2marblecount.text, out intlv2marble);

        Vector3 redpoint = new Vector3();
        Vector2 redbtnPos = new Vector2();
        redbtnPos.x = lv2btn.transform.position.x;
        redbtnPos.y = lv2btn.transform.position.y;
        redpoint = Camera.main.ScreenToWorldPoint(new Vector3(redbtnPos.x,redbtnPos.y, .21f));

        Vector3 bluepoint = new Vector3();
        Event currentEvent = Event.current;
        Vector2 bluebtnPos = new Vector2();
        

        bluebtnPos.x = 0.0f;
        bluebtnPos.y = -570.0f;
        bluepoint = Camera.main.ScreenToWorldPoint(new Vector3(bluebtnPos.x,bluebtnPos.y, Camera.main.nearClipPlane));

        //무슨 레벨의 구슬의 0개라면 토스트 메세지 띄우기 else 색깔 바꾸기
        if(intlv2marble == 0)
        {
            StartCoroutine(ShowToast("level2 구슬이 없습니다.", 2.5f)); 
            yield return "intlv2marble == 0";
        }

        else
        {
            marble.SetActive(true);
            Singleton.Instance.target = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Singleton.Instance.distance));
            Instantiate(marblePrefab, redpoint, Quaternion.identity);
        }
        
    }

    IEnumerator Lv3Marble()
    {
        int.TryParse(lv3marblecount.text, out intlv3marble);

        Vector3 redpoint = new Vector3();
        Vector2 redbtnPos = new Vector2();
        redbtnPos.x = lv3btn.transform.position.x;
        redbtnPos.y = lv3btn.transform.position.y;
        redpoint = Camera.main.ScreenToWorldPoint(new Vector3(redbtnPos.x,redbtnPos.y, .21f));

        Vector3 bluepoint = new Vector3();
        Event currentEvent = Event.current;
        Vector2 bluebtnPos = new Vector2();

        bluebtnPos.x = 240.0f;
        bluebtnPos.y = -570.0f;
        bluepoint = Camera.main.ScreenToWorldPoint(new Vector3(bluebtnPos.x,bluebtnPos.y, Camera.main.nearClipPlane));


        yield return "bluepoint";


        //무슨 레벨의 구슬의 0개라면 토스트 메세지 띄우기 else 색깔 바꾸기
        if(intlv3marble == 0)
        {
            StartCoroutine(ShowToast("level3 구슬이 없습니다.", 2.5f)); 
            yield return "intlv3marble == 0";
        }

        else
        {
            marble.SetActive(true);
            Singleton.Instance.target = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Singleton.Instance.distance));
            Instantiate(marblePrefab, redpoint, Quaternion.identity);
        }    
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
}
