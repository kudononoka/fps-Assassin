using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitEffect : MonoBehaviour
{
    [SerializeField, Header("Enemyに当たった時のパーティクル")] ParticleSystem _hitPrtical;
   
    public void HitEffect(Vector3 hitpos)
    {
        transform.position = hitpos;
        _hitPrtical.Play();
    }
}
