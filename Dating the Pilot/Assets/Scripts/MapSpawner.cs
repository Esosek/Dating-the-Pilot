using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject landingTile;
    public Transform firstTilePos;

    public int maxCol;
    public int maxRow;

    bool landingSpawned;
    int[] rotations = { 0, 90, 180, 270 };

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        float offset = 400f;
        Vector3 currentSpawnPoint = firstTilePos.position;

        for (int i = 0; i < maxRow; i++)
        {
            if(!landingSpawned && i == 7)
            {
                int landingIndex = Random.Range(0, maxCol);
                // landing possible points
                for (int o = 0; o < maxCol; o++)
                {
                    if(o == landingIndex)
                    {
                        Instantiate(landingTile, new Vector3(currentSpawnPoint.x + offset * o, currentSpawnPoint.y, currentSpawnPoint.z), Quaternion.identity);
                        landingSpawned = true;
                    }
                    else
                    {
                        int _randomTileIndex = Random.Range(0, tiles.Length);
                        Instantiate(tiles[_randomTileIndex], new Vector3(currentSpawnPoint.x + offset * o, currentSpawnPoint.y, currentSpawnPoint.z), Quaternion.AngleAxis(rotations[Random.Range(0, rotations.Length)], Vector3.up));
                    } 
                }
            }

            else
            {
                for (int o = 0; o < maxCol; o++)
                {
                    int _randomTileIndex = Random.Range(0, tiles.Length);
                    Instantiate(tiles[_randomTileIndex], new Vector3(currentSpawnPoint.x + offset * o, currentSpawnPoint.y, currentSpawnPoint.z), Quaternion.AngleAxis(rotations[Random.Range(0, rotations.Length)], Vector3.up));
                }
            }

            currentSpawnPoint = new Vector3(currentSpawnPoint.x, currentSpawnPoint.y, currentSpawnPoint.z + offset);
        }

        Debug.Log("Map spawned");
    }
}
