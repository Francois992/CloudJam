using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject horsePrefab;
    public Transform[] horseSpawnLocation;

    public GameObject slowTrap;
    public GameObject obstacle;
    [SerializeField, Range(0, 100)] private float chanceForObstacleToSpawn = 50f;
    public float timeBetweenObstacles = 3f;


    private List<float> ySpawnLocation = new List<float>();
    private List<float> timers = new List<float>();

    private Transform spawnObstable;

    private void Start()
    {
        spawnObstable = Camera.main.transform.GetChild(1).transform;

        foreach (Transform transform in horseSpawnLocation)
        {
            Octopus horse = Instantiate(horsePrefab, transform).GetComponent<Octopus>();
            horse.HorseCanRun(true);
            ySpawnLocation.Add(transform.position.y);
            timers.Add(Random.Range(0f, timeBetweenObstacles));
        }
    }

    private void Update()
    {
        for (int i = 0; i < timers.Count; ++i)
        {
            timers[i] += Time.deltaTime;

            if (timers[i] > timeBetweenObstacles)
            {
                SpawnObstacle(i);
                timers[i] = 0f;
            }
        }
    }

    private void SpawnObstacle(int i)
    {
        GameObject toSpawn = null;

        if (100 * Random.value > chanceForObstacleToSpawn)
        {
            if (Random.value > 0.5f)
            {
                toSpawn = slowTrap;
            }
            else
            {
                toSpawn = obstacle;
            }

            Instantiate(toSpawn);
            
            Vector2 newPos = spawnObstable.transform.position;
            newPos.x += 1;
            newPos.y = ySpawnLocation[i];
            toSpawn.transform.position = newPos;
        }
    }
}
