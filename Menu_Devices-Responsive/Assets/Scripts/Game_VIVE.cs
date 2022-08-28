using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;


public class Game_VIVE : MonoBehaviour
{

	public Text Text_VRcontroller_GRAB_pulse_time     ;
	public Text Text_VRcontroller_GRAB_pulse_frequency;
	public Text Text_VRcontroller_GRAB_pulse_amplitude;

	public Text Text_VRcontroller_PLUCK_pulse_time     ;
	public Text Text_VRcontroller_PLUCK_pulse_frequency;
	public Text Text_VRcontroller_PLUCK_pulse_amplitude;

	public Text Text_VRcontroller_SPRING_pulse_time     ;
	public Text Text_VRcontroller_SPRING_pulse_frequency;
	public Text Text_VRcontroller_SPRING_pulse_amplitude;


	private void Start()
	{
		Text_VRcontroller_GRAB_pulse_time.text = StoreVariables.VRcontroller_GRAB_pulse_time.ToString()          ;
		Text_VRcontroller_GRAB_pulse_frequency.text = StoreVariables.VRcontroller_GRAB_pulse_frequency.ToString();
		Text_VRcontroller_GRAB_pulse_amplitude.text = StoreVariables.VRcontroller_GRAB_pulse_amplitude.ToString();
		
		Text_VRcontroller_PLUCK_pulse_time.text = StoreVariables.VRcontroller_PLUCK_pulse_time.ToString()          ;
		Text_VRcontroller_PLUCK_pulse_frequency.text = StoreVariables.VRcontroller_PLUCK_pulse_frequency.ToString();
		Text_VRcontroller_PLUCK_pulse_amplitude.text = StoreVariables.VRcontroller_PLUCK_pulse_amplitude.ToString();

		Text_VRcontroller_SPRING_pulse_time.text = StoreVariables.VRcontroller_SPRING_pulse_time.ToString()          ;
		Text_VRcontroller_SPRING_pulse_frequency.text = StoreVariables.VRcontroller_SPRING_pulse_frequency.ToString();
		Text_VRcontroller_SPRING_pulse_amplitude.text = StoreVariables.VRcontroller_SPRING_pulse_amplitude.ToString();

	}

	public void GoBack()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
