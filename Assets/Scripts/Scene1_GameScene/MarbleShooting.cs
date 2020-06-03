/*
 손을 누르고 있다 떼면 구슬이 날아가는 스크립트(마블 프리팹에 적용)
*/
using UnityEngine;

public class MarbleShooting : MonoBehaviour
{
    public Material lv1;
    public Material lv2;
    public Material lv3;
    
    private void FixedUpdate()
    {
        this.transform.position += Singleton.Instance.target * 2 * Time.deltaTime;
    }

    void Update() 
    {
        if(Singleton.Instance.marble == "lv1")
        {
            gameObject.GetComponent<Renderer>().material = lv1;
        }

        else if(Singleton.Instance.marble == "lv2")
        {
            gameObject.GetComponent<Renderer>().material = lv2;
        }

        else if(Singleton.Instance.marble == "lv3")
        {
            gameObject.GetComponent<Renderer>().material = lv3;
        }
    }

}
