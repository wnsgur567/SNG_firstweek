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

[System.Serializable]
public class Serialization_1DArray<T>
{
    public T[] array;
    public Serialization_1DArray(T[] _array) => array = _array;
}

// 콜백 인터페이스는 클래스에서만 작동합니다. 구조체에서는 작동하지 않습니다.
[System.Serializable]
public class Serialization_2DArray<T> : ISerializationCallbackReceiver
{
    [SerializeField]
    Serialization_1DArray<T>[] arrayList;

    public T[][] array;

    public Serialization_2DArray(T[][] _array)
    {
        array = _array;
    }

    public void OnBeforeSerialize()
    {
        int length = array.Length;
        arrayList = new Serialization_1DArray<T>[length];
        for (int i = 0; i < length; i++)
        {
            arrayList[i] = new Serialization_1DArray<T>(array[i]);
        }
    }

    public void OnAfterDeserialize()
    {
        int length = arrayList.Length;
        array = new T[length][];
        for (int i = 0; i < length; i++)
        {
            array[i] = arrayList[i].array;
        }
    }
}

[System.Serializable]
public class Serialization<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField]
    List<TKey> keys;
    [SerializeField]
    List<TValue> values;

    public Dictionary<TKey, TValue> target;
    public Serialization(Dictionary<TKey, TValue> _target) => target = _target;

    public void OnBeforeSerialize()
    {   // 직렬화 전
        keys = new List<TKey>();
        values = new List<TValue>();
        foreach (var item in target)
        {
            keys.Add(item.Key);
            values.Add(item.Value);
        }
    }
    public void OnAfterDeserialize()
    {   // 역직렬화 후
        var count = Mathf.Min(keys.Count, values.Count);
        target = new Dictionary<TKey, TValue>(count);
        for (var i = 0; i < count; i++)
        {
            target.Add(keys[i], values[i]);
        }
    }
}

public static class JsonManager 
{    
    // Persitent 기준으로 Path 생성 및 반환
    public static string GetPersistentPath(string p_directoryPath)
    {
        string persistentPath;
        string resultPath;        // persistent + directory + filename         

        persistentPath = Application.persistentDataPath;
        resultPath = Methods.CombinePath(persistentPath, p_directoryPath);        

        return resultPath;
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


    /// Save

    // 기본 데이터 형식 or Serializable class 를 Json으로 저장
    public static void Save<T>(string p_filepath, T p_data)
    {
        string jsonData = JsonUtility.ToJson(p_data,true);
        File.WriteAllText(p_filepath, jsonData);
    }

    // List를 직렬화 시켜 Json으로 저장
    public static void Save<T>(string p_filepath, List<T> p_listData)
    {        
        string jsonData = JsonUtility.ToJson(new Serialization<T>(p_listData), true);
        File.WriteAllText(p_filepath, jsonData);
    }

    //public static void Save<TKey,TValue>(string p_filepath,Dictionary<TKey,TValue> p_DicData)
    //{
    //    string jsonData = JsonUtility.ToJson(new Serialization<TKey, TValue>(p_DicData));
    //    File.WriteAllText(p_filepath, jsonData);
    //}
    public static void Save<T>(string p_filepath, T[] p_array1D)
    {
        string jsonData = JsonUtility.ToJson(new Serialization_1DArray<T>(p_array1D), true);
        Debug.Log(jsonData);
        File.WriteAllText(p_filepath, jsonData);
    }
    //public static void Save<T>(string p_filepath, T[][] p_array2D)
    //{
    //    string jsonData = JsonUtility.ToJson(new Serialization_2DArray<T>(p_array2D), true);
    //    Debug.Log(jsonData);
    //    File.WriteAllText(p_filepath, jsonData);
    //}

    
    /// Load   
    

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
    //public static void Load<Tkey,TValue>(string p_filepath,out Dictionary<Tkey, TValue> __outDicData)
    //{
    //    string jsonData = File.ReadAllText(p_filepath);
    //    __outDicData = JsonUtility.FromJson<Serialization<Tkey, TValue>>(jsonData).target;
    //}
    public static void Load<T>(string p_filepath, out T[] __outArrayData)
    {
        string jsonData = File.ReadAllText(p_filepath);
        __outArrayData = JsonUtility.FromJson<Serialization_1DArray<T>>(jsonData).array;
    }
    //public static void Load<T>(string p_filepath, out T[][] __outArrayData)
    //{
    //    string jsonData = File.ReadAllText(p_filepath);
    //    __outArrayData = JsonUtility.FromJson<Serialization_2DArray<T>>(jsonData).array;
    //}
}
