/*
게임 시작 전,
사용자에게 걸음수를 선택받음
선택받은 걸음수를 싱글톤안에 넣음

창을 열고 닫는 함수 Visible()과 Invisible() public으로 구현됨
*/
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public void OnRangeBtnClicked(int btnNumber)        //btnNumber 1,2,3 받음
    {
        int range;
        switch (btnNumber) {
            case 1:
                range = 2000;
                break;
            case 2:
                range = 4000;
                break;
            case 3:
                range = 6000;
                break;
            case 4:
                range = 8000;
                break;
            default:
                range = 0;
                break;
        }
        Singleton.Instance.range = range;       //목표 걸음수 설정
        Singleton.Instance.panel = false;       //다음 접속 시 패널 다시 설정하지 않기 위해 false
    }

    public void Invisible(GameObject obj)       //창 닫기
    {
        obj.SetActive(false);
    }

    public void Visible(GameObject obj)         //창 열기
    {
        obj.SetActive(true);
    }
}