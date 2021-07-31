using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    [SerializeField]
    private AsteroidMovement asteroidPrefab;

    [SerializeField]
    private Vector3 spawnPos, rotation;

    public EnemyView enemy;
    public EnemyController EnemyController;
    public EnemyModel enemyModel;

    private bool asteriodCreated;

    [SerializeField]
    private float[] asterSpawnYPos;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyShip(spawnPos, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!asteriodCreated)
        //StartCoroutine(AsteriodDelay());
    }

    private void SpawnAsteriodsRand(int posX)
    {
        int randY = Random.Range(0, asterSpawnYPos.Length);
        Vector3 randPos = new Vector3(20 + posX, asterSpawnYPos[randY], 10);
        Instantiate(asteroidPrefab, randPos, Quaternion.identity);
    }

    private EnemyController SpawnEnemyShip(Vector3 pos, Vector3 rot)
    {
        EnemyController enemyController = new EnemyController(enemy, enemyModel, pos, Quaternion.Euler(rot.x, rot.y, rot.z));
        return enemyController;
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
