/*
구슬이 날아가고 나서 다시 생길 수 있도록 하는 스크립트
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleGenerator : MonoBehaviour
{
    public GameObject marblePrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            
                GameObject marble = Instantiate(marblePrefab) as GameObject;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            Vector3 worldDir = ray.direction;
            
        }
    }
}
