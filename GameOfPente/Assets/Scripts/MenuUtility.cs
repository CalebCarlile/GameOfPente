using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUtility : MonoBehaviour 
{
	[SerializeField] int sceneN;

	[SerializeField] Text boardSizeText;

	[SerializeField] Slider boardSlider;

	public static int boardSize = 9;
	public void ChangeToSceneN()
	{
		SceneManager.LoadScene(sceneN);
	}

	public void StartPvP()
	{
		TurnManager.Instance.p1.playerType = PlayerType.HUMAN;
		TurnManager.Instance.p2.playerType = PlayerType.HUMAN;
		ChangeToSceneN();
	}

	public void StartPvC()
	{
		TurnManager.Instance.p1.playerType = PlayerType.HUMAN;
		TurnManager.Instance.p2.playerType = PlayerType.COMPUTER;
		ChangeToSceneN();
	}

	public void QuitApplication()
	{
		Application.Quit();
	}

	public void OpenRules()
	{
		Application.OpenURL("https://www.pente.net/instructions.html");
	}

	public void OnSliderChange()
	{
		int size = (int)boardSlider.value;
		size *= 2;
		size += 1;
		boardSizeText.text = "Board Size: " + size;
		boardSize = size;

	}
}
