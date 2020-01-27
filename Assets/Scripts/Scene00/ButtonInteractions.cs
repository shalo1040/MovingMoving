using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteractions : MonoBehaviour
{
    public void OnCloseClicked()
    {
        SceneManager.LoadScene("Scene00_Main");
    }
}
