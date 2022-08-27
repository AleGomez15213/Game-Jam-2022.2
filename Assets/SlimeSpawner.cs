using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slimePrefab;
    private bool shouldSpawn;

    public BoxCollider spawnArea;
    private float xMinBound;
    private float xMaxBound;
    private float yMinBound;
    private float yMaxBound;

    public float intervalInSeconds;

    public int maxSlimes = 10;
    private int slimes;

    private void OnEnable() => GetComponent<StageManager>().timeUpEvent += StartSpawning;
    private void OnDisable() => GetComponent<StageManager>().timeUpEvent -= StopSpawning;

    private void StartSpawning() => shouldSpawn = true;
    private void StopSpawning() => shouldSpawn = false;

	private void Start()
	{
        xMinBound = -spawnArea.bounds.extents.x;
        xMaxBound = spawnArea.bounds.extents.x;
        yMinBound = -spawnArea.bounds.extents.y;
        xMaxBound = spawnArea.bounds.extents.y;

        slimes = 0;
        shouldSpawn = true;
    }

	private void Update()
    {
        if (shouldSpawn && slimes < maxSlimes)
        {
            StartCoroutine(Spawn());
        }
    }

	private IEnumerator Spawn()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(xMinBound, xMaxBound), -3.949f, Random.Range(yMinBound, yMaxBound));
        Instantiate(slimePrefab, spawnPoint, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
        slimes++;
        yield return new WaitForSeconds(intervalInSeconds);
    }
}
