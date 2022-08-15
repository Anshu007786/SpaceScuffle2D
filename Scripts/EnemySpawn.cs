using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    WaveConfig currentWave;
    
    
    
    void Start()
    {
        StartCoroutine (SpawnEnemies());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach(WaveConfig wave in waveConfig)
            {
                currentWave = wave;
                for(int i = 0 ; i < currentWave.GetEnemyCount() ; i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(0), 
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
        
        
        
            
    }


}
