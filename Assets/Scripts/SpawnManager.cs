using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float cooldownSpawnBall = 5;
    public float cooldownSpeed = 1;
    public int maxBall = 3;

    public GameObject parent;
    public GameObject ball;
    public float force = 100;
    public List<GameObject> listSpawner;
    public List<GameObject> listBall;

    private float timer = 0;

    private void Start()
    {
        timer = cooldownSpawnBall;
    }

    private void Update()
    {
        timer -= Time.deltaTime * cooldownSpeed;

        if (timer <= 0)
        {
            timer = cooldownSpawnBall;
            if (listBall.Count<maxBall)
            {
                SpawnBall(ball);
            }
        }
    }

    public void SpawnBall(GameObject ball)
    {
        GameObject spawnPosition = GetRandomSpawner();
        float randomDiff = Random.Range(-0.5f, 0.5f);
        print(randomDiff);
        GameObject spawnedBall = Instantiate(ball, spawnPosition.transform.position, transform.rotation * Quaternion.Euler( spawnPosition.transform.eulerAngles), parent.transform);
        spawnedBall.GetComponent<Rigidbody>().AddForce((spawnedBall.transform.forward+(spawnedBall.transform.right*randomDiff))* force);
        listBall.Add(spawnedBall);
    }

    public GameObject GetRandomSpawner()
    {
        int randomIndex = Random.Range(0, listSpawner.Count);
        return listSpawner[randomIndex];
    }
}
