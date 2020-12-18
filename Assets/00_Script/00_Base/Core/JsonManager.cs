using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Serialization<T>
{
    public List<T> target;
    public Serialization(List<T> _target) => target = _target;
}

public static class JsonManager 
{    
    // Persitent 기준으로 Path 생성 및 반환
    public static string GetDirectoryPath(string p_directoryPath)
    {
        string m_persistentPath;
        string m_resultPath;        // persistent + directory + filename         

        m_persistentPath = Application.persistentDataPath;        
        m_resultPath = Methods.CombinePath(m_persistentPath, p_directoryPath);        

        return m_resultPath;
    }
    public static string GetFilePath(string p_directoryPath, string p_filename)
    {
        string m_persistentPath;
        string m_resultPath;        // persistent + directory + filename         

        m_persistentPath = Application.persistentDataPath;
        m_resultPath = Methods.CombinePath(m_persistentPath, p_directoryPath, p_filename);

        return m_resultPath;
    }

    // 해당 경로의 디렉토리 준비
    // 없는 경우 디렉토리 생성
    public static void PrepareDirectory(string p_directoryPath)
    {
        // 해당 경로에 디렉토리가 없는 경우
        if (Directory.Exists(p_directoryPath) == false)
        {   // 디렉토리 생성
            Directory.CreateDirectory(p_directoryPath);
        }        
    }

    // 해당 경로의 파일 준비
    // 없는 경우 파일 생성
    public static void PrepareFile(string p_filePath)
    {
        if(File.Exists(p_filePath) == false)
        {
            File.Create(p_filePath);
        }        
    }

    // 기본 데이터 형식 or Serializable class 를 Json으로 저장
    public static void Save<T>(string p_filepath, T p_data)
    {
        string jsonData = JsonUtility.ToJson(p_data,true);
        File.WriteAllText(p_filepath, jsonData);
    }

    // List를 직렬화 시켜 Json으로 저장
    public static void Save<T>(string p_filepath, List<T> p_listData)
    {
        List<T> serialized = new Serialization<T>(p_listData).target;
        string jsonData = JsonUtility.ToJson(serialized, true);
        File.WriteAllText(p_filepath, jsonData);
    }

    
    public static void Load<T>(string p_filepath, out T __outData)
    {
        string jsonData = File.ReadAllText(p_filepath);
        __outData = JsonUtility.FromJson<T>(jsonData);
    }

    
    public static void Load<T>(string p_filepath,out List<T> __outListData)
    {
        string jsonData = File.ReadAllText(p_filepath);
        __outListData = JsonUtility.FromJson<Serialization<T>>(jsonData).target;
    }
}
