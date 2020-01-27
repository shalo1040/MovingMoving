/*
사용자가 걸음수를 지정하는 패널 뒤에 위치하는 검은색 패널
걸음수 설정을 했다면 setactive가 false
걸음수 설정을 하지 않았다면 setactive가 true
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelmanager : MonoBehaviour
{
    public GameObject panel;

    void Update()
    {
        if(Singleton.Instance.panel == true)
        {   
            panel.SetActive(true);
        }

        else
        {
            panel.SetActive(false);
        }
    }
}
