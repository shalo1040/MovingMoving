/*
싱클톤에서 bool 타입이 true인 몬스터들을 화면에서 보이게 함
*/
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MonsterDictionaryInput : MonoBehaviour
{
    public GameObject[] monbox;
    public Sprite noMonsters;
    public Sprite noClickedMonsters;
    public Image img;
    
    private void Awake() {
        for(int i = 0; i < 9; i++)
        {
            monbox[i].SetActive(false);
        }
        StartCoroutine(CheckMonsters());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Singleton.Instance.sceneNumber == 2)
        {
            StartCoroutine(CheckMonsters());
            Singleton.Instance.sceneNumber = 1;
        }
    }

    IEnumerator CheckMonsters()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/monsters_retrieve.php", wwwForm);
        yield return www.SendWebRequest();
        
        string[] value = www.downloadHandler.text.Split('*');
        string str = "";
        //for (int i = 0; i < 12; i++) str += value[i] + " ";
        foreach (string s in value)
            str += s + " ";
        Debug.Log(str);

        if (value.Length <= 0) img.sprite = noMonsters;
        else img.sprite = noClickedMonsters;

        for (int i = 0; i < value.Length-1; i++)
        {
            Debug.Log("length "+value.Length);
            if (value[i] == "1") monbox[i].SetActive(true);
            else monbox[i].SetActive(false);
        }
    }
}
