using UnityEngine;

public class EnemyController
{
    public EnemyController(EnemyView _enemyView)
    {
        _enemyView.GetEnemyController(this);
    }

    public EnemyController(EnemyView enemyView, EnemyModel enemyModel, Vector3 pos, Quaternion quaternion)
    {
        EnemyView = GameObject.Instantiate<EnemyView>(enemyView, pos, quaternion);
    }

    public EnemyView EnemyView { get; }
}
