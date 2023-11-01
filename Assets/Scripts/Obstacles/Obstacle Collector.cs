using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollector : MonoBehaviour
{
    public delegate void PlayerDied(bool isEvent);
    public static event PlayerDied OnPlayerDied;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag!="ground" && collision.gameObject.tag=="Player")
        {
            Destroy(collision.gameObject);
            if(OnPlayerDied != null) OnPlayerDied(true);
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            collision.gameObject.SetActive(false);
        }

    }
}
