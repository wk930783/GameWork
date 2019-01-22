using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scenes : MonoBehaviour
{

    public Button BtnStart;
    public Button BtnExit;

    // Use this for initialization
    void Start()
    {

        BtnStart.onClick.AddListener(BtnStartOnClick);
        BtnExit.onClick.AddListener(BtnExitOnClick);

    }

    // Update is called once per frame

    public void BtnStartOnClick()
    {
        Debug.Log("yee");
        Application.LoadLevel("Play");
    }

    public void BtnExitOnClick()
    {
        Application.Quit();
    }


    void Update()
    {

    }
}
