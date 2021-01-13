using System.Collections;
using TMPro;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public bool SimRun = false;
    private int loopHappened;
    /// <summary>
    /// Method that handles starting and stopping the game
    /// It changes own text depending on state of game
    /// Then starts coroutine to start game
    /// </summary>
    public void onClick()
    {
        if (SimRun == false)
        {
            GameObject.Find("Button_Play").GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
            StartCoroutine(PlayLoop());
            SimRun = true;
        }
        else if (SimRun == true)
        {
            GameObject.Find("Button_Play").GetComponentInChildren<TextMeshProUGUI>().text = "Play";
            StopCoroutine(PlayLoop());
            SimRun = false;
        }
    }
    /// <summary>
    /// Coroutine for running game in sence it doesnt skip a frame or doesnt run faster then it is shown on screen
    /// allways waits for itself to finish
    /// 
    /// </summary>
    private IEnumerator PlayLoop()
    {
        //does until coroutine stops
        do
        {

        
            GameObject gameObject = GameObject.Find("GameObject");
            ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();
            //Creates newBoard which is copy of shown board so it doesnt mess with calculation when i am assinging new values
            bool[,] newBoard = new bool[ManipulateGrid.rows, ManipulateGrid.cols];
            //Nested loop that goes thru all cells and assigns to numberOfNeigbours its number of neighbours and to C its state
            for (int row = 0; row < ManipulateGrid.rows; row++)
            {
                for (int col = 0; col < ManipulateGrid.cols; col++)
                {
                    var numberOfNeigbours = ManipulateGrid.countLiveNeighbors(row, col);
                    var currentState = manipulateGrid._states[row, col];
                    //if currentState on newBoard[row, col] is true and it has 2 or 3 live neigbors it stayes true(alive)
                    //or currentState on newBoard[row, col] is false and it has 3 neigbours it becomes negate of its state therefore true(alive)
                    newBoard[row, col] = currentState && (numberOfNeigbours == 2 || numberOfNeigbours == 3) || !currentState && numberOfNeigbours == 3;
                }
            }
            //Assigns rest unaffected cells to now new board
            for (int row = 0; row < ManipulateGrid.rows; row++)
            {
                for (int col = 0; col < ManipulateGrid.cols; col++)
                {
                    manipulateGrid._states[row, col] = newBoard[row, col];
                }
            }
            //May be needed. Testing required.
            //loopHappened = manipulateGrid.GridGenerate(manipulateGrid._states);
            // Here it waits until generation metod returns 1 
            yield return new WaitUntil(() => manipulateGrid.GridGenerate(manipulateGrid._states) == 1);
            //May be needed. Testing required.
            //loopHappened = 0;
        } while (SimRun == true);
    }
}