using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler1 : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("VR Controller-scene");
    }
}
