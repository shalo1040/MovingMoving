/* main 씬 처음 시작할 때 로딩 영상 보여준 뒤 걸음수 설정 */
using UnityEngine;

public class LoadingVideo : MonoBehaviour
{
    GameObject ui;
    public GameObject goal;
    float timer = 5f;
    
    void Start()
    {
        if (!Singleton.Instance.watchedLoading)
        {
            ui = GameObject.Find("UI");
            //goal = GameObject.Find("SetGoalBackground");
            ui.SetActive(false);
            goal.SetActive(false);
            Debug.Log("loadingVideo");
        }
        else
        {
            Destroy(gameObject);
            goal.SetActive(false);
        }
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
            ui.SetActive(true);
            goal.SetActive(true);
            Singleton.Instance.watchedLoading = true;
        }
    }
}
