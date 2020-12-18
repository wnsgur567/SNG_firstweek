using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _OrderManager : MonoBehaviour
{
    [SerializeField]
    private List<MonoBehaviour> m_awake_list;
    private List<IAwake> m_awakes;

    [SerializeField] 
    private List<MonoBehaviour> m_onEnable_list;
    private List<IOnEnable> m_onEnables;

    [SerializeField] 
    private List<MonoBehaviour> m_start_list;
    private List<IStart> m_starts;

    [SerializeField] 
    private List<MonoBehaviour> m_onDisable_list;
    private List<IOnDisable> m_onDisables;
    
    void Awake()
    {  
        m_awakes = new List<IAwake>();
        m_onEnables = new List<IOnEnable>();
        m_starts = new List<IStart>();
        m_onDisables = new List<IOnDisable>();

        foreach (var item in m_awake_list)
        {
            var awake = item as IAwake;
            if (awake != null)
                m_awakes.Add(awake);
            else
                Debug.LogErrorFormat("_OrderManager : IAake미포함 {0}", item.name);
        }
        foreach (var item in m_onEnable_list)
        {
            var onEnable = item as IOnEnable;
            if (onEnable != null)
                m_onEnables.Add(onEnable);
            else
                Debug.LogErrorFormat("_OrderManager : IOnEnable미포함 {0}", item.name);
        }
        foreach (var item in m_start_list)
        {
            var start = item as IStart;
            if (start != null)
                m_starts.Add(start);
            else
                Debug.LogErrorFormat("_OrderManager : IStart 미포함 {0}", item.name);
        }
        foreach (var item in m_onDisable_list)
        {
            var onDisable = item as IOnDisable;
            if (onDisable != null)
                m_onDisables.Add(onDisable);
            else
                Debug.LogErrorFormat("_OrderManager : IOnDisable 미포함 {0}", item.name);
        }

        Call_Awakes();
    }

    private void Call_Awakes()
    {
        foreach (var item in m_awakes)
        {
            item.__Awake();
        }
    }
    private void Call_OnEnables()
    {
        foreach (var item in m_onEnables)
        {
            item.__OnEnable();
        }
    }
    private void Call_Start()
    {
        foreach (var item in m_starts)
        {
            item.__Start();
        }
    }
    private void Call_OnDisables()
    {
        foreach (var item in m_onDisables)
        {
            item.__OnDisable();
        }
    }    
}
