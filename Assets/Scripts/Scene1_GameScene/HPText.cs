using UnityEngine;
using TMPro;

public class HPText : MonoBehaviour
{
    float moveSpeed = .2f;
    float timer = 1f;
    TextMeshPro hpText;
    Color txtColor;
    bool moveDir;

    private void Awake()
    {
        moveDir = Singleton.Instance.isDirUp;
        hpText = GetComponent<TextMeshPro>();
        hpText.text = Singleton.Instance.changedAmount.ToString();
    }
    void Update()
    {
        if(moveDir) transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        else transform.position += new Vector3(0, - moveSpeed, 0) * Time.deltaTime;

        timer -= Time.deltaTime;
        if(timer < 0)
        {
            txtColor.a -= 3f * Time.deltaTime;
            hpText.color = txtColor;

            if (txtColor.a < 0) Destroy(gameObject);
        }
    }
}
