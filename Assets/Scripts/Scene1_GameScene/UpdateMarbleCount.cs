/*AR 씬에서 구슬 개수 보여주고 업데이트*/

using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMarbleCount : MonoBehaviour
{
    Text lv1, lv2, lv3;
    bool isRunninglv1, isRunninglv2, isRunninglv3;

    void Start()
    {
        lv1 = GameObject.Find("Canvas/marbleBtn1/lv1").GetComponent<Text>();
        lv2 = GameObject.Find("Canvas/marbleBtn2/lv2").GetComponent<Text>();
        lv3 = GameObject.Find("Canvas/marbleBtn3/lv3").GetComponent<Text>();

        isRunninglv1 = isRunninglv2 = isRunninglv3 = false;
    }

    void Update()
    {
        StartCoroutine(GetMarbleCount());
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

            yield return lv1.text = value[0];
            yield return lv2.text = value[1];
            yield return lv3.text = value[2];
        }
    }

    public void OnRedBtnClicked()
    {
        if (!isRunninglv1) StartCoroutine(DecMarbleCount("lv1"));
    }
    public void OnGreenBtnClicked()
    {
        if (!isRunninglv2) StartCoroutine(DecMarbleCount("lv2"));
    }
    public void OnBlueBtnClicked()
    {
        if (!isRunninglv3) StartCoroutine(DecMarbleCount("lv3"));
    }

    IEnumerator DecMarbleCount(string level)
    {
        if (level == "lv1") isRunninglv1 = true;
        else if (level == "lv2") isRunninglv2 = true;
        else isRunninglv3 = true;

        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userID", Singleton.Instance.userID.ToString());
        wwwForm.AddField("marble", level);

        UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/marbles_decrease.php", wwwForm);

        yield return www.SendWebRequest();

        if (level == "lv1") isRunninglv1 = false;
        else if (level == "lv2") isRunninglv2 = false;
        else isRunninglv3 = false;
    }
}
