using System.Collections;
using UnityEngine;
using UnityUtils;

namespace Flyweight
{
    public class Projectile : Flyweight
    {
        new ProjectileSettings settings => (ProjectileSettings) base.settings; 
        void OnEnable() => StartCoroutine(DespawnAfterDelay());

        void Update()
        {
            transform.Translate(Vector2.right * (settings.speed * Time.deltaTime));
        }

        IEnumerator DespawnAfterDelay()
        {
            yield return Helpers.GetWaitForSeconds(settings.despawnDelay);
            FlyweightFactory.ReturnToPool(this);
        }
    }
}