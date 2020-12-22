using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScriptOrderManager)),CanEditMultipleObjects]
public class OrderEditor : Editor 
{    
    public override void OnInspectorGUI() {
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("testList"));

        serializedObject.ApplyModifiedProperties();         
    }
}

// 각 Scene 별로 존재해야 함
// project setting 에서 order를 최상단으로 설정 할 것
[System.Serializable]
public class ScriptOrderManager : MonoBehaviour
{   
    private List<int> testList;
    [SerializeField] public List<IAwake> m_awake_list;
    public List<IOnEnable> m_onEnable_list;
    public List<IStart> m_start_list;
    public List<IOnDisable> m_onDisable_list;

    private void Awake() 
    {        
        foreach(var item in m_awake_list)
        {
            item.__Awake();
        }
    }
    private void OnEnable() 
    {
        foreach(var item in m_onEnable_list)
        {
            item.__OnEnable();
        }
    }
    private void Start() 
    {
        foreach(var item in m_start_list)
        {
            item.__Start();
        }
    }
    private void OnDisable() 
    {
        foreach(var item in m_onDisable_list)
        {
            item.__OnDisable();
        }
    }
}
