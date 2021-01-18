using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Script : MonoBehaviour
{
    public GameObject AliveCell;
    public GameObject DeadCell;

    /// <summary>
    /// Method that handles transition to game screen.
    /// /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Method that calls Options menu.
    /// Opening is set up in Unity.
    /// </summary>
    public void OptionsMenu()
    {
        Debug.Log("Application opened options...");
    }

    public Dropdown Dropdown_color;

    /// <summary>
    /// Method that handles changing color to Cells.
    /// </summary>
    public void ChangeColor()
    {
        switch (Dropdown_color.value)
        {
            case 0:
                var ColorWhite = AliveCell.GetComponent<Image>();
                Color white = new Color();
                white.r = 255;
                white.g = 255;
                white.b = 255;
                white.a = 1;
                ColorWhite.color = white;
                break;

            case 1:
                var ColorRed = AliveCell.GetComponent<Image>();
                Color red = new Color();
                red.r = 255;
                red.g = 0;
                red.b = 0;
                red.a = 1;
                ColorRed.color = red;
                break;

            case 2:
                var ColorBlue = AliveCell.GetComponent<Image>();
                Color blue = new Color();
                blue.r = 0;
                blue.g = 0;
                blue.b = 255;
                blue.a = 1;
                ColorBlue.color = blue;
                break;
        };
    }

    /// <summary>
    /// Method that handles closing the application.
    /// !Only works in builded version.
    /// For editor there is Log Message.
    /// </summary>
    public void Quit()
    {
        Debug.Log("Application is closing...");
        Application.Quit();
    }
}