using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_1to2 : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Scene00_Main");
    }
}
