using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// json manager로 이관 필요
public class _FileLoader : Singleton<_FileLoader>,IAwake
{
    #region Infomation Data Table
    [Tooltip("ex : FileStore/User/UserInfo.txt")]
    public string filepath_userInfo;
    [Tooltip("ex : FileStore/User/UserInfo.txt")]
    public string filepath_buildingsInfo;
    [Tooltip("ex : FileStore/User/UserInfo.txt")]
    public string filepath_plantsInfo;
    [Tooltip("ex : FileStore/User/UserInfo.txt")]
    public string filepath_animalsInfo;
    #endregion

    #region 플레이로 인해 발생된 결과들을 불러옴
    [Tooltip("ex : FileStore/User/UserInfo.txt")]
    public string filepath_SetGroundsInfo;
    [Tooltip("ex : FileStore/User/UserInfo.txt")]
    public string filepath_SetBuildingsInfo;

    [Tooltip("ex : FileStore/User/UserInfo.txt")]
    public string filepath_SetAchievementInfo;
    #endregion


    [HideInInspector]
    public List<string> loaded_userInfo;
    [HideInInspector]
    public List<string> loaded_buildingInfo;
    [HideInInspector]
    public List<string> loaded_plantInfo;
    [HideInInspector]
    public List<string> loaded_animalsInfo;

    [HideInInspector]
    public List<string> loaded_setGroundInfo;
    [HideInInspector]
    public List<string> loaded_setBuildingsInfo;
    [HideInInspector]
    public List<string> loaded_setAchievementInfo;


    public void __Awake()
    {
        //loaded_userInfo = FileManager.File_Load(filepath_userInfo);
        //loaded_buildingInfo = FileManager.File_Load(filepath_buildingsInfo);
        //loaded_plantInfo = FileManager.File_Load(filepath_plantsInfo);
        //loaded_animalsInfo = FileManager.File_Load(filepath_animalsInfo);
        
    }    
}
