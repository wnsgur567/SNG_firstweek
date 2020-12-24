using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 레벨별 플레이어 정보 스토리지

[System.Serializable]
public class UserInfo
{
    // 해당 레벨
    public int level;

    // 해당 레벨에 대한 정보
    public int ExpRequired; // 해당 레벨에서 다음 레벨로의 요구 경험치
    public int MaxStamina;  // 해당 레벨에서의 최대 행동력 수치

    public GroundSize MaxGroundSize;            // 해당 레벨에서의 최대 확장가능한 ground 사이즈
    public List<E_BuildingType> BuildingTypes;  // 해당 레벨에서 생성 가능한 빌드 타입
    [SerializeField]    // json 직렬화 필드
    private Serialization<E_BuildingType> serialization_BuildingTypes;

    public List<E_PlantType> PlantTypes;        // 해당 레벨에서 생산 가능한 식물 타입
    [SerializeField]    // json 직렬화 필드
    private Serialization<E_PlantType> serialization_PlantTypes;
}
public class UserInfoStorage : Singleton<UserInfoStorage>, IAwake
{
    _JsonInfoLoader _loader = null;

    // storage
    [ReadOnly]
    public List<UserInfo> userInfos = null;

    public void __Awake()
    {
        _loader = _JsonInfoLoader.Instance;

        userInfos = _loader.m_userInfo; // json 에서 읽어온 파일 그대로 셋팅
    }
}
