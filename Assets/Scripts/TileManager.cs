using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++)
        {
            if(i == 0)
                SpawnTiles(0);
            else
                SpawnTiles(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTiles(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
        
    }

    void SpawnTiles(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex],transform.forward * zSpawn,transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
