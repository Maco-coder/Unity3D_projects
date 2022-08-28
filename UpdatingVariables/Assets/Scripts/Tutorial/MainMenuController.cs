using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{

    public float input ;
    public float input2;
    
    public void LoadGame()
    {
        
        StateNameController.difficulty = input  ;
        StateNameController.difficulty2 = input2;
        SceneManager.LoadScene("Game")          ;

    }
}