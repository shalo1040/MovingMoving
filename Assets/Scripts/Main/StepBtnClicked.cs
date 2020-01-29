using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StepBtnClicked : MonoBehaviour
{
    public GameObject Canvas;

    public void Invisible() // 버튼이 클릭되는 순간 안보이게 숨김
    {
        Canvas.SetActive(false);
    }
  
}
