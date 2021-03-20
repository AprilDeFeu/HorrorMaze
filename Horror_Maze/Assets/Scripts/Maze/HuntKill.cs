using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implementing Hunt & Kill Algorithm
public class HuntKill : Algorithm
{
    private int currentRow = 0;
    private int currentCol = 0;
    private bool finished=false;

    public HuntKill(MazeCell[,] mazeCells) : base(mazeCells)
    {
    }

    public override void CreateMaze()
    {
        HuntAndKill ();
    }

    // Check if there is an available route from the current cell
    private bool RouteStillAvailable (int row, int col) 
    {
        int availableRoutes = 0;
        if (    row > 0 && !mazeCells[row-1, col].visited) availableRoutes++;
        if (    col > 0 && !mazeCells[row, col-1].visited) availableRoutes++;   
        if (    row < mazeRows - 1 && !mazeCells[row+1,col].visited ) availableRoutes++;
        if (    col < mazeColumns - 1 && !mazeCells[row,col+1].visited ) availableRoutes++;
            return availableRoutes > 0;
    }
    // Check if an indexed cell is available
    private bool CellIsAvailable(int row, int col)
    {
        if (row >= 0 && row < mazeRows && col >= 0 && col < mazeColumns && !mazeCells[row, col].visited) return true;
        else return false;
    }

    // Check if an adjacent cell is visited
    private bool AdjcacentCellVisited(int row, int col)
    {
        int visitedCells = 0;
        if (row > 0 && mazeCells[row-1, col].visited) visitedCells++;
        if (row < (mazeRows-2) && mazeCells[row+1, col].visited) visitedCells++;
        if (col > 0 && mazeCells[row, col-1].visited) visitedCells++;
        if (col < (mazeColumns-2) && mazeCells[row, col+1].visited) visitedCells++;
        return visitedCells > 0;
    }
    

    // Destroy a wall object
    private void WallDestroyer(GameObject wall)
    {
        if (wall != null)
        {
            GameObject.Destroy (wall);
        }
    }

    // Destroy adjacent walls
    private void AdjacentWallDestroyer(int row, int col)
    {
        bool destroyed = false;

        while (!destroyed)
        {
            int direction = Random.Range(1,5);

            if (direction == 1 && row > 0 && mazeCells [row-1, col].visited)
            {
                WallDestroyer(mazeCells[row, col].nWall);
                WallDestroyer(mazeCells[row-1, col].sWall);
                destroyed = true;
            } else if (direction == 2 && row < (mazeRows - 2) && mazeCells[row+1, col].visited)
            {
                WallDestroyer(mazeCells[row, col].sWall);
                WallDestroyer(mazeCells[row+1, col].nWall);
                destroyed = true;
            } else if (direction == 3 && col > 0 && mazeCells[row, col-1].visited)
            {
                WallDestroyer(mazeCells[row, col].wWall);
                WallDestroyer(mazeCells[row, col-1].eWall);
                destroyed = true;
            } else if (direction == 4 && col < (mazeColumns - 2) && mazeCells[row, col+1].visited)
            {
                WallDestroyer(mazeCells[row, col].eWall);
                WallDestroyer(mazeCells[row, col+1].wWall);
                destroyed = true;
            }
        }
    }
    // Hunt and Kill implementation
    private void HuntAndKill() 
    {
        // Mark cell as visited
        mazeCells[currentRow, currentCol].visited = true;
        while (! finished)
        {
            Kill(); // Random walk until it hits a dead end.
            Hunt(); // Hunts for next unvisited cell with an adjacent visited cell.
            // Marks 'finished' as true if no more unvisited cells are found.

        }
    }

    private void Hunt () 
    {
        finished = true;
        for (int rows = 0; rows < mazeRows; rows++) 
        {
            for (int cols = 0; cols < mazeColumns; cols++)
            {
                if (!mazeCells[rows, cols].visited && AdjcacentCellVisited(rows, cols)) 
                {
                    finished = false;
                    currentRow = rows;
                    currentCol = cols;
                    AdjacentWallDestroyer(currentRow, currentCol); 
                    mazeCells [currentRow, currentCol].visited = true;
                    return;
                }
            }
        }    
    }
    private void Kill()
    {
        while (RouteStillAvailable (currentRow, currentCol)) 
        {
            int direction = Random.Range(1,5);
            
            if (direction == 1 && CellIsAvailable (currentRow - 1, currentCol)) 
            // Kill North
            { 
                WallDestroyer(mazeCells[currentRow, currentCol].nWall);
                WallDestroyer(mazeCells[currentRow - 1, currentCol].sWall);
                currentRow --;
            } else if (direction == 2 && CellIsAvailable (currentRow + 1, currentCol))
            // Kill South
            {
                WallDestroyer(mazeCells[currentRow, currentCol].sWall);
                WallDestroyer(mazeCells[currentRow + 1, currentCol].nWall);
                currentRow ++;
            } else if (direction == 3 && CellIsAvailable (currentRow, currentCol + 1))
            // Kill East
            {
                WallDestroyer(mazeCells[currentRow, currentCol].eWall);
                WallDestroyer(mazeCells[currentRow, currentCol + 1].wWall);
                currentCol ++;
            }  else if (direction == 4 && CellIsAvailable (currentRow, currentCol - 1))
            // Kill East
            {
                WallDestroyer(mazeCells[currentRow, currentCol].wWall);
                WallDestroyer(mazeCells[currentRow, currentCol - 1].eWall);
                currentCol --;
            }
            mazeCells[currentRow, currentCol].visited = true;
        }
    }
}
