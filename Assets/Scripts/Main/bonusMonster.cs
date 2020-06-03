/*
    보너스 몬스터가 생성될 시 활성화
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bonusMonster : MonoBehaviour
{
    public Button bonusMon;
    int currentSteps, steps, bonusMonsterSteps, bonusMonsterLimit = 300;

    private void Awake()
    {
        if (Singleton.Instance.onBonusMonster == false) SetAlpha(bonusMon.image, .5f);
        else SetAlpha(bonusMon.image, 1f);
        bonusMon.onClick.AddListener(BonusMonster);
    }
    private void Update()
    {
        currentSteps = Singleton.Instance.step;
        bonusMonsterSteps = currentSteps % bonusMonsterLimit;

        if(currentSteps > 0 && steps !=currentSteps && bonusMonsterSteps == 0)
        {
            SetAlpha(bonusMon.image, 1f);
            Singleton.Instance.onBonusMonster = true;
        }
    }
    public void BonusMonster()
    {
        Debug.Log(bonusMon);
        if(bonusMon.image.color.a == 1f)
        {
            Singleton.Instance.bonusmonster = true;
            Singleton.Instance.onBonusMonster = false;
            SetAlpha(bonusMon.image, .5f);
            SceneManager.LoadScene("Scene01_MonsterAR");//씬 전환 
        }
    }
    void SetAlpha(Image img, float color)
    {
        Color c = img.color;
        c.a = color;
        img.color = c;
    }
}
