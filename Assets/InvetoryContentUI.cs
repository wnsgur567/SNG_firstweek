using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryContentUI : MonoBehaviour
{
    _ObjectStorage storage = null;
    MemoryPool nodePool;
    public UserInventory inven;

    List<GameObject> actived_nodes; // spawn된 오브젝트 관리용 리스트

    

    private void Awake()
    {
        storage = _ObjectStorage.Instance;
        nodePool = storage.node_pools[E_IvenNodeType.UserNode];

        actived_nodes = new List<GameObject>();
    }

    private void Start()
    {       
        

        OnUserInvenNodeUpdate(inven.m_curSize);
    }

    public void OnUserInvenNodeUpdate(int makeSize)
    {
        for (int i = 0; i < makeSize; i++)
        {
            GameObject _node = nodePool.Spawn();

            // init
            _node.transform.SetParent(this.gameObject.transform);
            _node.SetActive(true);
            actived_nodes.Add(_node);
        }
    }

}
