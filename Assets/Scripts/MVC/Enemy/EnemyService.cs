using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoSingletonGeneric<EnemyService>
{

    [Header("Ship Details")]
    [SerializeField]
    private Vector3 spawnPos;
    [SerializeField]
    private Vector3 rotation;

    public EnemyView enemy;
    public EnemyController EnemyController;
    public EnemyModel enemyModel;

    private bool shipCreated;


    [Header("Asteriod Details")]
    [SerializeField]
    private AsteroidMovement asteroidPrefab;

    private bool asteriodCreated;

    [SerializeField]
    private float[] asterSpawnYPos;

    [Header("Lists")]
    [SerializeField]
    private Transform ships, asteriods;

    [SerializeField]
    private Vector3[] shipPositions;

    public List<AsteroidMovement> asteroidsObjs;
    public List<EnemyView> enemyViews;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!asteriodCreated)                                             //asteriods will be created continously in time intervals
            StartCoroutine(AsteriodDelay());

        if (!shipCreated)
            StartCoroutine(SpawnEnemyShipDelay(10));

        if (PlayerShipService.playerIsDead)
        {
            foreach (AsteroidMovement item in asteroidsObjs)
            {
                item.enabled = false;
            }
            foreach (EnemyView item in enemyViews)
            {
                item.enabled = false;
            }
        }
/*        else
        {
            foreach (AsteroidMovement item in asteroidsObjs)
            {
                item.enabled = true;
            }
            foreach (EnemyView item in enemyViews)
            {
                item.enabled = true;
            }
        }
*/    }

    private void SpawnEnemyWithPath(EnemyPath enemyPath)
    {
        Vector3 initPos = new Vector3(25, 11, 10);                      //top right corner


        switch (enemyPath)
        {
            case EnemyPath.None:
                for (int i = 0; i < shipPositions.Length; i++)
                {
                    shipPositions[i].z = 10;
                    SpawnEnemyShip(shipPositions[i]);
                }
                break;
            case EnemyPath.Right_V:
                /* for (int i = 0; i < shipPositions.Length; i++)
                 {
                     if (i < shipPositions.Length / 2)
                     {
                         initPos.x--;
                         initPos.y -= 2;
                     }
                     else
                     {
                         initPos.x++;
                         initPos.y += 2;
                     }
                     shipPositions[i] = initPos;
                     SpawnEnemyShip(shipPositions[i]);
                 }*/

                break;
            case EnemyPath.Left_V:
                break;
            case EnemyPath.Right_U:
                break;
            default:
                break;
        }
    }


    private void SpawnAsteriodsRand(int posX)
    {
        int randY = Random.Range(0, asterSpawnYPos.Length);
        Vector3 randPos = new Vector3(20 + posX, asterSpawnYPos[randY], 10);
        AsteroidMovement asteroidMovement = Instantiate(asteroidPrefab, randPos, Quaternion.identity, asteriods);
    }

    private EnemyController SpawnEnemyShip(Vector3 pos)
    {
        EnemyController enemyController = new EnemyController(enemy, enemyModel, pos, enemy.transform.rotation, ships);
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

    IEnumerator SpawnEnemyShipDelay(float secs)
    {
        shipCreated = true;
        yield return new WaitForSeconds(secs);
        SpawnEnemyWithPath(EnemyPath.None);
        shipCreated = false;
    }
}
public enum EnemyPath
{
    None,
    Right_V,
    Left_V,
    Right_U,

}