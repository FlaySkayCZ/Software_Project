using UnityEngine;

public class ManipulateGrid : MonoBehaviour
{
    // Variable "rows">Number of rows.
    // Variable "cols">Number of cols.
    // Variable "tileSize">Size of cell.
    // Variable "happened">Checks if it is first load.
    // Variable "AliveCell">Game object of Alive cell prefab.
    // Variable "DeadCell">Game object of Dead cell prefab.
    // Variable "_states">Board array in [rows,cols] = State of cell .
    public static int rows = 43;

    public static int cols = 68;
    private float tileSize = 24;
    private bool happened = false;
    public GameObject AliveCell;
    public GameObject DeadCell;
    public bool[,] _states = new bool[rows, cols];

    /// <summary>
    /// Method that destroys board on changed tiles and creates new ones.
    /// </summary>
    /// <param name="state">Array which shows how the board should look like in next iteration.</param>
    /// <param name="changes">Array which sayes which cells should be changed. Which is basically last and next iteration combined.</param>
    /// <returns></returns>
    public int GridGenerate(bool[,] state, bool[,] changes)
    {
        // Destroys cells which change.
        // Nested loop that goes thru changes and if is true it deletes the cell that will change.
        // Happened is here if first generation allready happeden. Else it would destroy non existent cells on MASS and that causes troubles.
        if (happened == true)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (changes[i, j] == true)
                    {
                        Destroy(GameObject.Find("Cell_Dead:" + i + "." + j));
                        Destroy(GameObject.Find("Cell_Alive:" + i + "." + j));
                    }
                }
            }
        }
        // Checks for position of GridManipulator which is same as board - Is for calculating starting position, so it doesnt matter how we position the board.
        // Board as refered ^^ is GameObject called Panel under which is GridManipulator which holds cells and this script.
        float gridX = GameObject.Find("GridManipulator").transform.position.x;
        float gridY = GameObject.Find("GridManipulator").transform.position.y;
        //Nested loop which creates  dead or alive cells
        //State of cells depends on bool value of array with X and Y pos of cell
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (changes[i, j] == true)
                {
                    if (state[i, j] == false)
                    {
                        GameObject tile = (GameObject)Instantiate(DeadCell, transform);
                        // posX & posY are calculated position of next cell to generate.
                        // gridX/gridY is posiiton of board on screen.
                        // i/j are number of position of cell.
                        // We need to subtract i from position because our starting position on board is top left.
                        // tileSize is size of cell by how much we need to move it.
                        // We ofset the positions by 1/2 of tile size because cells are generated in center of grid and we want create them form left top corner.
                        // Magical values of +2 or -2 on end of equation are for offseting whole grid and making it look nicer - not mandatory.
                        float posX = gridX + j * tileSize + tileSize / 2 + 2;
                        float posY = gridY - i * tileSize - tileSize / 2 - 2;
                        // tile. is assigning various parameters.
                        tile.name = ("Cell_Dead:" + i + "." + j);
                        tile.transform.position = new Vector2(posX, posY);
                        tile.transform.SetParent(GameObject.Find("GridManipulator").transform);
                    }
                    else if (state[i, j] == true)
                    {
                        // Same as above.
                        GameObject tile = Instantiate(AliveCell, transform);
                        float posX = gridX + j * tileSize + tileSize / 2 + 2;
                        float posY = gridY - i * tileSize - tileSize / 2 - 2;
                        tile.name = ("Cell_Alive:" + i + "." + j);
                        tile.transform.position = new Vector2(posX, posY);
                        tile.transform.SetParent(GameObject.Find("GridManipulator").transform);
                    }
                }
            }
        }

        happened = true;
        // returns one because in Simulation.cs private IEnumerator PlayLoop() waits for 1 so it can loop itself,
        // and doesnt frame skip.
        return 1;
    }

    /// <summary>
    /// Method which counts alive neighbours on board
    /// </summary>
    /// <param name="x">Place in array/board</param>
    /// <param name="y">Place in array/board</param>
    /// <returns>Returns number of alive neighbours and evaluates next state</returns>
    public static int countLiveNeighbors(int x, int y)
    {
        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
        // Amount of alive neigbours
        int numberOfNeigbors = 0;
        // If we thnik about board looping around itself
        bool loopEdges = true;
        for (var j = -1; j <= 1; j++)
        {
            if (!loopEdges && y + j < 0 || y + j >= cols)
            {
                continue;
            }
            int k = (y + j + cols) % cols;
            for (var i = -1; i <= 1; i++)
            {
                if (!loopEdges && x + i < 0 || x + i >= rows)
                {
                    continue;
                }
                int h = (x + i + rows) % rows;

                numberOfNeigbors += manipulateGrid._states[h, k] ? 1 : 0;
            }
        }
        return numberOfNeigbors - (manipulateGrid._states[x, y] ? 1 : 0);
    }
}