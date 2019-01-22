using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static bool isfirstrun = true;


    // Use this for initialization
    private void Awake()
    {
        if (!isfirstrun)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);  //自殺
        }
        else
        {
            isfirstrun = !true;
            DontDestroyOnLoad(this.gameObject);
        }
    }

}


