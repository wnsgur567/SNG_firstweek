using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundGenerator : Singleton<GroundGenerator>, IAwake
{   // 맵의 중앙을 0,0 으로 설정
    private UserInfoManager _userInfoManager = null;   
    private GroundInfoStorage _groundInfoStorage = null;

    private Dictionary<E_GroundType, MemoryPool> ground_pools = null;
    public GameObject[,] ground_arr;          
    
    public void __Awake()
    {
        _userInfoManager = UserInfoManager.Instance; 
        _groundInfoStorage = GroundInfoStorage.Instance;

        ground_pools = _ObjectStorage.Instance.ground_pools;        
        ground_arr = Generate(_userInfoManager.userInfo.curGroundLevel);        
    }

    // 아무것도 없는 상태에서 생성 (게임 로드 시)
    public GameObject[,] Generate(int p_ground_level)
    {
        int _max = _groundInfoStorage.MAXGROUNDSIZE;
        GameObject[,] ret = new GameObject[_max, _max];


        // 불러온 데이터 정보를 바탕으로 셋팅...
        for (int i = 0; i < _max; i++)
        {
            for (int j = 0; j < _max; j++)
            {
                int _info = _groundInfoStorage.m_settingInformation.GroundSettingInfo[i][j];
                ret[i, j] = ground_pools[(E_GroundType)_info].Spawn();
                // 나머지 Init 할거 ...
                ret[i,j].transform.position = _groundInfoStorage.IndexToPosition(i, j);
                ret[i, j].SetActive(true);
            }
        }

        return ret;
    }

    // 생성된 데이터가 있는 경우 추가로 확장 (게임 중 확장)
    // 상하좌우로 확장함
    public void Append(int p_level)
    {

    }
}
