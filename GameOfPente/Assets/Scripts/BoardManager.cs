using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
	public GameObject NodeTemplate = null;
	public GameObject[,] Nodes;

    [SerializeField] Camera m_camera = null;
    public int boardSize = 19;


    private float distanceBetween = 1.0f;

    void Start()
    {
        Initialize(boardSize);
    }

	public void Initialize(int size)
	{
        //distanceBetween = ((0.00178571f  * Mathf.Pow(boardSize, 2)) - (0.135714f * boardSize) + 3.07679f);
        float camSize = ((float)boardSize - 9) / 30;
        m_camera.orthographicSize = Mathf.Lerp(5, 20, camSize);
        GetComponent<BoardVisualizer>().Initialize(boardSize, distanceBetween);
		CreateNodes(size);
        boardSize = size;
	}

	private void CreateNodes(int size)
	{
        //float nodeSize = ((float)boardSize - 9) / 30;
        //nodeSize = Mathf.Lerp(0.75f, 0.15f, nodeSize);
        Nodes = new GameObject[boardSize, boardSize];
        float curx, cury;
        curx = 0 - (boardSize / 2 * distanceBetween);
        cury = 0 + (boardSize / 2 * distanceBetween);
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                GameObject node = Instantiate(NodeTemplate);
                Node n = node.GetComponent<Node>();
                //node.transform.localScale = new Vector3(nodeSize, nodeSize, nodeSize);
                n.boardManager = this;
                n.x = x;
                n.y = y;
                Nodes[x, y] = node;
                node.transform.position = new Vector3(curx, cury, 0.0f);
                cury -= distanceBetween;
            }
            curx += distanceBetween;
            cury = 0 + (boardSize / 2 * distanceBetween);
        }
	}

    public Node GetNode(int x, int y)
    {
        if (x < 0 || y < 0 || x >= boardSize || y >= boardSize) return null;
        return Nodes[x, y].GetComponent<Node>();
    }

    public bool IsValidPlacement(PlayerTurn player, int turn, Node node, eColor color)
    {
        return true;
    }

    public void CheckBoard(Node last)
    {
        if (WonGame(last))
        {
            print(last.Color + " WON!");
        }
        foreach (Node capture in FindCaptures(last))
        {
            capture.Color = eColor.EMPTY;
        }
        if (TesseraCreated(last))
        {
            print("TESSERA!");
        }
        else if (TriaCreated(last))
        {
            print("TRIA!");
        }
    }

    public class Line
    {
        public List<Node> nodes;
        public Direction direction;
        public Direction opposite;
    }

    public List<Node> FindCaptures(Node last)
    {
        List<Node> captures = new List<Node>();
        return captures;
    }

    private List<Line> GetLines(Node last, int size)
    {
        List<Line> lines = new List<Line>();
        lines.Add(new Line() { nodes = new List<Node>() { last }, direction = Direction.NORTH, opposite = Direction.SOUTH });
        lines.Add(new Line() { nodes = new List<Node>() { last }, direction = Direction.NORTHEAST, opposite = Direction.SOUTHWEST });
        lines.Add(new Line() { nodes = new List<Node>() { last }, direction = Direction.EAST, opposite = Direction.WEST });
        lines.Add(new Line() { nodes = new List<Node>() { last }, direction = Direction.SOUTHEAST, opposite = Direction.NORTHWEST });
        foreach (Line line in lines)
        {
            // Check if it can be expanded into a tria!
            for (int i = 0; i < size; i++)
            {
                Node node = line.nodes[0].GetNode(line.opposite);
                if (node == null) break;
                line.nodes.Insert(0, node);
            }
            for (int i = 0; i < size; i++)
            {
                Node node = line.nodes[line.nodes.Count - 1].GetNode(line.direction);
                if (node == null) break;
                line.nodes.Add(node);
            }
        }
        return lines;
    }

    private bool IsUnblocked(Line line)
    {
        Node previous = line.nodes[0].GetNode(line.opposite);
        if (previous == null || previous.Color != eColor.EMPTY)
        {
            return false;
        }
        Node next = line.nodes[line.nodes.Count - 1].GetNode(line.direction);
        if (next == null || next.Color != eColor.EMPTY)
        {
            return false;
        }
        return true;
    }

    public bool TriaCreated(Node last)
    {
        List<Line> triaLines = GetLines(last, 3);
        List<List<eColor>> trias = new List<List<eColor>>() {
            new List<eColor>() { last.Color, last.Color, last.Color },
            new List<eColor>() { last.Color, last.Color, eColor.EMPTY, last.Color },
            new List<eColor>() { last.Color, eColor.EMPTY, last.Color, last.Color }
        };
        foreach (Line line in triaLines)
        {
            for (int i = 0; i < line.nodes.Count - 4; i++)
            {
                List<Node> nodeLine = line.nodes.GetRange(0, 3);
                List<eColor> colors = new List<eColor>();
                foreach (Node node in nodeLine)
                {
                    colors.Add(node.Color);
                }
                if (trias.Contains(colors))
                {
                    if (IsUnblocked(new Line() { nodes = nodeLine, direction = line.direction, opposite = line.opposite }))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool TesseraCreated(Node last)
    {
        List<Line> tesseraLines = GetLines(last, 4);
        List<eColor> tessera = new List<eColor>() { last.Color, last.Color, last.Color, last.Color };

        return false;
    }

	

	//Specific check functions here:
    public bool WonGame(Node last)
    {
        List<Line> winLines = GetLines(last, 5);
        List<eColor> win = new List<eColor>() { last.Color, last.Color, last.Color, last.Color, last.Color };
        return false;
    }

}
