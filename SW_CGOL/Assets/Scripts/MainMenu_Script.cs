using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Script : MonoBehaviour
{
    public GameObject AliveCell;
    public GameObject DeadCell;
    /// <summary>
    /// Method that handles transition to game screen
    /// /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    /// <summary>
    /// Method that calls Options menu
    /// Opening is set up in Unity 
    /// </summary>
    public void OptionsMenu()
    {
        Debug.Log("Application opened options...");
    }
    /// <summary>
    /// Method that handles changing color to Cells
    /// 
    /// </summary>
    public Dropdown Dropdown_color;
    public void ChangeColor()
    {
        switch (Dropdown_color.value)
        {
            case 0:
                var ColorWhite = AliveCell.GetComponent<Color>();
                ColorWhite.r = 255;
                ColorWhite.g = 0;
                ColorWhite.b = 0;
                ColorWhite.a = 1;
                Debug.Log("Red");
                break;

            case 1:
                var ColorRed = AliveCell.GetComponent<Color>();
                ColorRed.r = 255;
                ColorRed.g = 0;
                ColorRed.b = 0;
                ColorRed.a = 1;
                Debug.Log("Red");
                break;

            case 2:
                AliveCell.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
                Debug.Log("Blue");
                var ColorBlue = AliveCell.GetComponent<Color>();
                ColorBlue.r = 0;
                ColorBlue.g = 0;
                ColorBlue.b = 255;
                ColorBlue.a = 1;
                break;
        };
    }
    /// <summary>
    /// Method that handles closing the application
    /// !Only works in builded version 
    /// For editor there is Log Message
    /// </summary>
    public void Quit()
    {
        Debug.Log("Application is closing...");
        Application.Quit();
    }
}