using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ObjectStorage : Singleton<_ObjectStorage>, IAwake
{
    _ResourcesLoader _resourcesLoader = null;
    public Dictionary<E_GroundType, MemoryPool> ground_pools;
    public Dictionary<E_BuildingType, MemoryPool> building_pools;
    public Dictionary<E_IvenNodeType, MemoryPool> node_pools;

    public void __Awake()
    {
        _resourcesLoader = _ResourcesLoader.Instance;
        // 메모리풀 생성
        ground_pools = Methods.MakeMemoryPool(_resourcesLoader.ground_origin_dic, this.gameObject, 10);
        building_pools = Methods.MakeMemoryPool(_resourcesLoader.building_origin_dic, this.gameObject, 10);
        node_pools = Methods.MakeMemoryPool(_resourcesLoader.invenNode_origin_dic, this.gameObject, 100);


        // 코루틴으로 메모리 풀 확장
        foreach (var item in ground_pools)
        {
            StartCoroutine(item.Value.ExpandPoolSizeAsync(10, 1));
        }
    }



}
