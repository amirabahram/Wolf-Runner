using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] obstacles;
    [SerializeField]
    List<GameObject> obs = new List<GameObject> ();
    private void Awake()
    {
        Shuffle();

    }

    private void Start()
    {
        StartCoroutine(CreateObstacle());
    }
    void Shuffle()
    {

        for (int i = 0; i < obstacles.Length*3; i++)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            GameObject obj = Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity) as GameObject;
            obj.SetActive(false);
            obs.Add(obj);
        }
    }
    IEnumerator CreateObstacle()
    {
        yield return new WaitForSeconds(4);
        var index = Random.Range(0, obs.Count);
        while (true)
        {
            if (!obs[index].activeInHierarchy)
            {
                obs[index].SetActive(true);
                obs[index].transform.position = new Vector3(transform.position.x,
                    transform.position.y, 0);
             
                break;
            }
            else
            {
                index = Random.Range(0, obs.Count);
            }
        }

        
        StartCoroutine(CreateObstacle());
    }
}
