using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject LoadingImage; // 화면에 나올 로딩이미지
    public Slider slider; // 로딩바
    
    // public void LoadingScreenExample()
    // {
    //     StartCoroutine(LoadingScreen());
    // }

    // Start is called before the first frame update
    void Start()
    {
        LoadingImage.SetActive(true);
        StartCoroutine(SlideProcess());
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        // AsyncOperation async = LoadingImage(false);

        
        yield return new WaitForSeconds(5); // 5초 뒤에 사라짐
        // float progress = Mathf.Clamp01(0.9f);
        // slider.value = progress;
         LoadingImage.SetActive(false);
    }

    IEnumerator SlideProcess()
    {
        float progress = Mathf.Clamp01(0.2f);
        slider.value = progress;
        yield return new WaitForSeconds(1);

        slider.value += progress;
        yield return new WaitForSeconds(1);

        slider.value += progress;
        yield return new WaitForSeconds(1);

        slider.value += progress;
        yield return new WaitForSeconds(1);

        slider.value += progress;
    }
}
