using System.Runtime.CompilerServices;
using UnityEngine;

public class brickSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject brick;
    public LogicScript logic;
    void Start()
    {
        spawnBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnBricks()
    {
        float positionX = 1.1f;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 2; j < 5; j++)
            {
                Instantiate(brick, new Vector3((transform.position.x - positionX * i) + 0.55f, j, 0), transform.rotation);
                Instantiate(brick, new Vector3(transform.position.x + positionX * i - 0.55f, j, 0), transform.rotation);
            }
        }
    }
}
