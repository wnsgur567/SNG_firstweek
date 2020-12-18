using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_StuffType
{
    None = 0,
    Seed,       // 씨앗
    Plant,      // 재배 작물
    Consumable, // 소모품
    Equipment,  // 착용 장비
    Facility,   // 시설물
    ETC,        // 기타

    Max
}

public struct InvenNode
{
    public E_StuffType type;

    int count;      // 현재 개수
    int MAXCOUNT;   // 한 Node 에서 개수 최대치 (각 물건 별로 결정 됨)

    public void __Init(E_StuffType _type, int _count, int _MAXCOUNT)
    {
        type = _type;
        count = _count;
        MAXCOUNT = _MAXCOUNT;
    }

    public void Clear()
    {
        type = E_StuffType.None;
        count = 0;
        MAXCOUNT = 0;
    }
}

// 상속
public class Inventory : MonoBehaviour, IAwake
{
    [Range(0, 1000)]
    public int MAXSIZE;         // 인벤토리 확장 최대치
    [Range(0, 1000)]
    public int m_totalSize;     // 현재 확장된 최대치

    [HideInInspector]
    public int m_curSize;       // occupied 

    [HideInInspector]
    public List<InvenNode> invenNodes;

    virtual public void __Awake()
    {
        invenNodes = new List<InvenNode>(MAXSIZE);  // capacity
        m_curSize = 0;
    }
}
