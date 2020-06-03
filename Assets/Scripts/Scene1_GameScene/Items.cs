/*AR 씬에서의 물약 및 쉴드 아이템 기능을 담은 스크립트*/

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    Scrollbar healthBar;
    Image activatedShieldScreen;
    public GameObject hpText;
    public GameObject shield;

    private GameObject prefab;

    bool validItem = false;

    public Text potionCount, shieldCount;

    private void Awake()
    {
        StartCoroutine(GetItemCount());
        //potionCount = GameObject.FindGameObjectWithTag("potionCount").GetComponent<Text>();
        //shieldCount = GameObject.FindGameObjectWithTag("shieldCount").GetComponent<Text>();
    }
    private void Start()
    {
        healthBar = GameObject.Find("HPbar/HPBar").GetComponent<Scrollbar>();
        activatedShieldScreen = GameObject.Find("ActivatedShieldScreen").GetComponent<Image>();
        SetAlpha(activatedShieldScreen, 0f);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Singleton.Instance.onItem)
        {
            Vector3 position = Camera.main.transform.position;
            float distance = 1.5f;

            prefab.transform.position = position + Camera.main.transform.forward * distance;
            prefab.transform.rotation = Camera.main.transform.rotation;
        }
    }
    public void OnPotionAdd()       //메인에서 물약 아이템 사용
    {
        float plus = 15f;

        StartCoroutine(CheckDB("potion"));
        StartCoroutine(GetItemCount());

        if (!validItem) return;
        else
        {
            validItem = false;

            if (Singleton.Instance.userHP >= Singleton.Instance.fullHP - plus)    //사용자 HP 증가
                Singleton.Instance.userHP = Singleton.Instance.fullHP;
            else Singleton.Instance.userHP += plus;
            healthBar.size = Singleton.Instance.userHP / Singleton.Instance.fullHP;
        }
    }
    public void OnPotionClicked()      //물약 아이템 사용
    {
        float plus = 15f;

        StartCoroutine(CheckDB("potion"));
        StartCoroutine(GetItemCount());

        if (!validItem) return;
        else
        {
            validItem = false;

            if (Singleton.Instance.userHP >= Singleton.Instance.fullHP - plus)    //사용자 HP 증가
                Singleton.Instance.userHP = Singleton.Instance.fullHP;
            else Singleton.Instance.userHP += plus;
            healthBar.size = Singleton.Instance.userHP / Singleton.Instance.fullHP;
            Singleton.Instance.isDirUp = true;
            Singleton.Instance.changedAmount = plus;

            Transform cam = Camera.main.transform;
            Vector3 pos = cam.position + cam.forward * 2.3f + cam.up * 1.3f;
            pos.x = Random.Range(cam.position.x - .4f, cam.position.x);
            Instantiate(hpText, pos, cam.rotation);
        }
    }

    public void OnShieldClicked()      //쉴드 아이템 사용
    {
        if (Singleton.Instance.onItem) return;      //중복으로 아이템 사용 방지

        StartCoroutine(CheckDB("shield"));
    }

    IEnumerator Shield()
    {
        //방어 효과 on
        Singleton.Instance.onItem = true;       //쉴드 아이템 사용하는 동안은 몬스터 공격 받지 않음

        /*for(float time = 4f, alpha = 1f; time > 0; time--, alpha -= 0.25f)
        {
            SetAlpha(activatedShieldScreen, alpha);
            yield return new WaitForSeconds(1);
        }*/

        Vector3 position = Camera.main.transform.position;
        position.y -= .1f;
        position.z += 1.5f;
        prefab = Instantiate(shield, position, Quaternion.identity);
        yield return new WaitForSeconds(4);
        //방어 효과 off
        Singleton.Instance.onItem = false;
        Destroy(prefab);
    }

    IEnumerator CheckDB(string item)        //DB에 아이템 있는지 확인하고 있으면 사용
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID.ToString());
        wwwForm.AddField("item", item);

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/items_checkDB.php", wwwForm);
        yield return www.SendWebRequest();

        string t = www.downloadHandler.text;
        string[] value = t.Split('*');
        if (value[0] == "true")
        {
            validItem = true;
            yield return potionCount.text = value[2];
            yield return shieldCount.text = value[1];

            if (item == "shield")
                StartCoroutine(Shield());
        }
        else validItem = false;
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

            yield return potionCount.text = value[0];
            yield return shieldCount.text = value[1];
        }
    }

    void SetAlpha(Image img, float color)
    {
        Color c = img.color;
        c.a = color;
        img.color = c;
    }
}