using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class BoardManager {

    public int boardSize;
    public Node[,] nodes;

    public void Init(int size)
    {
        boardSize = size;
        nodes = new Node[size, size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                nodes[x, y] = new Node();
                nodes[x, y].x = x;
                nodes[x, y].y = y;
            }
        }
    }

    public Node GetNode(Node n, Direction dir)
    {
        switch (dir)
        {
            case Direction.EAST:
                return GetNode(n.x + 1, n.y);
            case Direction.NORTH:
                return GetNode(n.x, n.y - 1);
            case Direction.NORTHEAST:
                return GetNode(n.x + 1, n.y - 1);
            case Direction.NORTHWEST:
                return GetNode(n.x - 1, n.y - 1);
            case Direction.SOUTH:
                return GetNode(n.x, n.y + 1);
            case Direction.SOUTHEAST:
                return GetNode(n.x + 1, n.y + 1);
            case Direction.SOUTHWEST:
                return GetNode(n.x - 1, n.y + 1);
            case Direction.WEST:
                return GetNode(n.x - 1, n.y);
        }
        return null;
    }

    public Node GetNode(int x, int y)
    {
        if (x < 0 || y < 0 || x >= boardSize || y >= boardSize) return null;
        return nodes[x, y];
    }

    public bool IsValidPlacement(PlayerTurn player, int turn, Node node, eColor color)
    {
        int boardCenter = boardSize / 2;
        if (node.color != eColor.EMPTY)
        {
            return false;
        }
        // Tournament Rule
        if (turn == 0 && player == PlayerTurn.BLACK_PLAYER1 
                && (node.x != boardCenter || node.y != boardCenter) )
        {
            return false;
            
        }
        else if( turn == 2 && player == PlayerTurn.BLACK_PLAYER1 
                && (Mathf.Abs(node.x - boardCenter) < 3 && Mathf.Abs(node.y - boardCenter) < 3) )
        {
            return false;
            
            
        }
        return true;
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
        eColor other = (last.color == eColor.BLACK) ? eColor.WHITE : eColor.BLACK;
        List<eColor> capture = new List<eColor>() { last.color, other, other, last.color };
        List<Line> captureLines = GetLines(last, 4);
        foreach (Line line in captureLines)
        {
            for (int i = 0; i < line.nodes.Count - 4; i++)
            {
                List<Node> nodeLine = line.nodes.GetRange(i, 4);
                List<eColor> colors = new List<eColor>();
                foreach (Node node in nodeLine)
                {
                    colors.Add(node.color);
                }
                if (capture.SequenceEqual(colors))
                {
                    captures.Add(nodeLine[1]);
                    captures.Add(nodeLine[2]);
                }
            }
        }
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
            for (int i = 0; i < size; i++)
            {
                Node node = GetNode(line.nodes[0], line.opposite);
                if (node == null) break;
                line.nodes.Insert(0, node);
            }
            for (int i = 0; i < size; i++)
            {
                Node node = GetNode(line.nodes[line.nodes.Count - 1], line.direction);
                if (node == null) break;
                line.nodes.Add(node);
            }
        }
        return lines;
    }

    private int SidesBlocked(Line line)
    {
        int sidesBlocked = 0;
        Node previous = GetNode(line.nodes[0], line.opposite);
        if (previous == null || previous.color != eColor.EMPTY)
        {
            sidesBlocked++;
        }
        Node next = GetNode(line.nodes[line.nodes.Count - 1], line.direction);
        if (next == null || next.color != eColor.EMPTY)
        {
            sidesBlocked++;
        }
        return sidesBlocked;
    }

    public bool TriaCreated(Node last)
    {
        List<Line> triaLines = GetLines(last, 4);
        List<List<eColor>> trias = new List<List<eColor>>() {
            new List<eColor>() { last.color, last.color, last.color },
            new List<eColor>() { last.color, last.color, eColor.EMPTY, last.color },
            new List<eColor>() { last.color, eColor.EMPTY, last.color, last.color }
        };
        foreach (Line line in triaLines)
        {
            foreach (List<eColor> tria in trias)
            {
                for (int i = 0; i < line.nodes.Count - tria.Count; i++)
                {
                    List<Node> nodeLine = line.nodes.GetRange(i, tria.Count);
                    List<eColor> colors = new List<eColor>();
                    foreach (Node node in nodeLine)
                    {
                        colors.Add(node.color);
                    }
                    foreach (var triaOption in trias)
                    {
                        if (triaOption.SequenceEqual(colors))
                        {
                            if (SidesBlocked(new Line() { nodes = nodeLine, direction = line.direction, opposite = line.opposite }) == 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    public bool TesseraCreated(Node last)
    {
        List<Line> tesseraLines = GetLines(last, 4);
        List<eColor> tessera = new List<eColor>() { last.color, last.color, last.color, last.color };
        foreach (Line line in tesseraLines)
        {
            for (int i = 0; i < line.nodes.Count - 4; i++)
            {
                List<Node> nodeLine = line.nodes.GetRange(i, 4);
                List<eColor> colors = new List<eColor>();
                foreach (Node node in nodeLine)
                {
                    colors.Add(node.color);
                }
                if (tessera.SequenceEqual(colors))
                {
                    if (SidesBlocked(new Line() { nodes = nodeLine, direction = line.direction, opposite = line.opposite }) < 2)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool WonGame(Node last)
    {
        List<Line> winLines = GetLines(last, 5);
        List<eColor> win = new List<eColor>() { last.color, last.color, last.color, last.color, last.color };
        foreach (Line line in winLines)
        {
            for (int i = 0; i < line.nodes.Count - 5; i++)
            {
                List<Node> nodeLine = line.nodes.GetRange(i, 5);
                List<eColor> colors = new List<eColor>();
                foreach (Node node in nodeLine)
                {
                    colors.Add(node.color);
                }
                if (win.SequenceEqual(colors))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void SaveNodesToFile(string path)
    {
        using (StreamWriter saveWrite = new StreamWriter(path))
        {
            saveWrite.WriteLine(boardSize);
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    saveWrite.Write((int)nodes[x, y].color);
                }
                saveWrite.Write("\n");
            }
        }
    }

    public void LoadNodesFromFile(string path)
    {
        using (StreamReader loadRead = new StreamReader(path))
        {
            boardSize = int.Parse(loadRead.ReadLine());
            for (int x = 0; x < boardSize; x++)
            {
                string line = loadRead.ReadLine();
                for (int y = 0; y < boardSize; y++)
                {
                    nodes[x, y].color = (eColor)int.Parse(line[y].ToString());
                }
            }
        }
    }

}
