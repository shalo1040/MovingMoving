using System.Collections;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public GameObject panel1,panel2,panel3,panel4;
    public GameObject desert;
    public GameObject winter;
    public GameObject volcano;
    public GameObject city;
    public GameObject forest;
    
    void Awake() {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
    }

    void Start() {
        if(Singleton.Instance.door == 0)
        {
            desert.SetActive(true);
            winter.SetActive(false);
            volcano.SetActive(false);
            city.SetActive(false);
            forest.SetActive(false);
        }

        else if(Singleton.Instance.door == 1)
        {
            desert.SetActive(false);
            winter.SetActive(true);
            volcano.SetActive(false);
            city.SetActive(false);
            forest.SetActive(false);
        }

         else if(Singleton.Instance.door == 2)
        {
            desert.SetActive(false);
            winter.SetActive(false);
            volcano.SetActive(true);
            city.SetActive(false);
            forest.SetActive(false);
        }
        else if(Singleton.Instance.door == 3)
        {
            desert.SetActive(false);
            winter.SetActive(false);
            volcano.SetActive(false);
            city.SetActive(true);
            forest.SetActive(false);
        }

        else if(Singleton.Instance.door == 4)
        {
            desert.SetActive(false);
            winter.SetActive(false);
            volcano.SetActive(false);
            city.SetActive(false);
            forest.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Singleton.Instance.door == 0)
        {
            Debug.Log("현재 배경화면번호는 " + Singleton.Instance.door);
            desert.SetActive(true);
            winter.SetActive(false);
            volcano.SetActive(false);
            city.SetActive(false);
            forest.SetActive(false);
        }

        else if(Singleton.Instance.door == 1)
        {
            Debug.Log("현재 배경화면번호는 " + Singleton.Instance.door);
            StartCoroutine(Door1());
        }

        else if(Singleton.Instance.door == 2)
        {
            Debug.Log("현재 배경화면번호는 " + Singleton.Instance.door);
            StartCoroutine(Door2());
        }

        else if(Singleton.Instance.door == 3)
        {
            Debug.Log("현재 배경화면번호는 " + Singleton.Instance.door);
            StartCoroutine(Door3());
        }

        else if(Singleton.Instance.door == 4)
        {
            Debug.Log("현재 배경화면번호는 " + Singleton.Instance.door);
            StartCoroutine(Door4());
            GameObject[] objs = GameObject.FindGameObjectsWithTag("door");
            for (int i = 0; i < objs.Length; i++)
                Destroy(objs[i]);
        }

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "door")
            {
                Destroy(other.gameObject);
                if(Singleton.Instance.door == 0)
                {
                    Singleton.Instance.door = Singleton.Instance.door+1;
                    panel1.SetActive(true);//패널 하얘지는 애니메이션 실행
                }

                else if(Singleton.Instance.door == 1)
                {
                    Singleton.Instance.door = Singleton.Instance.door+1;
                    panel2.SetActive(true);//패널 하얘지는 애니메이션 실행
                }

                else if(Singleton.Instance.door == 2)
                {
                    Singleton.Instance.door = Singleton.Instance.door+1;
                    panel3.SetActive(true);//패널 하얘지는 애니메이션 실행
                }

                else if(Singleton.Instance.door == 3)
                {
                    panel4.SetActive(true);
                    Singleton.Instance.door = Singleton.Instance.door+1;
                }

                else if(Singleton.Instance.door == 4)
                {
                    Singleton.Instance.door = 4;
                }
                
        }
    }

    IEnumerator Door1()
    {
        yield return new WaitForSeconds(1f);
        desert.SetActive(false);
        winter.SetActive(true);
        volcano.SetActive(false);
        city.SetActive(false);
        forest.SetActive(false);
        panel1.SetActive(false);
    }

    IEnumerator Door2()
    { 
        yield return new WaitForSeconds(1f);
        desert.SetActive(false);
        winter.SetActive(false);
        volcano.SetActive(true);
        city.SetActive(false);
        forest.SetActive(false);
        panel2.SetActive(false);
    }

    IEnumerator Door3()
    { 
        yield return new WaitForSeconds(1f);
        desert.SetActive(false);
        winter.SetActive(false);
        volcano.SetActive(false);
        city.SetActive(true);
        forest.SetActive(false);
        panel3.SetActive(false);
    }

    IEnumerator Door4()
    {
        yield return new WaitForSeconds(1f);
        desert.SetActive(false);
        winter.SetActive(false);
        volcano.SetActive(false);
        city.SetActive(false);
        forest.SetActive(true);
        panel4.SetActive(false);
    }
    
}

