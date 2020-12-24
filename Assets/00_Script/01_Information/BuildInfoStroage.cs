using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BuildInformation
{
    public string name;
    public E_BuildingType type;
    
    public int width;   
    public int height;
    public float time;  // 소요 시간
    public int gold;    // 요구 금액    
    public int level;   // 요구 레벨


    public void __Init(string _name,E_BuildingType _type, int _width, int _height, float _time, int _gold)
    {
        name = _name;
        type = _type;
        width = _width;
        height = _height;
        time = _time;
        gold = _gold;
    }
    public void Clear()
    {
        width = 0;
        height = 0;
        time = 0f;
        gold = 0;
        level = 0;
    }
}
public class BuildInfoStroage: Singleton<BuildInfoStroage>,IAwake
{
    _JsonInfoLoader _loader = null;

    // 각 타입 별 기본 정보값들을 셋팅
    public Dictionary<E_BuildingType, BuildInformation> storage;

    public void __Awake()
    {
        _loader = _JsonInfoLoader.Instance;

        storage = new Dictionary<E_BuildingType, BuildInformation>();

        // json에서 읽은 파일로 셋팅
        foreach (var item in _loader.m_buildInfomation)
        {
            storage[item.type] = item;
        } 

        // 임시 셋팅시
        //for (int i = 0; i < (int)E_BuildingType.Max; i++)
        //{
        //    storage[(E_BuildingType)i] = new BuildInformation();
        //    storage[(E_BuildingType)i].Clear();

        //    storage[(E_BuildingType)i].__Init(((E_BuildingType)i).ToString() ,(E_BuildingType)i, 1, 1, 10, 10);    // 임시
        //}
    }
}
