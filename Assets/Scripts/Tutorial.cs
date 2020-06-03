using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    GameObject tutorial;
    Button tutorialCloseBtn;

    void Start()
    {
        tutorial = GameObject.Find("tutorialImg");
        tutorialCloseBtn = GameObject.Find("tutorialImg/closeButton").GetComponent<Button>();
        tutorialCloseBtn.onClick.AddListener(CloseTutorial);

        if (Singleton.Instance.sawTutorial == true)
            Destroy(tutorial);
    }
    
    //튜토리얼 창 닫기
    void CloseTutorial()
    {
        tutorial.SetActive(false);
        Singleton.Instance.sawTutorial = true;
    }
}
