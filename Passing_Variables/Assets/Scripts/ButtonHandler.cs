using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    
    public void ClickButton1(){
        Debug.Log("Click Button1");
        SceneManager.LoadScene(1) ;
    }

    public void BackButton(){
        Debug.Log("Going Back")   ;
        SceneManager.LoadScene(0) ;
    }

}
