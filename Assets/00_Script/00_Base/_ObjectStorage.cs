using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ObjectStorage : Singleton<_ObjectStorage>, IAwake
{
    public Dictionary<E_GroundType, MemoryPool> ground_pools;
    
    public void __Awake()
    {
        // 메모리풀 생성
        ground_pools = Methods.MakeMemoryPool(_ResourcesLoader.Instance.ground_origin_dic,this.gameObject,10);

        // 코루틴으로 메모리 풀 확장
        foreach (var item in ground_pools)
        {
            StartCoroutine(item.Value.ExpandPoolSizeAsync(100, 10));
        }
    }



}
