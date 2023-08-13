using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler2 : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("3D touch-scene");
    }
}
