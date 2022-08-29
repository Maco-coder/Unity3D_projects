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

	void Update()
	{
		if (Input.GetKeyDown("space")){
			SceneManager.LoadScene("MainMenu_Devices");
		}
	}

}