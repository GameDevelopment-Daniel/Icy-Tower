using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Spwner : MonoBehaviour
{
    [SerializeField] float minTimeBetweenSpawns = 1f;
    [SerializeField] float maxTimeBetweenSpawns = 3f;
    [SerializeField] float maxXDistance = 0.5f;
    [SerializeField] GameObject floor1;
    [SerializeField] GameObject floor2;
    GameObject floor;
    int countPoints;
    [SerializeField] int pointsLvl2;
    GameObject points;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
        countPoints= 0;
        floor = floor1;
        points = GameObject.Find("points");
    }

    // Update is called once per frame
    void Update()
    {
        if (countPoints == pointsLvl2)
        {
            floor= floor2;
            GameObject.Find("lvl2").GetComponent<TextMeshProUGUI>().text = "lvl 2";
        }
    }

    IEnumerator SpawnRoutine()
    {    // co-routines
         // async Task SpawnRoutine() {  // async-await
        while (true)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
            // await Task.Delay((int)(timeBetweenSpawnsInSeconds*1000));       // async-await
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);
            GameObject newObject = Instantiate(floor, positionOfSpawnedObject, Quaternion.identity);
            countPoints++;
            points.GetComponent<TextMeshProUGUI>().text = countPoints.ToString();
            //newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
        }
    }
}
