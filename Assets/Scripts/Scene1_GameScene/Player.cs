/* 몬스터의 공격에 맞으면 사용자 HP 감소하고 게임에서 졌을 경우 결과화면 보여줌 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameObject cam;
    GameObject attackedScreen;
    Image attackedScreenImg;
    GameObject resultWindow;
    Text resultTxt, result;
    Button resultBtn;
    Scrollbar healthBar;
    public Sprite loseImg;
    Image loseResultImg;

    public GameObject hpText;

    float damage = Singleton.Instance.damage;     //몬스터의 공격 데미지
    
    void Awake()
    {
        Singleton.Instance.sceneNumber = 2;
        attackedScreen = GameObject.Find("AttackedScreen");
        attackedScreenImg = attackedScreen.GetComponent<Image>();
        attackedScreen.SetActive(false);
    }

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        resultWindow = GameObject.Find("Canvas/Result Window");
        resultBtn = GameObject.Find("Canvas/Result Window/closeBtn").GetComponent<Button>();
        loseResultImg = GameObject.Find("Result Window/Image").GetComponent<Image>();
        result = GameObject.Find("Canvas/Result Window/result").GetComponent<Text>();
        resultBtn.onClick.AddListener(CloseBtnClicked);
        resultWindow.SetActive(false);

        healthBar = GameObject.Find("HPbar/HPBar").GetComponent<Scrollbar>();
        healthBar.size = 1f;
    }

    private void Update()
    {
        transform.position = cam.transform.position;

        if(Singleton.Instance.done)
        {
            Destroy(GameObject.FindGameObjectWithTag("monster"));
            Singleton.Instance.done = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("monster weapon"))
        {
            Vibration.Vibrate((long)200);
            if (!Singleton.Instance.onItem)          //사용자가 쉴드 아이템 사용하고 있지 않으면 데미지 준다
            {
                StartCoroutine(Attacked());     //사용자 화면 색 변화
                Singleton.Instance.isDirUp = false;
                Singleton.Instance.changedAmount = damage;

                Transform cam = Camera.main.transform;
                Vector3 pos = cam.position + cam.forward * 2.3f + cam.up * 1.3f;
                pos.x = Random.Range(cam.position.x - .4f, cam.position.x);
                Instantiate(hpText, pos, cam.rotation);
                
                if (Singleton.Instance.userHP > damage)         //사용자 체력 감소
                {
                    Singleton.Instance.userHP -= damage;
                    healthBar.size = Singleton.Instance.userHP / Singleton.Instance.fullHP;          //사용자 체력 바 감소
                }
                else                                //사용자가 짐
                {
                    Debug.Log("LOSE");
                    Singleton.Instance.userHP = 0;
                    Lose();                         //결과 화면
                    healthBar.size = 0f;          //사용자 체력 바 감소
                    Debug.Log("lose1");
                }
            }
        }
     }

    IEnumerator Attacked()
    {
        attackedScreen.SetActive(true);
        Color c = attackedScreenImg.color;
        c.a = 1f;
        attackedScreenImg.color = c;

        yield return new WaitForSeconds(2);

        attackedScreen.SetActive(false);
    }

    //사용자가 졌을 때
    void Lose()
    {
        Destroy(GameObject.FindGameObjectWithTag("monsterHP"));
        Destroy(GameObject.FindGameObjectWithTag("monster"));
        Debug.Log("lose2");
        //Time.timeScale = 0;

        loseResultImg.sprite = loseImg;
        loseResultImg.rectTransform.localPosition = new Vector3(0, 110, 0);
        loseResultImg.rectTransform.localScale = new Vector3(8, 8, 8);

        //경험치 감소
        if (Singleton.Instance.exp < 50) Singleton.Instance.exp = 0;
        else Singleton.Instance.exp -= 50;

        result.rectTransform.localPosition = new Vector3(0f, 364f, 0f);

        result.text = "경험치가 " + 50 + "만큼 감소했습니다.";
        resultWindow.SetActive(true);           //결과창
    }

    //메인씬으로 이동
    void CloseBtnClicked()
    {
        SceneManager.LoadScene("Scene00_Main");
    }
}