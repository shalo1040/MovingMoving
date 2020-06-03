using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    public GameObject BarPrefab;
    protected Image Bar;
    protected Image BarFilled;
    //public GameObject barcontrol;


    // Start is called before the first frame update
    void Start()
    {
        Bar = Instantiate(BarPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        //Bar.transform.parent = barcontrol.transform;
        //Bar.GetComponent<Transform>().SetParent(GameObject.Find("Canvas/monsterbar").GetComponent<Transform>());
        BarFilled = new List<Image>(Bar.GetComponentsInChildren<Image>()).Find(image => image !=Bar);

    }

    // Update is called once per frame
    void Update()
    {
        Bar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0,0.7f,0));
        BarFilled.fillAmount = 1.0f;
    }

}
