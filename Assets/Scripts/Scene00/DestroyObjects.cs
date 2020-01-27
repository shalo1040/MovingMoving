/*
 * 구슬/아이템이 화면 밖으로 사라지면 오브젝트 삭제
 */
using UnityEngine;
using System.Linq;

public class DestroyObjects : MonoBehaviour
{
    GameObject[] marbles, items, objs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        marbles = GameObject.FindGameObjectsWithTag("marble");
        items = GameObject.FindGameObjectsWithTag("item");
        objs = marbles.Concat(items).ToArray();

        foreach (GameObject o in objs)               //오브젝트가 화면 밖으로 나가면 없앤다.
        {
            if (o.transform.position.z < Camera.main.ScreenToWorldPoint(Vector3.zero).z)
            {
                if (o.tag == "marble")               //구슬이라면 사용자에게 구슬 추가로 주고 삭제한다.
                {
                    switch (o.name)
                    {
                        case "marble01(Clone)":
                            //구슬++
                            break;
                        case "marble02(Clone)":
                            //구슬++
                            break;
                        case "marble03(Clone)":
                            //구슬++
                            break;
                        default:
                            break;
                    }
                }
                Destroy(o);                         //오브젝트 삭제
            }
        }
    }
}
