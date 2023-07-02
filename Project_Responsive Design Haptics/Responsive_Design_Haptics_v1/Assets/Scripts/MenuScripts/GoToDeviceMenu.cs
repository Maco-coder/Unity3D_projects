using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;

public class GoToDeviceMenu : MonoBehaviour
{
	public void GoToDevices()
	{
		SceneManager.LoadScene("Devices_MainMenu");
	}

	void Update()
	{
		if (Input.GetKeyDown("space")){
			SceneManager.LoadScene("Devices_MainMenu");
		}
	}
}
