using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpplayer : MonoBehaviour
{
    Vector2 lastClickedpos;

    bool moving;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            lastClickedpos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving= true;
        }

        if((moving && (Vector2)transform.position != lastClickedpos))
        {
            transform.position = new Vector2(lastClickedpos.x, lastClickedpos.y);
        }
        else
        {
            moving= false;
        }
    }
    
}
