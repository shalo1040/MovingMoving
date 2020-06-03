/* 스킵 또는 다음으로 버튼 클릭했을 때 씬 바꾸기
 * 영상 끝나면 버튼 이미지 바꾸기
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ButtonEvent : MonoBehaviour
{
    Button btn;
    VideoPlayer vp;
    public Sprite nextImg;

    private void Start()
    {
        btn = GameObject.Find("SkipBtn").GetComponent<Button>();
        vp = GameObject.Find("Video Player").GetComponent<VideoPlayer>();

        vp.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer source)
    {
        //버튼 이미지 바꾸기
        btn.image.sprite = nextImg;
    }

    //스킵 또는 다음 버튼 클릭
    public void btnClicked()
    {
        SceneManager.LoadScene("SceneB1_Signup");
    }
}