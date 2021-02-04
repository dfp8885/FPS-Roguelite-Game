using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TileGeneration : MonoBehaviour
{
    public GameObject[] enemyTiles, eliteTiles, emptyTiles, bossTiles;
    public NavMeshSurface meshSurface;

    public static bool BossFloor = false;
    public int bossMapLayers = 2;
    public int numOfLayers;
    
    float height = 50f;
    float width = 86.61f;

    // Start is called before the first frame update
    void Start()
    {
        // Set game to paused so that palyer cannot move until map is built
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;

        // Start the generation at the center of the map
        transform.position = Vector3.zero;

        // Build Floor
        if (BossFloor) {
            BuildBossMap();
        }
        else {
            BuildMap(numOfLayers);
        }

        // Cover floor in navmesh
        meshSurface.BuildNavMesh();

        // Resume game
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;

    }

    private void BuildMap(int layers) {
        // Generate starting tile
        Instantiate(emptyTiles[0], transform.position, Quaternion.identity);

        for (int layerNum = 1; layerNum < layers; layerNum++){
            // Move to the next layer, up and right
            transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z + height);

            for (int i = 0; i < layerNum; i++){
                // Create a tile
                Instantiate(randTile(), transform.position, Quaternion.identity);
                // Move down
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (2*height));
            }
            for (int i = 0; i < layerNum; i++){
                // Create a tile
                Instantiate(randTile(), transform.position, Quaternion.identity);
                // Move down and left
                transform.position = new Vector3(transform.position.x - width, transform.position.y, transform.position.z - height);
            }
            for (int i = 0; i < layerNum; i++){
                // Create a tile
                Instantiate(randTile(), transform.position, Quaternion.identity);
                // Move up and left
                transform.position = new Vector3(transform.position.x - width, transform.position.y, transform.position.z + height);
            }
            for (int i = 0; i < layerNum; i++){
                // Create a tile
                Instantiate(randTile(), transform.position, Quaternion.identity);
                // Move up
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (2*height));
            }
            for (int i = 0; i < layerNum; i++){
                // Create a tile
                Instantiate(randTile(), transform.position, Quaternion.identity);
                // Move up and right
                transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z + height);
            }
            for (int i = 0; i < layerNum; i++){
                // Create a tile
                Instantiate(randTile(), transform.position, Quaternion.identity);
                // Move down and right
                transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z - height);
            }
        }
    }

    void BuildBossMap() {
        // Generate starting tile
        Instantiate(bossTiles[0], transform.position, Quaternion.identity);

        for (int layerNum = 1; layerNum < bossMapLayers; layerNum++) {
            // Move to the next layer, up and right
            transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z + height);

            for (int i = 0; i < layerNum; i++) {
                // Create a tile
                Instantiate(bossTiles[1], transform.position, Quaternion.identity);
                // Move down
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (2 * height));
            }
            for (int i = 0; i < layerNum; i++) {
                // Create a tile
                Instantiate(bossTiles[0], transform.position, Quaternion.identity);
                // Move down and left
                transform.position = new Vector3(transform.position.x - width, transform.position.y, transform.position.z - height);
            }
            for (int i = 0; i < layerNum; i++) {
                // Create a tile
                Instantiate(bossTiles[0], transform.position, Quaternion.identity);
                // Move up and left
                transform.position = new Vector3(transform.position.x - width, transform.position.y, transform.position.z + height);
            }
            for (int i = 0; i < layerNum; i++) {
                // Create a tile
                Instantiate(bossTiles[0], transform.position, Quaternion.identity);
                // Move up
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (2 * height));
            }
            for (int i = 0; i < layerNum; i++) {
                // Create a tile
                Instantiate(bossTiles[0], transform.position, Quaternion.identity);
                // Move up and right
                transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z + height);
            }
            for (int i = 0; i < layerNum; i++) {
                // Create a tile
                Instantiate(bossTiles[0], transform.position, Quaternion.identity);
                // Move down and right
                transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z - height);
            }
        }
    }

    private int randNum(GameObject[] set) {
        return Random.Range(0, set.Length);
    }

    private GameObject randTile() {
        // This function will be used to randomize times based off of tile type
        // Certain types will be given different weights when considered in generation
        int rand = Random.Range(0, 10);
        if (rand > 3) {
            if (rand > 8) {
                return eliteTiles[randNum(eliteTiles)];
            }
            return emptyTiles[randNum(emptyTiles)];
        }
        return enemyTiles[randNum(enemyTiles)];
    }
}
