﻿using System.Collections;
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
        JsonManager.Load(m_persistentPath_list[0].filePath, out m_userInfo);
        JsonManager.Load(m_persistentPath_list[1].filePath, out m_buildInfomation);
        JsonManager.Load(m_persistentPath_list[2].filePath, out m_groundInformation);
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



    [ReadOnlyAttribute]
    public List<UserInfo> m_userInfo;
    [ReadOnlyAttribute]
    public List<BuildInformation> m_buildInfomation;
    [ReadOnlyAttribute]
    public List<GroundInformation> m_groundInformation;

    
}
