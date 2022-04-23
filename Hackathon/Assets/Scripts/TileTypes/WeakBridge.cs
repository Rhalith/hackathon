using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBridge : Tile
{
    private void Update()
    {
        if (isClicked && isOneTimeUse && isClickable)
        {
            isClickable = false;
        }
    }
}
