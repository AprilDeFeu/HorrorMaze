using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Algorithm 
{
    // OOP implementation of algorithm class.
    // This allows us to design and use different
    // maze algorithms on the same framework.
    protected MazeCell[,] mazeCells;
    protected int mazeRows, mazeColumns;
    protected Algorithm(MazeCell[,] mazeCells) : base() 
    {
        this.mazeCells = mazeCells;
        mazeRows = mazeCells.GetLength(0);
        mazeColumns = mazeCells.GetLength(1);
    }

    public abstract void CreateMaze ();
}
