using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_GroundType
{
    None = 0,   // 비활성 상태 

    Normal,     // 기본 (건물 설치 가능)
    Farm,       // 경장지 (재배 가능)    
    Water,      // 물 ( 추가 기능 없음 )

    Max,
}

public struct GroundInformation
{
    public E_GroundType type;
    
    public bool isAvailable;    

    public void Clear()
    {
        type = E_GroundType.None;
        isAvailable = false;
    }
}

public class Ground_InfoStorage : MonoBehaviour
{
    GroundInformation storage;

    public void __Init(E_GroundType type,bool isAvailable)
    {
        storage.type = type;
        storage.isAvailable = isAvailable;
    }
}
