using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Methods
{
    private static System.DateTime timer;
    public static void CheckTimeIN()
    {
        timer = System.DateTime.Now;
    }
    public static System.TimeSpan CheckTimeStop()
    {
        System.TimeSpan time = System.DateTime.Now - timer;
        return time;
    }

    public static Transform[] GetChilderen(this Transform tf, string name)
    {
        int count = tf.childCount;

        List<Transform> ret_list = new List<Transform>();
        if (tf.name == name)
        {
            ret_list.Add(tf);
        }
        else if (count == 0)
            return null;

        for (int i = 0; i < count; i++)
        {
            Transform[] arr = tf.GetChild(i).GetChilderen(name);
            if (arr != null)
                ret_list.AddRange(arr);
        }

        return ret_list.ToArray();
    }

    public static Transform GetChildObjFind(this Transform _transform, string p_name)
    {
        int count = _transform.childCount;

        Transform temp_child_transforms;

        for (int i = 0; i < count; i++)
        {

            temp_child_transforms = _transform.GetChild(i);
            if (temp_child_transforms.name == p_name)
            {
                return temp_child_transforms;
            }
            else if(temp_child_transforms.childCount > 0)
            {
                temp_child_transforms = GetChildObjFind(temp_child_transforms, p_name);
                if (temp_child_transforms != null)
                {
                    return temp_child_transforms;
                }
            }

        }

        return null;
    }
    
}