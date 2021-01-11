using System.Collections;
using TMPro;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public bool SimRun = false;
    private int Done;

    public void onClick()
    {
        if (SimRun == false)
        {
            GameObject.Find("Button_Play").GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
            StartCoroutine(Wait());
            SimRun = true;
        }
        else if (SimRun == true)
        {
            GameObject.Find("Button_Play").GetComponentInChildren<TextMeshProUGUI>().text = "Play";
            StopCoroutine(Wait());
            SimRun = false;
        }
    }

    private IEnumerator Wait()
    {
        do
        {
            GameObject gameObject = GameObject.Find("GameObject");
            ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
            bool[,] newBoard = new bool[ManipulateGrid.rows, ManipulateGrid.cols];
            for (int row = 0; row < ManipulateGrid.rows; row++)
            {
                for (int col = 0; col < ManipulateGrid.cols; col++)
                {
                    var n = ManipulateGrid.countLiveNeighbors(row, col);
                    var c = manipulateGrid._states[row, col];
                    newBoard[row, col] = c && (n == 2 || n == 3) || !c && n == 3;
                }
            }
            for (int row = 0; row < ManipulateGrid.rows; row++)
            {
                for (int col = 0; col < ManipulateGrid.cols; col++)
                {
                    manipulateGrid._states[row, col] = newBoard[row, col];
                }
            }

            Done = manipulateGrid.GridGenerate(manipulateGrid._states);
            yield return new WaitUntil(() => Done == 1);

            Done = 0;
        } while (SimRun == true);
    }
}