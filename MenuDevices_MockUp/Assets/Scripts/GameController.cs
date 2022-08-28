using System.Collections         ;
using System.Collections.Generic ;
using UnityEngine                ;
using UnityEngine.UI             ;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
	public Text difficultyText ;
	public Text difficultyText2;

	private void Start()
	{
		difficultyText.text =  StateNameController.difficulty.ToString();
		difficultyText2.text =  StateNameController.difficulty2.ToString();
	}

	public void GoBack()
	{
		SceneManager.LoadScene("Main");
	}
}
