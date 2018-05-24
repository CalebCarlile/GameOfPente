using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class PenteBoardValidation
{

    // Test neighbors, intersections that have 2, 3, and 4 neighbors
    // [Test]
    // public void TestIntersectionNeighbors()
    // {

    // }

    // Test captures, single, multiple, both players, false capture where player boxes themselves in
    // List<List<Node>>

    [Test] public void TestFalseCapture_Black_Vertical ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 6]).Count == 0);
    }

    [Test] public void TestFalseCapture_Black_Horizontal ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[6, 5]).Count == 0);
    }
    [Test] public void TestFalseCapture_White_Vertical ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 6]).Count == 0);
    }

    [Test] public void TestFalseCapture_White_Horizontal ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[6, 5]).Count == 0);
    }
    #region Black Tria Tests
    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Positon_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Positon_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Positon_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Positon_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Positon_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Positon_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Blocked_Space_Position_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Blocked_Space_Position_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Blocked_Space_Position_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Blocked_Space_Position_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Blocked_Space_Position_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Blocked_Space_Position_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;
        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_No_Space_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_1_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Vertical_With_Space_Position_2_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Positon_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Positon_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Positon_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Positon_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Positon_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Positon_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;

        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Blocked_Space_Position_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Blocked_Space_Position_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Blocked_Space_Position_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Blocked_Space_Position_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Blocked_Space_Position_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Blocked_Space_Position_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_No_Space_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_1_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Horizontal_With_Space_Position_2_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;

        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Positon_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Positon_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Positon_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Positon_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Positon_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Positon_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;

        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Blocked_Space_Position_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Blocked_Space_Position_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Blocked_Space_Position_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Blocked_Space_Position_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Blocked_Space_Position_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Blocked_Space_Position_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_No_Space_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_1_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;

        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Positon_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Positon_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Positon_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;

        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Positon_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Positon_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Positon_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;

        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Blocked_Space_Position_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Blocked_Space_Position_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Blocked_Space_Position_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Blocked_Space_Position_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Blocked_Space_Position_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Blocked_Space_Position_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_No_Space_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_1_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_Black_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }
    #endregion

    #region Black Tessera Tests 
    [Test]
    public void TestTessaraFinder_Black_Vertical_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[4, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[3, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[2, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[4, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[3, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[2, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[4, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[3, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[2, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Vertical_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[6, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[7, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Horizontal_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[8, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[6, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[7, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_1_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[8, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[4, 6]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[3, 7]));
    }

    [Test]
    public void TestTessaraFinder_Black_Diagonal_2_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[2, 8]));
    }

    [Test]
    public void TestTessaraFinder_Black_No_Tessera ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 4]));
    }
    #endregion

    #region White Tria Tests
    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Positon_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Positon_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Positon_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Positon_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Positon_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Positon_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Blocked_Space_Position_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Blocked_Space_Position_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Blocked_Space_Position_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Blocked_Space_Position_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Blocked_Space_Position_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Blocked_Space_Position_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;
        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_No_Space_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_1_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Vertical_With_Space_Position_2_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Positon_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Positon_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Positon_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Positon_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Positon_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Positon_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;

        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Blocked_Space_Position_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Blocked_Space_Position_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Blocked_Space_Position_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Blocked_Space_Position_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Blocked_Space_Position_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Blocked_Space_Position_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_No_Space_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_1_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Horizontal_With_Space_Position_2_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;

        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Positon_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Positon_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Positon_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Positon_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Positon_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Positon_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;

        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Blocked_Space_Position_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Blocked_Space_Position_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Blocked_Space_Position_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Blocked_Space_Position_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Blocked_Space_Position_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Blocked_Space_Position_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_No_Space_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[7, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_1_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[6, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_1_With_Space_Position_2_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[8, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;

        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Positon_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Positon_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Positon_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;

        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Positon_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Positon_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Positon_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;

        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Blocked_Space_Position_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Blocked_Space_Position_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Blocked_Space_Position_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Blocked_Space_Position_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Blocked_Space_Position_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Blocked_Space_Position_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_No_Space_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_Two_Blocked_Ends_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[5, 5];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_Two_Blocked_Ends_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[3, 7];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_1_Two_Blocked_Ends_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[4, 6];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }

    [Test]
    public void TestTriaFinder_White_Diagonal_2_With_Space_Position_2_One_Blocked_End_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;
        Node node2 = bm.nodes[2, 8];
        node2.color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TriaCreated (node2));
    }
    #endregion

    #region White Tessera Tests
    [Test]
    public void TestTesseraFinder_White_Vertical_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[4, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[3, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[2, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[4, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[3, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[2, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[6, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[7, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[8, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[4, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[3, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.TesseraCreated (bm.nodes[2, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Vertical_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[6, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[7, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Horizontal_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[8, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[6, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[7, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_1_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[8, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 5]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[4, 6]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[3, 7]));
    }

    [Test]
    public void TestTesseraFinder_White_Diagonal_2_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[2, 8]));
    }

    [Test]
    public void TestTesseraFinder_White_No_Tessera ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsFalse (bm.TesseraCreated (bm.nodes[5, 4]));
    }
    #endregion

    #region White Won Game Tests
    [Test]
    public void TestWonGame_White_Vertical_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Vertical_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 6]));
    }

    [Test]
    public void TestWonGame_White_Vertical_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 7]));
    }

    [Test]
    public void TestWonGame_White_Vertical_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 8]));
    }

    [Test]
    public void TestWonGame_White_Vertical_No_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 9]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_No_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 6]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 7]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 8]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_No_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 9]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[4, 6]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[3, 7]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[2, 8]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_No_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[1, 9]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 6]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 7]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 8]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_1_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 9]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_1_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 6]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 7]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 8]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_1_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 9]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[4, 6]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[3, 7]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[2, 8]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_1_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[1, 9]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 6]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 7]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 8]));
    }

    [Test]
    public void TestWonGame_White_Vertical_One_Block_Position_2_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 9]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_One_Block_Position_2_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 6]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 7]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 8]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_One_Block_Position_2_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 9]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[4, 6]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[3, 7]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[2, 8]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_One_Block_Position_2_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[1, 9]));
    }

    [Test]
    public void TestWonGame_White_Vertical_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Vertical_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 6]));
    }

    [Test]
    public void TestWonGame_White_Vertical_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 7]));
    }

    [Test]
    public void TestWonGame_White_Vertical_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 8]));
    }

    [Test]
    public void TestWonGame_White_Vertical_Two_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[5, 4].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 9]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 5]));
    }

    [Test]
    public void TestWonGame_White_Horizontal_Two_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 5].color = eColor.WHITE;
        bm.nodes[7, 5].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[9, 5].color = eColor.WHITE;
        bm.nodes[10, 5].color = eColor.BLACK;
        bm.nodes[4, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 6]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 7]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 8]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_1_Two_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[6, 6].color = eColor.WHITE;
        bm.nodes[7, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[9, 9].color = eColor.WHITE;
        bm.nodes[10, 10].color = eColor.BLACK;
        bm.nodes[4, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 9]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[4, 6]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[3, 7]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[2, 8]));
    }

    [Test]
    public void TestWonGame_White_Diagonal_2_Two_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[4, 6].color = eColor.WHITE;
        bm.nodes[3, 7].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[1, 9].color = eColor.WHITE;
        bm.nodes[0, 10].color = eColor.BLACK;
        bm.nodes[6, 4].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[1, 9]));
    }
    #endregion

    #region Black Won Game Tests
    [Test]
    public void TestWonGame_Black_Vertical_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 6]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 7]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 8]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_No_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 9]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_No_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 6]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 7]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 8]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_No_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 9]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_No_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_No_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[4, 6]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_No_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[3, 7]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_No_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[2, 8]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_No_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[1, 9]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 6]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 7]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 8]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_1_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 9]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_1_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 5].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 6]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 7]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 8]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_1_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[4, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 9]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_1_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_1_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[4, 6]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_1_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[3, 7]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_1_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[2, 8]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_1_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[6, 4].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[1, 9]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 6]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 7]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 8]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_One_Block_Position_2_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 9]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_One_Block_Position_2_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 6]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 7]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 8]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_One_Block_Position_2_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 9]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_2_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_2_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[4, 6]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_2_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[3, 7]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_2_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[2, 8]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_One_Block_Position_2_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[1, 9]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 6]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 7]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 8]));
    }

    [Test]
    public void TestWonGame_Black_Vertical_Two_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[5, 4].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 9]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 5]));
    }

    [Test]
    public void TestWonGame_Black_Horizontal_Two_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 5].color = eColor.BLACK;
        bm.nodes[7, 5].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[9, 5].color = eColor.BLACK;
        bm.nodes[10, 5].color = eColor.WHITE;
        bm.nodes[4, 5].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[6, 6]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[7, 7]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[8, 8]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_1_Two_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[6, 6].color = eColor.BLACK;
        bm.nodes[7, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[9, 9].color = eColor.BLACK;
        bm.nodes[10, 10].color = eColor.WHITE;
        bm.nodes[4, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[9, 9]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_Two_Blocks_Position_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[5, 5]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_Two_Blocks_Position_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[4, 6]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_Two_Blocks_Position_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[3, 7]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_Two_Blocks_Position_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[2, 8]));
    }

    [Test]
    public void TestWonGame_Black_Diagonal_2_Two_Blocks_Position_5 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[4, 6].color = eColor.BLACK;
        bm.nodes[3, 7].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[1, 9].color = eColor.BLACK;
        bm.nodes[0, 10].color = eColor.WHITE;
        bm.nodes[6, 4].color = eColor.WHITE;

        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue (bm.WonGame (bm.nodes[1, 9]));
    }
    #endregion

    #region White Capture Tests
    [Test] public void TestCapture_White_Vertical_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_White_Vertical_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Horizontal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_White_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_White_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_White_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_White_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_White_Vertical_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_White_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_White_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_White_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_White_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_White_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.WHITE;
        bm.nodes[5, 5].color = eColor.WHITE;
        bm.nodes[5, 6].color = eColor.BLACK;
        bm.nodes[5, 7].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.WHITE;
        bm.nodes[5, 10].color = eColor.BLACK;
        bm.nodes[5, 9].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.WHITE;
        bm.nodes[7, 8].color = eColor.BLACK;
        bm.nodes[6, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.BLACK;
        bm.nodes[3, 8].color = eColor.BLACK;
        bm.nodes[2, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.BLACK;
        bm.nodes[7, 6].color = eColor.BLACK;
        bm.nodes[8, 5].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.BLACK;
        bm.nodes[7, 10].color = eColor.BLACK;
        bm.nodes[8, 11].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.BLACK;
        bm.nodes[3, 10].color = eColor.BLACK;
        bm.nodes[2, 11].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.BLACK;
        bm.nodes[3, 6].color = eColor.BLACK;
        bm.nodes[2, 5].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 16);
    }
    #endregion

    #region Black Capture Tests

    [Test] public void TestCapture_Black_Vertical_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_Black_Vertical_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Horizontal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_Black_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 2);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_Black_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 4);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_Black_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 6);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_Black_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 8);
    }

    [Test] public void TestCapture_Black_Vertical_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_Black_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 10);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_Black_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 12);
    }

    [Test] public void TestCapture_Black_Vertical_1_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_Black_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 14);
    }

    [Test] public void TestCapture_Black_Vertical_1_Vertical_2_Horizontal_1_Horizontal_2_Diagonal_1_Diagonal_2_Diagonal_3_Diagonal_4 ()
    {
        BoardManager bm = new BoardManager ();
        bm.Init (19);
        bm.nodes[5, 8].color = eColor.BLACK;
        bm.nodes[5, 5].color = eColor.BLACK;
        bm.nodes[5, 6].color = eColor.WHITE;
        bm.nodes[5, 7].color = eColor.WHITE;
        bm.nodes[5, 11].color = eColor.BLACK;
        bm.nodes[5, 10].color = eColor.WHITE;
        bm.nodes[5, 9].color = eColor.WHITE;
        bm.nodes[8, 8].color = eColor.BLACK;
        bm.nodes[7, 8].color = eColor.WHITE;
        bm.nodes[6, 8].color = eColor.WHITE;
        bm.nodes[4, 8].color = eColor.WHITE;
        bm.nodes[3, 8].color = eColor.WHITE;
        bm.nodes[2, 8].color = eColor.BLACK;
        bm.nodes[6, 7].color = eColor.WHITE;
        bm.nodes[7, 6].color = eColor.WHITE;
        bm.nodes[8, 5].color = eColor.BLACK;
        bm.nodes[6, 9].color = eColor.WHITE;
        bm.nodes[7, 10].color = eColor.WHITE;
        bm.nodes[8, 11].color = eColor.BLACK;
        bm.nodes[4, 9].color = eColor.WHITE;
        bm.nodes[3, 10].color = eColor.WHITE;
        bm.nodes[2, 11].color = eColor.BLACK;
        bm.nodes[4, 7].color = eColor.WHITE;
        bm.nodes[3, 6].color = eColor.WHITE;
        bm.nodes[2, 5].color = eColor.BLACK;
        Assert.IsTrue (bm.FindCaptures (bm.nodes[5, 8]).Count == 16);
    }
    #endregion

    [Test]
    public void TestCaptureWin ()
    {

    }

    [Test]
    public void TestOverkillWin ()
    {

    }

    // // Test placement, black first move and tournament rule, piece on top of piece
    // [Test]
    // public void TestBlackFirstMove()
    // {
    //     BoardManager bm = new BoardManager();
    //     bm.Init(19);
    //     int center = 19 / 2;
    //     Node n = bm.GetNode(center, center);

    //     Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(center, center), eColor.BLACK));

    //     Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(1, 1), eColor.BLACK));
    // }

    // [Test]
    // public void TestBlackSecondMove()
    // {
    //     BoardManager bm = new BoardManager();
    //     bm.Init(19);
    //     int center = 19 / 2;

    //     Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 2, bm.GetNode(center +1, center-1), eColor.BLACK));

    //     Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 2, bm.GetNode(0, 0), eColor.BLACK));
    // }

    // [Test]
    // public void TestPiecePlacedOnPiece()
    // {
    //     BoardManager bm = new BoardManager();
    //     bm.Init(19);
    //     int center = 19 / 2;

    //     Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(center, center), eColor.BLACK));

    //     Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 1, bm.GetNode(center, center), eColor.WHITE));
    // }

    // [Test]
    // public void TestBlackMovesFirst()
    // {
    //     BoardManager bm = new BoardManager();
    //     bm.Init(19);

    //     Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 0, bm.GetNode(0, 0), eColor.WHITE));
    // }

}