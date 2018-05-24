using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;
	public PlayerType playerType;
    public int captureCount;
}

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance = new TurnManager();
    public Player p1 = new Player();
    public Player p2 = new Player();
	public PlayerTurn playerTurn = PlayerTurn.BLACK_PLAYER1;
	public int TurnCount = 0;

	public void NextTurn()
	{
		TurnCount++;
		switch(playerTurn)
		{
			case PlayerTurn.BLACK_PLAYER1:
				playerTurn = PlayerTurn.WHITE_PLAYER2;
				break;
			case PlayerTurn.WHITE_PLAYER2:
				playerTurn = PlayerTurn.BLACK_PLAYER1;
				break;
		}
		if(playerTurn == PlayerTurn.WHITE_PLAYER2 && p2.playerType == PlayerType.COMPUTER)
		{
			Computer.MakeMove();
		}
	}
}
