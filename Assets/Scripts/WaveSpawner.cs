using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timeBV = 5f;
    
    private float countdown = 2f;

    private int waveIndex = 0;
    [SerializeField]
    private Text waveCountDown;

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBV;
        }
        countdown-= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDown.text = string.Format("{0:00.00}", countdown);

    }

    IEnumerator SpawnWave()
    {

        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2.0f);
        }

        

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
