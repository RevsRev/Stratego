using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonPress()
    {
        Debug.Log("Button pressed");
        SceneManager.LoadScene("StgPlaying");
    }
}
