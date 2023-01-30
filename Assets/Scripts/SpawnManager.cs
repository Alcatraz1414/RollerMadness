using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField]private float spawnRate = 5f;
    [SerializeField] private float currentTime=0f;
    private TimeManager timeManager;

    

    [SerializeField] private GameObject[] objects;
    [SerializeField] private Transform[] spawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.gameOver == false && timeManager.gameFinish == false)  //1 altýndaki if in koþullarýna da yazýlabilir     if (Time.timeSinceLevelLoad > currentTime & timeManager.gameOver == false && timeManager.gameFinish == false) gibi...
        {
            // 5 saniyede 1 düþman çýktý yazýsý yazýyor
            if (Time.timeSinceLevelLoad > currentTime)
            {
                SpawnObject(objects[ObjectSpawnNumber()], spawnPositions[RandomSpawnNumber()]);  // RandomSpawnNumber metodu ile transform tipindeki spawnPosition arrayindeki deðerlerden 1 tanesini rastegele seçiyor..       
                currentTime += spawnRate;
            }

        }
    }

    // obje üretmeyi metot halinde yaptýk
    private void SpawnObject(GameObject ObjecttoSpawn, Transform newTransform)
    {
        Instantiate(ObjecttoSpawn, newTransform.position, newTransform.rotation);
    }

    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }

    private int ObjectSpawnNumber()
    {
        return Random.Range(0,objects.Length);
    }

}
