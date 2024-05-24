using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> animals;
    public int maxAnimalCount = 10;
    public int currentAnimalCount = 0;
    public float spawnTime = 2f;
    public float currentTime = 0f;
    public Transform animalParent;
    private void Update()
    {
        if (currentTime >= spawnTime)
        {
            if (currentAnimalCount < maxAnimalCount)
            {
                SpawnAnimal();
                currentAnimalCount++;
            }
            currentTime = 0f;
        }
        currentTime += Time.deltaTime;
    }
    private void SpawnAnimal()
    {
        GameObject animal = Instantiate(animals[Random.Range(0, animals.Count)], new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0), Quaternion.identity);
        animal.transform.SetParent(animalParent);
    }
}
