using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Tile
{
    private void Update()
    {
        if (isClicked && isClickable && !gameManager.isStormHappened)
        {
            gameManager.isStormHappened = true;
            checker.hole++;
        }
    }
}
