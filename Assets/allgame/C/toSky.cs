using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toSky : MonoBehaviour
{
    public float x = -1.897f;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D next)
    {

        if (next.gameObject.tag == "deathZone")
        {
            //gameObject.transform = new Vector2(-1.89f, -0.62f);

            gameObject.transform.position = new Vector2(x, 1.85f);
        }
    }
}
