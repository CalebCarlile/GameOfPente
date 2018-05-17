using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : Singleton<TurnManager> 
{

	public string player1Name;
	public string player2Name;
	public PlayerTurn playerTurn = PlayerTurn.PLAYER1;

	public void NextTurn()
	{
		switch(playerTurn)
		{
			case PlayerTurn.PLAYER1:
				playerTurn = PlayerTurn.PLAYER2;
				break;
			case PlayerTurn.PLAYER2:
				playerTurn = PlayerTurn.PLAYER1;
				break;
		}
	}
}
