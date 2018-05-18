using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUtility : MonoBehaviour 
{
	[SerializeField] int sceneN;


	public void ChangeToSceneN()
	{
		SceneManager.LoadScene(sceneN);
	}

	public void QuitApplication()
	{
		Application.Quit();
	}

	public void OpenRules()
	{
		Application.OpenURL("https://www.pente.net/instructions.html");
	}

}
