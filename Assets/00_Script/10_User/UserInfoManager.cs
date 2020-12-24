using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 현재 플레이어에 대한 정보
[System.Serializable]
public struct UserInfo_Current
{
    public int level;       // 현재 레벨
    public int curExp;      // 현재 exp
    public int maxExp;      // 현재 레벨에서 요구하는 최대 exp

    public int stamina;     // 행동력 

    public int gold;
    public int cash;

    public int curGroundLevel;  // 현재 Ground 확장 레벨

    public Dictionary<E_MaterialType, int> materials;   // 재화 별 소유 개수

    void Clear()
    {
        level = 0;
        curExp = 0;
        maxExp = 0;
        stamina = 0;
        gold = 0;
        cash = 0;
        curGroundLevel = 0;

        ClearMaterials();
    }

    void ClearMaterials()
    {
        for (int i = 0; i < (int)E_MaterialType.Max; i++)
        {
            materials[(E_MaterialType)i] = 0;
        }
    }
}

public class UserInfoManager : Singleton<UserInfoManager>, IAwake
{
    public UserInfo_Current userInfo;

    public void __Awake()
    {
        // FileLoad로 읽어온 내용으로 셋팅 예정

    }
}
