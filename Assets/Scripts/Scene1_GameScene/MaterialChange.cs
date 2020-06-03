using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public GameObject marble;
    public Material red;
    public Material green;
    public Material blue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Red()
    {
        marble.GetComponent<Renderer>().material = red;
    }

    public void Green()
    {
        marble.GetComponent<Renderer>().material = green;
    }


    public void Blue()
    {
        marble.GetComponent<Renderer>().material = blue;
    }

}
