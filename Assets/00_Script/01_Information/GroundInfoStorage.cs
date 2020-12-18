using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GroundInformation
{
    public E_GroundType type;

    public bool isAvailable;

    public GroundInformation(E_GroundType _type, bool _isAvailable)
    {
        type = _type;
        isAvailable = _isAvailable;
    }

    public void __Init(E_GroundType _type, bool _isAvailable)
    {
        type = _type;
        isAvailable = _isAvailable;
    }
    public void Clear()
    {
        type = E_GroundType.None;
        isAvailable = false;
    }
}

public struct GroundSize
{
    public int width;
    public int height;
    public GroundSize(int _width, int _height)
    {
        width = _width;
        height = _height;
    }
}
public struct Index
{
    /*
           x1  x2  x3
        y1  .   .   .
        y2  .   .   .
        y3  .   .   .
     */
    public int x;
    public int y;

    public Index(int _x, int _y)
    {
        x = _x;
        y = _y;
    }
}

public class GroundInfoStorage : Singleton<GroundInfoStorage>, IAwake
{
    [Tooltip("width & height MAX value"), Range(0, 200)]
    public int MAXGROUNDSIZE;
    [Tooltip("레벨 1 기준으로 기본 제공되는 Ground 사이즈"), Range(10, 100)]
    public int STDSIZE;
    [Range(0, 100)]
    public int MAXGROUNDLEVEL;


    // 각 타입 별 기본 정보값들을 셋팅
    public Dictionary<E_GroundType, GroundInformation> storage;

    // 각 GroundLevel 별 width height 길이
    [HideInInspector]
    public List<GroundSize> GroundSizes;

    // 실제 Ground 정보
    [HideInInspector]
    public GroundInformation[,] groundInfo_arr = null;


    public void __Awake()
    {
        __InitDictionary();
        __InitLevelInfo();
        __InitGroundArrInfo();
    }

    private void __InitDictionary()
    {
        storage = new Dictionary<E_GroundType, GroundInformation>();
        // 임시 -> 파일
        for (int i = 0; i < (int)E_GroundType.Max; i++)
        {
            storage[(E_GroundType)i] = new GroundInformation();
            storage[(E_GroundType)i].Clear();
            storage[(E_GroundType)i].__Init((E_GroundType)i, false);
        }
    }
    private void __InitLevelInfo()
    {
        GroundSizes = new List<GroundSize>();
        // 임시 -> 파일
        GroundSizes.Add(new GroundSize());  // level 0

        // level 1 ~ ...
        for (int i = 1; i < MAXGROUNDLEVEL + 1; i++)
        {
            GroundSizes.Add(new GroundSize
                (STDSIZE + (i - 1) * 2,
                STDSIZE + (i - 1) * 2));
        }
    }

    private void __InitGroundArrInfo()
    {
        groundInfo_arr = new GroundInformation[MAXGROUNDSIZE, MAXGROUNDSIZE];

        // 파일 읽어서 정보 있으면 셋팅
        // ...
        // ...
    }

    // left top
    public Vector3 IndexToPosition(int _indexX, int _indexY)
    {
        Vector3 ret;

        Index center = GetCenterIndex();

        int deltaX = center.x - _indexX;
        int deltaY = center.y - _indexY;

        ret = new Vector3(deltaX, 0, deltaY);

        return ret;
    }

    public Index GetCenterIndex()
    {
        Index ret;

        int x = MAXGROUNDSIZE / 2;
        int y = MAXGROUNDSIZE / 2;
        ret = new Index(x, y);

        return ret;
    }
}
