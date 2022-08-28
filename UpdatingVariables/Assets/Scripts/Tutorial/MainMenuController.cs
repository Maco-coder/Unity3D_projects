using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    
    public void LoadGame (float input)
    {
        
        StateNameController.difficulty = input;
        SceneManager.LoadScene("Game")        ;

    }


    public void LoadGame2 (float input2)
    {
        
        StateNameController.difficulty2 = input2;

    }

}