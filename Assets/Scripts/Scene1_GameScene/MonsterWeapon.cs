/* 몬스터가 공격하면서 쏘는 공의 움직임에 대한 스크립트
 * 사용자의 카메라를 향해 공이 날아오며
 * 카메라에 닿으면 공은 사라지고 사용자의 HP가 줄어든다.(Player.cs)
 * */
using UnityEngine;

public class MonsterWeapon : MonoBehaviour
{
    GameObject cam;
    Vector3 target;
    Vector3 pos;
    Vector3 dir;
    float speed = 2f;
    
    void Start()
    {
        cam = GameObject.Find("ARCamera");
        target = cam.transform.position;
        pos = transform.position;

        dir = (target - pos).normalized;
        Debug.Log("dir = " + dir);
    }
    
    void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player") || other.gameObject.CompareTag("shield"))
            Destroy(gameObject);
    }
}
