using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
	[SerializeField] GameObject NodeTemplate = null;
	List<SpriteRenderer> Lines = new List<SpriteRenderer>();
	GameObject[][] Nodes;

	public void Initialize(int size)
	{
		ClearBoard();
		CreateLines(size);
		CreateNodes(size);
	}

	private void CreateLines(int size)
	{

	}

	private void CreateNodes(int size)
	{

	}

	public void ClearBoard()
	{
		Lines.Clear();
	}

	public void CheckBoard(Node placed)
	{
		
	}

	

	//Specific check functions here:

}
