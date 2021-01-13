using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LifeControls : MonoBehaviour
{
    /// <summary>
    /// Method that handles clicking on Cell
    /// If cell is alive clicking changes state to dead
    /// If cell is dead clicking changes state to alive
    /// </summary>
    public void OnClick()
    {
        string XY;
        int x, y;

        GameObject gameObject = GameObject.Find("GameObject");
        ManipulateGrid manipulateGrid = gameObject.GetComponent<ManipulateGrid>();

        XY = EventSystem.current.currentSelectedGameObject.name.Split(':')[1];
        x = Convert.ToInt32(XY.Split('.')[0]);
        y = Convert.ToInt32(XY.Split('.')[1]);

        if (manipulateGrid._states[x, y] == true)
            manipulateGrid._states[x, y] = false;
        else if (manipulateGrid._states[x, y] == false)
            manipulateGrid._states[x, y] = true;

        manipulateGrid.GridGenerate(manipulateGrid._states);
    }
}