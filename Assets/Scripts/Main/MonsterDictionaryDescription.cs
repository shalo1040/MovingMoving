/*
해당 몬스터 클릭시 몬스터 사진 + 몬스터 설명이 나온다
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDictionaryDescription : MonoBehaviour
{
    public GameObject mon1,mon2,mon3,mon4,mon5,mon6,mon7,mon8,mon9,mon10,mon11,mon12,mon13,mon14,mon15,mon16;

    public GameObject img;

    private void Awake() {
        /*
        mon1 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (1)");
        mon2 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (2)");
        mon3 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (3)");
        mon4 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (4)");
        mon5 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (5)");
        mon6 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (6)");
        mon7 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (7)");
        mon8 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (8)");
        mon9 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (9)");
        mon10 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (10)");
        mon11 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (11)");
        mon12 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (12)");
        mon13 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (13)");
        mon14 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (14)");
        mon15 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (15)");
        mon16 = GameObject.Find("Canvas/MonsterDictionary/MonDescription/monbook_ghost (16)");
        */
    }
    void Start() {
        img.SetActive(true);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
    }

    public void Mon1(){
        img.SetActive(false);
        mon1.SetActive(true);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }

        
    public void Mon2(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(true);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon3(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(true);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon4(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(true);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon5(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(true);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon6(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(true);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon7(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(true);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon8(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(true);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon9(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(true);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon10(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(true);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon11(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(true);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon12(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(true);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon13(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(true);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon14(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(true);
        mon15.SetActive(false);
        mon16.SetActive(false);
        }
    public void Mon15(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(true);
        mon16.SetActive(false);
        }    
    public void Mon16(){
        img.SetActive(false);
        mon1.SetActive(false);
        mon2.SetActive(false);
        mon3.SetActive(false);
        mon4.SetActive(false);
        mon5.SetActive(false);
        mon6.SetActive(false);
        mon7.SetActive(false);
        mon8.SetActive(false);
        mon9.SetActive(false);
        mon10.SetActive(false);
        mon11.SetActive(false);
        mon12.SetActive(false);
        mon13.SetActive(false);
        mon14.SetActive(false);
        mon15.SetActive(false);
        mon16.SetActive(true);
    }
}
