/*
사용자에게 걸음수를 선택받음
선택받은 걸음수를 싱글톤안에 넣음
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepManager : MonoBehaviour
{
    public Button Range1Btn;
    public Button Range2Btn;
    public Button Range3Btn;
    public Button NoRangeBtn;


    public void ClickedButton1()
    {
        Singleton.Instance.range = 2000;
        Debug.Log(2000);
        Singleton.Instance.panel = false;
    }

    public void ClickedButton2()
    {
        Singleton.Instance.range = 3000;
        Debug.Log(3000);
        Singleton.Instance.panel = false;
    }

    public void ClickedButton3()
    {
        Singleton.Instance.range = 5000;
        Debug.Log(5000);
        Singleton.Instance.panel = false;
    }

    public void ClickedButton4()
    {
        Singleton.Instance.range = 00;
        Debug.Log(00);
        Singleton.Instance.panel = false;
    }
}

