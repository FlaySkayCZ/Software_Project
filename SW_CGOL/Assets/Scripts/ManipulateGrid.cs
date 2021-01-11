using UnityEngine;

public class ManipulateGrid : MonoBehaviour
{
    public static int rows = 43;
    public static int cols = 68;
    private float tileSize = 24;
    private bool happened = false;
    public GameObject AliveCell;
    public GameObject DeadCell;
    public bool[,] _states = new bool[rows, cols];

    private void Start()
    {
    }

    public int GridGenerate(bool[,] state)
    {
        if (happened == true)
        {
            foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                string objectName = gameObj.name.Split(':')[0];
                if (objectName == "Cell_Dead")
                {
                    Destroy(gameObj);
                }
                if (objectName == "Cell_Alive")
                {
                    Destroy(gameObj);
                }
            }
        }

        float gridX = GameObject.Find("GridManipulator").transform.position.x;
        float gridY = GameObject.Find("GridManipulator").transform.position.y;
        int savage = state.GetLength(0);
        int xaxa = state.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (state[i, j] == false)
                {
                    GameObject tile = (GameObject)Instantiate(DeadCell, transform);
                    float posX = gridX + j * tileSize + tileSize / 2 + 2;
                    float posY = gridY - i * tileSize - tileSize / 2 - 2;
                    tile.name = ("Cell_Dead:" + i + "." + j);
                    tile.transform.position = new Vector2(posX, posY);
                    tile.transform.SetParent(GameObject.Find("GridManipulator").transform);
                }
                else if (state[i, j] == true)
                {
                    GameObject tile = Instantiate(AliveCell, transform);

                    float posX = gridX + j * tileSize + tileSize / 2 + 2;
                    float posY = gridY - i * tileSize - tileSize / 2 - 2;
                    tile.name = ("Cell_Alive:" + i + "." + j);
                    tile.transform.position = new Vector2(posX, posY);
                    tile.transform.SetParent(GameObject.Find("GridManipulator").transform);
                }
            }
        }
        happened = true;
        return 1;
    }

    public static int countLiveNeighbors(int x, int y)
    {
        bool loopEdges = true;
        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
        // The number of live neighbors.
        int value = 0;

        // This nested loop enumerates the 9 cells in the specified cells neighborhood.
        for (var j = -1; j <= 1; j++)
        {
            //If loopEdges is set to false and y+j is off the board, continue.
            if (!loopEdges && y + j < 0 || y + j >= cols)
            {
                continue;
            }

            // Loop around the edges if y+j is off the board.
            int k = (y + j + cols) % cols;

            for (var i = -1; i <= 1; i++)
            {
                // If loopEdges is set to false and x+i is off the board, continue.
                if (!loopEdges && x + i < 0 || x + i >= rows)
                {
                    continue;
                }

                // Loop around the edges if x+i is off the board.
                int h = (x + i + rows) % rows;

                // Count the neighbor cell at (h,k) if it is alive.
                value += manipulateGrid._states[h, k] ? 1 : 0;
            }
            // Subtract 1 if (x,y) is alive since we counted it as a neighbor.
        }
        return value - (manipulateGrid._states[x, y] ? 1 : 0);
    }
}