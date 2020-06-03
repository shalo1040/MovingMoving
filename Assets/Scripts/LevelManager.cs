using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int Level;
    private float hp;
    private int exp;
    public Text showlevel;
    Scrollbar healthBar;
    Scrollbar levelBar;
    GameObject ui;

    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GameObject.Find("HPbar/HPBar").GetComponent<Scrollbar>();
        levelBar = GameObject.Find("Level/LevelBar").GetComponent<Scrollbar>();
        ui = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {
       showlevel.text = "" + (Singleton.Instance.level);
       hp = Singleton.Instance.userHP;
       Level = Singleton.Instance.level;
       exp = Singleton.Instance.exp;
        
       if(Level == 1 && exp >= 1000) // 경험치 충족시 레벨업 (lv1->lv2) 
        {
            Singleton.Instance.level += 1;
            exp %= 1000;
            Singleton.Instance.userHP = 200;
            Singleton.Instance.damage = 20;
        } else if(Level == 2 && exp >= 1500)        //lv2->lv3
        {
            Singleton.Instance.level += 1;
            exp %= 1500;
            Singleton.Instance.userHP = 300;
            Singleton.Instance.damage = 40;
        } else if(Level == 3 && exp >= 3000)        //lv3->lv4
        {
            Singleton.Instance.level += 1;
            exp %= 3000;
        }

        Singleton.Instance.exp = exp;
        switch(Level)
        {
            case 1:
                levelBar.size = Singleton.Instance.exp / 1000f;
                break;
            case 2:
                levelBar.size = Singleton.Instance.exp / 1500f;
                break;
            case 3:
                levelBar.size = Singleton.Instance.exp / 3000f;
                break;
            default:
                levelBar.size = Singleton.Instance.exp / 1000f;
                break;
        }
        healthBar.size = Singleton.Instance.userHP / Singleton.Instance.fullHP;
    }


}
