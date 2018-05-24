using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {

	[SerializeField] Text PlayerTurnText;
	[SerializeField] Text TimerText;

	private float timeRemaining;
	private PlayerTurn curPlayer;

	private TurnManager turnManager = null;
	

	void Start () 
	{
		PlayerTurnText.text = "Current Turn: " + TurnManager.Instance.p1.name;
		turnManager = TurnManager.Instance;
		turnManager.playerTurn = PlayerTurn.BLACK_PLAYER1;
		curPlayer = turnManager.playerTurn;
		timeRemaining = 20;
	}
	
	void Update () 
	{
		timeRemaining -= Time.deltaTime;
		if(timeRemaining <= 0)
		{
			turnManager.NextTurn();
		}
		TimerText.text = Mathf.Ceil(timeRemaining).ToString();
		if(turnManager.playerTurn != curPlayer)
		{
			curPlayer = turnManager.playerTurn;
			switch(curPlayer)
			{
				case PlayerTurn.BLACK_PLAYER1:
					PlayerTurnText.text = "Current Turn: " + turnManager.p1.name;
					break;
				case PlayerTurn.WHITE_PLAYER2:
					PlayerTurnText.text = "Current Turn: " + turnManager.p2.name;
					break;
			}
			timeRemaining = 20;
		}
	}
}
