using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInventory : Inventory
{
    public override void __Awake()
    {
        base.__Awake();

        MakeInvenNode();
    }

    public void MakeInvenNode()
    {
        for (int i = 0; i < m_totalSize; i++)
        {
            InvenNode _node = new InvenNode();

            // init node

            invenNodes.Add(_node);
            ++m_curSize;
        }
    }

    //public IEnumerator MakeInvenAsync(int p_targetSize, int p_oneTimeSize)
    //{
    //    while (p_targetSize > m_curSize)
    //    {
    //        for (int i = 0; i < p_oneTimeSize; i++)
    //        {
    //            InvenNode _node = new InvenNode();

    //            // init node

    //            invenNodes.Add(_node);
    //            ++m_curSize;
    //        }
    //        yield return null;
    //    }
    //}
}
