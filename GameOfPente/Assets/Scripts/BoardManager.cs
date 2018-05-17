using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
	[SerializeField] GameObject NodeTemplate = null;
	GameObject[,] Nodes;
    public int boardSize = 19;

	public void Initialize(int size)
	{
		CreateNodes(size);
	}

	private void CreateNodes(int size)
	{
        Nodes = new GameObject[boardSize, boardSize];
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                GameObject node = Instantiate(NodeTemplate);
                Node n = node.GetComponent<Node>();
                n.boardManager = this;
                n.x = x;
                n.y = y;
                Nodes[x, y] = node;
                // Set node position
            }
        }
	}

    public Node GetNode(int x, int y)
    {
        if (x < 0 || y < 0 || x >= boardSize || y >= boardSize) return null;
        return Nodes[x, y].GetComponent<Node>();
    }

    public bool IsValidPlacement(Node node, eColor color, int turn)
    {
        return true;
    }

    public void SetNodeColor(Node node, eColor color)
    {

    }

    public void CheckBoard(Node last)
    {

    }

    public List<Node> FindCaptures(Node last)
    {
        List<Node> captures = new List<Node>();
        return captures;
    }

    public bool CallTria(Node last)
    {
        return false;
    }

    public bool CallTessera(Node last)
    {
        return false;
    }

}
