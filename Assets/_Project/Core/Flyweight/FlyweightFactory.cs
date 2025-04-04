using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityUtils;

namespace Flyweight
{
    public class FlyweightFactory : Singleton<FlyweightFactory>
    {
        [Tooltip("Flyweight 객체 풀을 타입별로 관리하는 사전(Dictionary)입니다.")]
        readonly Dictionary<FlyweightType, IObjectPool<Flyweight>> pools = new();

        [Tooltip("풀에 객체를 반환할 때 중복 반납 여부를 검사합니다. 디버깅에 유용합니다.")]
        [SerializeField] bool collectionCheck = true;

        [Tooltip("새롭게 생성되는 객체 풀의 기본 초기 크기입니다.")]
        [SerializeField] int defaultCapacity = 10;

        [Tooltip("풀에 저장할 수 있는 최대 객체 수를 설정합니다. 초과 시 객체가 삭제됩니다.")]
        [SerializeField] int maxPoolSize = 100;


        public static Flyweight Spawn(FlyweightSettings s) => instance.GetPoolFor(s)?.Get();
        public static void ReturnToPool(Flyweight f) => instance.GetPoolFor(f.settings)?.Release(f);
        
        IObjectPool<Flyweight> GetPoolFor(FlyweightSettings settings)
        {
            if (pools.TryGetValue(settings.type, out IObjectPool<Flyweight> pool)) return pool;

            pool = new ObjectPool<Flyweight>(
                settings.Create,
                settings.OnGet,
                settings.OnRelease,
                settings.OnDestroyPoolObject,
                collectionCheck,
                defaultCapacity,
                maxPoolSize
            );
            pools.Add(settings.type, pool);
            return pool;
        }
    }
}