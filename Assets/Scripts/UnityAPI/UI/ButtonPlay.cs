using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System;

public class ButtonPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public bool local = true;

    public void OnButtonPress()
    {
        if (local)
        {
            playLocal();
        }
        else
        {
            playNonLocal();
        }
    }

    private static void playLocal()
    {
        Debug.Log("Button pressed");
        SceneManager.LoadScene("StgPlaying");
    }

    private void playNonLocal()
    {
        //Create two new connections so that we can start a room!
        new StgTcpConnectionManager();
        new StgTcpConnectionManager();
    }
}
