using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{


    public Transform[] spawnLocations;
    public GameObject[] whatToSpawnPrefab;
    public GameObject[] whatToSpawnClone; 


    public void Start(){
        spawnMaterialsToolsPlease();
    }

    void spawnMaterialsToolsPlease(){
        Debug.Log("dsafsdf");
        whatToSpawnClone[0] = Instantiate(whatToSpawnPrefab[0],spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        whatToSpawnClone[1] = Instantiate(whatToSpawnPrefab[1],spawnLocations[1].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        whatToSpawnClone[2] = Instantiate(whatToSpawnPrefab[2],spawnLocations[2].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        whatToSpawnClone[3] = Instantiate(whatToSpawnPrefab[3],spawnLocations[3].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    }

}
