using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{

    void Start()
    {
       var hieght = Camera.main.orthographicSize*2f;
       var width = hieght * Screen.width/Screen.height;

        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector3(width, hieght, 0);
        }
        else
        {
            transform.localScale = new Vector3(width + 3f, 6, 0);
        }
    }

}
