# HorrorMaze
An early development build of a horror-themed maze game. It uses OOP to decide what algorithm to use to build a maze. Currently, the game has one algorithm but will be updated with several more. Further on ahead, there are plans to implement enemy AI.

- [x] The **Hunt-and-Kill** DFS algorithm will work on any rectangular _n x m_ grid of connected, unvisited nodes represented as cells. Assuming each cell in the grid has 4 adjacent walls, the algorithm will begin with a single cell, marking it as visited. It will randomly choose one neighbouring cell which is unvisited, and will 'kill' the walls between that cell and the current one, moving onto this newly visited cell to continue. This 'kill' phase will repeat until no unvisited neighbours remain around the current cell. Once that condition is met, the algorithm enters the 'hunt' phase to find an unvisited cell that neighbours some visited cell. Once said cell is found, the algorithm switches to the 'Kill' phase again and repeats untill all cells are visited.
The nature of this algorithm is based upon 'recursive backtracking', albeit applied with randomness to generate slightly more intersections and dead ends.
- [ ] **Recursive Backtracking** (TODO)
- [ ] **Kruskal's** (TODO)
- [ ] **Aldous-Broder** (TODO)
- [ ] **Wilson's Algorithm** (TODO)
- [ ] **"Blobby" Recursive Subdivision Algorithm** (TODO)
- [ ] **Enemies** (TODO) 

Music is done by me as well.
