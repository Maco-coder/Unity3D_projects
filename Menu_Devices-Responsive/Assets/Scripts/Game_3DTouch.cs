using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;


public class Game_3DTouch : MonoBehaviour
{
	public Text Text_Touch_GRAB_vibration_gain     ;
	public Text Text_Touch_GRAB_vibration_magnitude;

	public Text Text_Touch_PLUCK_vibration_gain     ;
	public Text Text_Touch_PLUCK_vibration_magnitude;

	public Text Text_Touch_SPRING_spring_gain      ;
	public Text Text_Touch_SPRING_spring_magnitude ;
	
	
	private void Start()
	{
		Text_Touch_GRAB_vibration_gain.text = StoreVariables.Touch_GRAB_vibration_gain.ToString()           ;
		Text_Touch_GRAB_vibration_magnitude.text = StoreVariables.Touch_GRAB_vibration_magnitude.ToString() ;

		Text_Touch_PLUCK_vibration_gain.text = StoreVariables.Touch_PLUCK_vibration_gain.ToString()           ;
		Text_Touch_PLUCK_vibration_magnitude.text = StoreVariables.Touch_PLUCK_vibration_magnitude.ToString() ;

		Text_Touch_SPRING_spring_gain.text = StoreVariables.Touch_SPRING_spring_gain.ToString()           ;
		Text_Touch_SPRING_spring_magnitude.text = StoreVariables.Touch_SPRING_spring_magnitude.ToString() ;
	}


	public void GoBack()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
