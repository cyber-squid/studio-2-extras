using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script contains a queue for in-game items. it adds an item to the queue after a given
// time period; if enough items are instantiated, dequeue is called and the first item in the queue is destroyed.
public class ItemSpawner : MonoBehaviour
{
    static Queue<GameObject> spawnQueue = new Queue<GameObject>();
    [SerializeField] int maxNumOfItemsInGame = 5;

    [SerializeField] GameObject itemToSpawn;

    [SerializeField] int buffer = 50; // value for how far up potions should spawn.

    float spawnDelay;
    [SerializeField] float maxSpawnDelay = 15;
    [SerializeField] float minSpawnDelay = 10;


    private void OnEnable()
    {
        StartCoroutine(SpawnTimer());
    }

    // this function continually repeats itself from Start -
    // it spawns an item, and randomises the next spawn time.
    IEnumerator SpawnTimer()
    {
        SpawnAnItem(itemToSpawn);

        spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnTimer());
    }


    // get the height of the screen, pick a random point along the x axis of the screen, 
    // translate to worldspace during instantiate, and add to the item queue via instantiate.
    void SpawnAnItem(GameObject spawnItem)
    {
        Vector3 currentSpawnPos = new Vector3(Random.Range(0, Screen.width), Screen.height + buffer, 1);

        spawnQueue.Enqueue(Instantiate(spawnItem, // adds an item to the queue and sets the item value to a new instantiated object.
            Camera.main.ScreenToWorldPoint(currentSpawnPos), Quaternion.identity)); 
        Debug.Log("Item spawned");


        if (spawnQueue.Count > maxNumOfItemsInGame)
        {
            Destroy(spawnQueue.Dequeue()); // destroys the first gameObject in the queue list while removing the queue value.

            Debug.Log("Item de-spawned");
        }
    }

}