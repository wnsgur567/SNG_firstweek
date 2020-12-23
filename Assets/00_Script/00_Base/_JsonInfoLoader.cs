using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ReadOnlyAttribute : PropertyAttribute
{

}

[System.Serializable]
public struct MyPath
{
    public string directoryPath;
    public string filePath;

    public MyPath(string _directoryPath,string _filePath)
    {
        directoryPath = _directoryPath;
        filePath = _filePath;
    }
}

// infomation 관련 기본 정보만 로드
public class _JsonInfoLoader : Singleton<_JsonInfoLoader>, IAwake
{
    [Tooltip("FileStorage/Info/Character & abc.json")]
    public List<MyPath> m_path_list;
    // 위 path 를 바탕으로 만든 결과물
    private List<MyPath> m_persistentPath_list;


    public void __Awake()
    {
        m_persistentPath_list = new List<MyPath>();
        // 파일 준비
        foreach (var item in m_path_list)
        {
            m_persistentPath_list.Add(
                Prepare(item.directoryPath, item.filePath)
                );
        }

        // 파일 로드
        Load_Info();
        Load_SettingInfo();
    }

    public MyPath Prepare(string p_diretoryPath, string p_filePath)
    {        
        // 디렉토리 및 파일 준비
        string _diretoryPath = JsonManager.GetPersistentPath(p_diretoryPath);
        JsonManager.PrepareDirectory(_diretoryPath);
        string _filePath = JsonManager.GetFilePath(p_diretoryPath, p_filePath);
        JsonManager.PrepareFile(_filePath);

        return new MyPath(_diretoryPath, _filePath);
    }



    // Info load

    [ReadOnlyAttribute]
    public List<UserInfo> m_userInfo;
    [ReadOnlyAttribute]
    public List<BuildInformation> m_buildInfomation;
    [ReadOnlyAttribute]
    public List<GroundInformation> m_groundInformation;

    private void Load_Info()
    {
        JsonManager.Load(m_persistentPath_list[0].filePath, out m_userInfo);
        JsonManager.Load(m_persistentPath_list[1].filePath, out m_buildInfomation);
        JsonManager.Load(m_persistentPath_list[2].filePath, out m_groundInformation);
    }


    // SettingInfo load

    [ReadOnly]
    public MapSettingInformation m_groundSettingInfo;
    
    private void Load_SettingInfo()
    {
        JsonManager.Load(m_persistentPath_list[3].filePath, out m_groundSettingInfo);
    }





    [ContextMenu("파일 기본정보 셋팅(오류 제거)")]
    public void Set()
    {
        //m_userInfo = new List<UserInfo>();
        //m_buildInfomation = new List<BuildInformation>();
        //m_groundInformation = new List<GroundInformation>();
        //m_groundSettingInfo = new MapSettingInformation();
        //m_groundSettingInfo.__Init(0, 0, 0, 0);

        m_persistentPath_list = new List<MyPath>();
        // 파일 준비
        foreach (var item in m_path_list)
        {
            m_persistentPath_list.Add(
                Prepare(item.directoryPath, item.filePath)
                );
        }

        JsonManager.Save(m_persistentPath_list[0].filePath, m_userInfo);
        JsonManager.Save(m_persistentPath_list[1].filePath, m_buildInfomation);
        JsonManager.Save(m_persistentPath_list[2].filePath, m_groundInformation);

        
        // 임시 세팅값
        m_groundSettingInfo.__Init(5, 5, 3, 3);

        for (int i = 0; i < m_groundSettingInfo.total_height; i++)
        {
            for (int j = 0; j < m_groundSettingInfo.total_width; j++)
            {
                m_groundSettingInfo.GroundSettingInfo[i][j] = 1;
            }
        }
        
        JsonManager.Save(m_persistentPath_list[3].filePath, m_groundSettingInfo);

        return;
    }



}
