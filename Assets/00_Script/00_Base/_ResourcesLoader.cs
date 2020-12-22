using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ResourcesLoader : Singleton<_ResourcesLoader>, IAwake
{
    public Dictionary<E_GroundType,GameObject> ground_origin_dic;
    public Dictionary<E_BuildingType, GameObject> building_origin_dic;
    public Dictionary<E_IvenNodeType, GameObject> invenNode_origin_dic;
    public void __Awake()
    {
        ground_origin_dic = ResourcesManager.LoadPrefabs<E_GroundType>("Ground");
        building_origin_dic = ResourcesManager.LoadPrefabs<E_BuildingType>("Building");
        invenNode_origin_dic = ResourcesManager.LoadPrefabs<E_IvenNodeType>("Inventory");
    }
}
