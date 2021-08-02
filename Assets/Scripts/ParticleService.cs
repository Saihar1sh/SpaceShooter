using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleService : MonoSingletonGeneric<ParticleService>
{
    [SerializeField]
    private ParticleSystem explosionParticle;


    public void CommenceExplosion(Transform t)
    {
        GameObject _Explosion = Instantiate(explosionParticle.gameObject, t.position, t.rotation);
        ParticleSystem particleSystem = _Explosion.GetComponent<ParticleSystem>();
        particleSystem.Play();
        Destroy(_Explosion, 1f);
    }

}
