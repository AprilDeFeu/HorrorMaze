using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    // Public variables
    public int mazeRows, mazeColumns;
    public GameObject wall;
    public GameObject floor;
    public float size = 2f;

    // Private variables
    private MazeCell[,] mazeCells;
    // Start is called before the first frame update
    void Start()
    {
        InitializeMaze ();
        Algorithm alg = new HuntKill (mazeCells);
        alg.CreateMaze ();
    }

    // Initialize the maze
    private void InitializeMaze() 
    {
        mazeCells = new MazeCell[mazeRows, mazeColumns];

        // Iterate maze rows
        for (int row = 0; row < mazeRows; row++) 
        {
            // Iterate maze columns
            for (int col = 0; col < mazeColumns; col++)
            {

                // Set maze cell for every element in maze matrix
                mazeCells[row, col] = new MazeCell ();

                // Instantiate floor
                mazeCells[row, col].floor = Instantiate(floor, new Vector3 (row * size, -(size/2f), col*size), Quaternion.identity);
                mazeCells[row, col].floor.transform.parent = this.transform;
                mazeCells[row, col].floor.name = "Floor " + row + ", " + col;
                

                // Instantiate West wall
                if (col == 0) {
                    mazeCells[row, col].wWall = Instantiate(wall, new Vector3(row*size, 12, (col*size) - (size/2f)), Quaternion.identity);
                    mazeCells[row, col].wWall.transform.parent = this.transform;
                    mazeCells[row, col].wWall.name = "West Wall " + row + ", " + col;
                }
                // Instantiate East wall
                mazeCells[row, col].eWall = Instantiate(wall, new Vector3(row*size, 12, (col*size) + (size/2f)), Quaternion.identity);
                mazeCells[row, col].eWall.transform.parent = this.transform;
                mazeCells[row, col].eWall.name = "East Wall " + row + ", " + col;
                
                // Instantiate North wall
                if (row == 0) {
                    mazeCells[row, col].nWall = Instantiate(wall, new Vector3((row*size) - (size/2f), 12, col*size), Quaternion.identity);
                    mazeCells[row, col].nWall.transform.parent = this.transform;
                    mazeCells[row, col].nWall.name = "North Wall " + row + ", " + col;
                    mazeCells[row, col].nWall.transform.Rotate (Vector3.up * 90f);
                }

                // Instantiate South wall
                mazeCells[row, col].sWall = Instantiate(wall, new Vector3((row*size) + (size/2f), 12, col*size), Quaternion.identity);
                mazeCells[row, col].sWall.transform.parent = this.transform;
                mazeCells[row, col].sWall.name = "South Wall " + row + ", " + col;
                mazeCells[row, col].sWall.transform.Rotate (Vector3.up * 90f);
            }
        }
    }
}
