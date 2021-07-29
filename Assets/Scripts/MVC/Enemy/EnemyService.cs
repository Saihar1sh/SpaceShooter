using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    [SerializeField]
    private AsteroidMovement asteroidPrefab;

    private bool asteriodCreated;

    [SerializeField]
    private float[] asterSpawnYPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!asteriodCreated)
            StartCoroutine(AsteriodDelay());
    }

    private void SpawnAsteriodsRand(int posX)
    {
        int randY = Random.Range(0, asterSpawnYPos.Length);
        Vector3 randPos = new Vector3(20 + posX, asterSpawnYPos[randY], 10);
        Instantiate(asteroidPrefab, randPos, Quaternion.identity);
    }

    IEnumerator AsteriodDelay()
    {
        asteriodCreated = true;
        int randNum = Random.Range(1, 5);
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < randNum; i++)
        {
            int rand = Random.Range(1, 5);
            SpawnAsteriodsRand(rand);
        }
        asteriodCreated = false;
    }
}
