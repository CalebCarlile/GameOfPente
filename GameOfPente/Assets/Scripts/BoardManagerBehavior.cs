using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerBehavior: MonoBehaviour
{
	public GameObject NodeBehaviorTemplate = null;
	public GameObject[,] NodeBehaviors;

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
		CreateNodeBehaviors(size);
        boardSize = size;
	}

	private void CreateNodeBehaviors(int size)
	{
        //float nodeSize = ((float)boardSize - 9) / 30;
        //nodeSize = Mathf.Lerp(0.75f, 0.15f, nodeSize);
        NodeBehaviors = new GameObject[boardSize, boardSize];
        float curx, cury;
        curx = 0 - (boardSize / 2 * distanceBetween);
        cury = 0 + (boardSize / 2 * distanceBetween);
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                GameObject node = Instantiate(NodeBehaviorTemplate);
                NodeBehavior n = node.GetComponent<NodeBehavior>();
                n.boardManager = this;
                n.x = x;
                n.y = y;
                NodeBehaviors[x, y] = node;
                node.transform.position = new Vector3(curx, cury, 0.0f);
                cury -= distanceBetween;
            }
            curx += distanceBetween;
            cury = 0 + (boardSize / 2 * distanceBetween);
        }
	}

    public NodeBehavior GetNodeBehavior(int x, int y)
    {
        if (x < 0 || y < 0 || x >= boardSize || y >= boardSize) return null;
        return NodeBehaviors[x, y].GetComponent<NodeBehavior>();
    }

    public bool IsValidPlacement(PlayerTurn player, int turn, NodeBehavior node, eColor color)
    {
        if (node.Color != eColor.EMPTY)
        {
            return false;
        }
        // Tournament Rule
        if (turn == 0)
        {
            int boardCenter = boardSize / 2;
            if (player == PlayerTurn.BLACK_PLAYER1)
            {
                if (node.x != boardCenter || node.y != boardCenter)
                {
                    return false;
                }
            } else
            {
                if (Mathf.Abs(node.x  - boardCenter) < 3 || Mathf.Abs(node.y - boardCenter) < 3)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void CheckBoard(NodeBehavior last)
    {
        if (WonGame(last))
        {
            print(last.Color + " WON!");
        }
        foreach (NodeBehavior capture in FindCaptures(last))
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
        public List<NodeBehavior> nodes;
        public Direction direction;
        public Direction opposite;
    }

    public List<NodeBehavior> FindCaptures(NodeBehavior last)
    {
        List<NodeBehavior> captures = new List<NodeBehavior>();
        eColor other = (last.Color == eColor.BLACK) ? eColor.WHITE : eColor.BLACK;
        List<eColor> capture = new List<eColor>() { last.Color, other, other, last.Color };
        List<Line> captureLines = GetLines(last, 3);
        foreach (Line line in captureLines)
        {
            for (int i = 0; i < line.nodes.Count - 4; i++)
            {
                List<NodeBehavior> nodeLine = line.nodes.GetRange(i, 4);
                List<eColor> colors = new List<eColor>();
                foreach (NodeBehavior node in nodeLine)
                {
                    colors.Add(node.Color);
                }
                if (capture == colors)
                {
                    captures.Add(nodeLine[1]);
                    captures.Add(nodeLine[2]);
                }
            }
        }
        return captures;
    }

    private List<Line> GetLines(NodeBehavior last, int size)
    {
        List<Line> lines = new List<Line>();
        lines.Add(new Line() { nodes = new List<NodeBehavior>() { last }, direction = Direction.NORTH, opposite = Direction.SOUTH });
        lines.Add(new Line() { nodes = new List<NodeBehavior>() { last }, direction = Direction.NORTHEAST, opposite = Direction.SOUTHWEST });
        lines.Add(new Line() { nodes = new List<NodeBehavior>() { last }, direction = Direction.EAST, opposite = Direction.WEST });
        lines.Add(new Line() { nodes = new List<NodeBehavior>() { last }, direction = Direction.SOUTHEAST, opposite = Direction.NORTHWEST });
        foreach (Line line in lines)
        {
            // Check if it can be expanded into a tria!
            for (int i = 0; i < size; i++)
            {
                NodeBehavior node = line.nodes[0].GetNodeBehavior(line.opposite);
                if (node == null) break;
                line.nodes.Insert(0, node);
            }
            for (int i = 0; i < size; i++)
            {
                NodeBehavior node = line.nodes[line.nodes.Count - 1].GetNodeBehavior(line.direction);
                if (node == null) break;
                line.nodes.Add(node);
            }
        }
        return lines;
    }

    private bool IsUnblocked(Line line)
    {
        int sidesBlocked = 0;
        NodeBehavior previous = line.nodes[0].GetNodeBehavior(line.opposite);
        if (previous == null || previous.Color != eColor.EMPTY)
        {
            sidesBlocked++;
        }
        NodeBehavior next = line.nodes[line.nodes.Count - 1].GetNodeBehavior(line.direction);
        if (next == null || next.Color != eColor.EMPTY)
        {
            sidesBlocked++;
        }
        return sidesBlocked < 2;
    }

    public bool TriaCreated(NodeBehavior last)
    {
        List<Line> triaLines = GetLines(last, 3);
        List<List<eColor>> trias = new List<List<eColor>>() {
            new List<eColor>() { last.Color, last.Color, last.Color },
            new List<eColor>() { last.Color, last.Color, eColor.EMPTY, last.Color },
            new List<eColor>() { last.Color, eColor.EMPTY, last.Color, last.Color }
        };
        foreach (Line line in triaLines)
        {
            foreach (List<eColor> tria in trias)
            {
                for (int i = 0; i < line.nodes.Count - tria.Count; i++)
                {
                    List<NodeBehavior> nodeLine = line.nodes.GetRange(i, tria.Count);
                    List<eColor> colors = new List<eColor>();
                    foreach (NodeBehavior node in nodeLine)
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
        }
        return false;
    }

    public bool TesseraCreated(NodeBehavior last)
    {
        List<Line> tesseraLines = GetLines(last, 4);
        List<eColor> tessera = new List<eColor>() { last.Color, last.Color, last.Color, last.Color };
        foreach (Line line in tesseraLines)
        {
            for (int i = 0; i < line.nodes.Count - 4; i++)
            {
                List<NodeBehavior> nodeLine = line.nodes.GetRange(i, 4);
                List<eColor> colors = new List<eColor>();
                foreach (NodeBehavior node in nodeLine)
                {
                    colors.Add(node.Color);
                }
                if (tessera == colors)
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

    public bool WonGame(NodeBehavior last)
    {
        List<Line> winLines = GetLines(last, 5);
        List<eColor> win = new List<eColor>() { last.Color, last.Color, last.Color, last.Color, last.Color };
        foreach (Line line in winLines)
        {
            for (int i = 0; i < line.nodes.Count - 5; i++)
            {
                List<NodeBehavior> nodeLine = line.nodes.GetRange(i, 5);
                List<eColor> colors = new List<eColor>();
                foreach (NodeBehavior node in nodeLine)
                {
                    colors.Add(node.Color);
                }
                if (win == colors)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
