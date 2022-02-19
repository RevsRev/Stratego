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
    private bool shouldContinue = true;

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
        Thread testThread = new Thread(() =>
        {
            while (shouldContinue)
            {   StgTcpConnectionManager.testConnection("127.0.0.1", "Hello World!");
                Thread.Sleep(10000);
            }
        });
        testThread.Start();
    }

    private void OnApplicationQuit()
    {
        shouldContinue = false;
    }
}
