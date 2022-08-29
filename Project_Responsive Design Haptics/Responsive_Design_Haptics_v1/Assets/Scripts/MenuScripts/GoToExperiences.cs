using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;

public class GoToExperiences : MonoBehaviour
{
	public void GoToMenuExperiences()
	{
		SceneManager.LoadScene("MainMenu_Experiences");
	}

	//void Update()
	//{
	//	if (Input.GetKeyDown("space")){
	//		SceneManager.LoadScene("MainMenu_Experiences");
	//	}

    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        SceneManager.LoadScene("VR Controller-scene");
    //    }

    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        SceneManager.LoadScene("3D touch-scene");
    //    }
    //}

}