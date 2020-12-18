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
}

// infomation 관련 기본 정보만 로드
public class _JsonInfoLoader : Singleton<_JsonInfoLoader>, IAwake
{
    [Tooltip("FileStorage/Info/Character & abc.json")]
    public List<MyPath> m_path_list;



    public void __Awake()
    {


        // 파일 로드
        Load_Info();
    }

    //public void Prepare(string _diretoryPath, string _filePath)
    //{
    //    // 디렉토리 및 파일 준비
    //    m_result_directoryPath = JsonManager.GetDirectoryPath(_diretoryPath);
    //    JsonManager.PrepareDirectory(m_result_directoryPath);
    //    m_result_filePath = JsonManager.GetFilePath(m_user_directoryPath, m_user_filePath);
    //    JsonManager.PrepareFile(m_result_filePath);
    //}



    [ReadOnlyAttribute]
    public UserInfo m_userInfo;
    [ReadOnlyAttribute]
    public List<BuildInformation> m_buildInfomation;
    [ReadOnlyAttribute]
    public List<GroundInformation> groundInformation;

    public void Load_Info()
    {

    }
}
