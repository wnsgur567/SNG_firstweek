﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRayReciever : MonoBehaviour
{
    public bool On;   

    private void Awake()
    {
        On = false;        
    }

    private enum E_ColliderType
    {
        None = 0,
        Box,
        Sphere,
        Capsule,

        Max
    }

    [System.Serializable]
    struct CapsuleColliderInfo
    {
        public float radius;
        public float height;
    }

    
    public bool IsTrigger;

    [ContextMenuItem("UpdateCollider", "UpdateColliderComponent")]
    [SerializeField, Header("변경 시 Update 해주세요")]
    private E_ColliderType colliderType;


    [Space(10)]
    [SerializeField, Tooltip("BoxCollider")]
    Vector3 m_boxSize;
    [SerializeField, Tooltip("SphereCollider")]
    float m_sphereRadius;
    [SerializeField, Tooltip("CapsuleCollder")]
    CapsuleColliderInfo m_capsuleSize;

#if UNITY_EDITOR
    private void UpdateColliderComponent()
    {
        var _collider = GetComponent<Collider>();
        if (_collider != null)
            DestroyImmediate(_collider);

        switch (colliderType)
        {            
            case E_ColliderType.Box:
                BoxCollider _c1 = this.gameObject.AddComponent<BoxCollider>();
                _c1.isTrigger = IsTrigger;
                _c1.size = m_boxSize;
                
                break;
            case E_ColliderType.Sphere:
                SphereCollider _c2 = this.gameObject.AddComponent<SphereCollider>();
                _c2.radius = m_sphereRadius;
                _c2.isTrigger = IsTrigger;
                break;
            case E_ColliderType.Capsule:
                CapsuleCollider _c3 = this.gameObject.AddComponent<CapsuleCollider>();
                _c3.radius = m_capsuleSize.radius;
                _c3.height = m_capsuleSize.height;
                _c3.isTrigger = IsTrigger;
                break;            
        }        
    }
   
#endif
}
