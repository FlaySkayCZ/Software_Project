# Software_Project

### Conway´s Game of Life

Explanation of Conway´s game of life can be found on
[Link for wikipedia article](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)

Basic are also provided bellow - copied and with (mostly)bad comments 
Cell itself doesn't count for its following state


# Rules
##### For Alive cells rules are:

1. Any live cell with fewer than two live neighbours dies, as if by underpopulation. 
  * 1 Neigbour = death

2. Any live cell with two or three live neighbours lives on to the next generation.
  * 2 Neigbours = Life
  * 3 Neigbours = Life

3. Any live cell with more than three live neighbours dies, as if by overpopulation.
  * 4 to 8 Neigbours = Death


##### For Death cells rules are:

4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

  * 3 Neigbours = Life
  * Anything else stayes dead


# Folder tree
```
Software_Project
|   
+---Build
|   |   SW_CGOL.exe     .exe file to play game on windows machines
|   
\---SW_CGOL   
    \---Assets          Folder with all assets
        |   
        +---Cells       Folder with prefabs for cells
        |       
        +---Images      Folder with images for different backgrounds
        |       
        +---Scenes      Folder with both scenes which are shown in game
        |       
        \---Scripts     Folder with scripts
```
