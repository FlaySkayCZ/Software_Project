using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu_Script : MonoBehaviour
{
    /// <summary>
    /// Method that handles returning to menu.
    /// On click it moves us to previous Scene.
    /// We move to previous and not to specific cene because it is better practise.
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// Method that handles creating empty grid.
    /// </summary>
    public void Generate()
    {
        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
        manipulateGrid.GridGenerate(CleanPlane(), ChangeAllToTrue());
    }

    /// <summary>
    /// Method that cleans array and sets every cell to empty.
    /// </summary>
    /// <returns>CleanState is empty grid.</returns>
    private bool[,] CleanPlane()
    {
        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
        bool[,] CleanState = new bool[ManipulateGrid.rows, ManipulateGrid.cols];
        for (int row = 0; row < ManipulateGrid.rows; row++)
        {
            for (int col = 0; col < ManipulateGrid.cols; col++)
            {
                manipulateGrid._states[row, col] = false;
            }
        }
        return CleanState;
    }

    public Dropdown menu_Dropdown;

    /// <summary>
    /// Method that handles loading presets from dropdown menu..
    /// First we load grid script and then we simply check which case is selected and send preconfigured array for gereration.
    /// </summary>
    public void loadPreset()
    {
        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();

        switch (menu_Dropdown.value)
        {
            case 0:
                manipulateGrid.GridGenerate(Cloverleaf(), ChangeAllToTrue());
                break;

            case 1:
                manipulateGrid.GridGenerate(GliderSet(), ChangeAllToTrue());
                break;

            case 2:
                manipulateGrid.GridGenerate(SmileySet(), ChangeAllToTrue());
                break;
        };
    }

    /// <summary>
    /// Method that stores data for so-called Cloverleaf which repeats itself.
    /// </summary>
    /// <returns>Returns filled array.</returns>
    private bool[,] Cloverleaf()
    {
        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
        bool[,] Preset1 = new bool[ManipulateGrid.rows, ManipulateGrid.cols];
        for (int row = 0; row < ManipulateGrid.rows; row++)
        {
            for (int col = 0; col < ManipulateGrid.cols; col++)
            {
                manipulateGrid._states[row, col] = false;
            }
        }
        manipulateGrid._states[13, 30] = true;
        manipulateGrid._states[13, 32] = true;
        manipulateGrid._states[14, 28] = true;
        manipulateGrid._states[14, 29] = true;
        manipulateGrid._states[14, 30] = true;
        manipulateGrid._states[14, 32] = true;
        manipulateGrid._states[14, 33] = true;
        manipulateGrid._states[14, 34] = true;
        manipulateGrid._states[15, 27] = true;
        manipulateGrid._states[15, 31] = true;
        manipulateGrid._states[15, 35] = true;
        manipulateGrid._states[16, 27] = true;
        manipulateGrid._states[16, 29] = true;
        manipulateGrid._states[16, 33] = true;
        manipulateGrid._states[16, 35] = true;
        manipulateGrid._states[17, 28] = true;
        manipulateGrid._states[17, 29] = true;
        manipulateGrid._states[17, 31] = true;
        manipulateGrid._states[17, 33] = true;
        manipulateGrid._states[17, 34] = true;
        manipulateGrid._states[19, 28] = true;
        manipulateGrid._states[19, 29] = true;
        manipulateGrid._states[19, 31] = true;
        manipulateGrid._states[19, 33] = true;
        manipulateGrid._states[19, 34] = true;
        manipulateGrid._states[20, 27] = true;
        manipulateGrid._states[20, 29] = true;
        manipulateGrid._states[20, 33] = true;
        manipulateGrid._states[20, 35] = true;
        manipulateGrid._states[21, 27] = true;
        manipulateGrid._states[21, 31] = true;
        manipulateGrid._states[21, 35] = true;
        manipulateGrid._states[22, 28] = true;
        manipulateGrid._states[22, 29] = true;
        manipulateGrid._states[22, 30] = true;
        manipulateGrid._states[22, 32] = true;
        manipulateGrid._states[22, 33] = true;
        manipulateGrid._states[22, 34] = true;
        manipulateGrid._states[23, 30] = true;
        manipulateGrid._states[23, 32] = true;
        return manipulateGrid._states;
    }

    /// <summary>
    /// Method that stores data for four so-called gliders which fly to two coliding spaces and create self sustaining 2x2 squares.
    /// </summary>
    /// <returns>Returns filled array.</returns>
    private bool[,] GliderSet()
    {
        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
        bool[,] Preset1 = new bool[ManipulateGrid.rows, ManipulateGrid.cols];
        for (int row = 0; row < ManipulateGrid.rows; row++)
        {
            for (int col = 0; col < ManipulateGrid.cols; col++)
            {
                manipulateGrid._states[row, col] = false;
            }
        }
        manipulateGrid._states[1, 2] = true;
        manipulateGrid._states[1, 65] = true;
        manipulateGrid._states[2, 3] = true;
        manipulateGrid._states[2, 64] = true;
        manipulateGrid._states[3, 1] = true;
        manipulateGrid._states[3, 2] = true;
        manipulateGrid._states[3, 3] = true;
        manipulateGrid._states[3, 64] = true;
        manipulateGrid._states[3, 65] = true;
        manipulateGrid._states[3, 66] = true;
        manipulateGrid._states[39, 1] = true;
        manipulateGrid._states[39, 2] = true;
        manipulateGrid._states[39, 3] = true;
        manipulateGrid._states[39, 64] = true;
        manipulateGrid._states[39, 65] = true;
        manipulateGrid._states[39, 66] = true;
        manipulateGrid._states[40, 3] = true;
        manipulateGrid._states[40, 64] = true;
        manipulateGrid._states[41, 2] = true;
        manipulateGrid._states[41, 65] = true;
        return manipulateGrid._states;
    }

    /// <summary>
    ///  Method that stores data for Smiley Face which is pretty neat. After 32 iterations it changes to flower which repeaits itself in 3 iteration cycle.
    /// </summary>
    /// <returns>Returns filled array.</returns>
    public bool[,] SmileySet()
    {
        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
        bool[,] Preset1 = new bool[ManipulateGrid.rows, ManipulateGrid.cols];
        for (int row = 0; row < ManipulateGrid.rows; row++)
        {
            for (int col = 0; col < ManipulateGrid.cols; col++)
            {
                manipulateGrid._states[row, col] = false;
            }
        }
        manipulateGrid._states[19, 27] = true;
        manipulateGrid._states[19, 29] = true;
        manipulateGrid._states[20, 27] = true;
        manipulateGrid._states[20, 29] = true;
        manipulateGrid._states[21, 25] = true;
        manipulateGrid._states[21, 31] = true;
        manipulateGrid._states[22, 26] = true;
        manipulateGrid._states[22, 27] = true;
        manipulateGrid._states[22, 28] = true;
        manipulateGrid._states[22, 29] = true;
        manipulateGrid._states[22, 30] = true;

        return manipulateGrid._states;
    }

    /// <summary>
    /// Creates a 2Darray which is set to true on all positions.
    /// </summary>
    /// <returns>2D Boolean array which is TRUE.</returns>
    private bool[,] ChangeAllToTrue()
    {
        bool[,] changes = new bool[ManipulateGrid.rows, ManipulateGrid.cols];
        for (int x = 0; x < ManipulateGrid.rows; x++)
        {
            for (int y = 0; y < ManipulateGrid.cols; y++)
            {
                changes.SetValue(true, x, y);
            }
        }
        return changes;
    }
}