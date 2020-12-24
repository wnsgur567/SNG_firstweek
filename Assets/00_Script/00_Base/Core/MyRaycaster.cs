using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HitObjectInformation
{
    public string name;
    public float distance;
    public Collider hitCollider;

    public HitObjectInformation(string _name, float _distance, Collider _hitCollider)
    {
        name = _name;
        distance = _distance;
        hitCollider = _hitCollider;
    }
}


public class MyRaycaster : MonoBehaviour
{
    public new Camera camera = null;
    [Tooltip("hitObject가 2개 이상인 경우 활성화")]
    public bool isMulti;
    [Tooltip("ray에 충돌하는 레이어 이름")]
    public List<string> layerNames;

    
    [Header("Hit 오브젝트 (단일)"),ReadOnly]
    public GameObject hitObject;    
    [Header("Hit 오브젝트 (다중)"),ReadOnly]
    public List<HitObjectInformation> hitObjects;

    private int cullingLayer;
    private void Awake()
    {
        cullingLayer = CullingLayer();
    }

    private void Update()
    {
        if (isMulti)
            UpdateHitObjects();
        else
            UpdateHitObject();        
    }

    private RaycastHit hit;
    private void UpdateHitObject()
    {
        UnshowReceiver(hitObject);
        hitObject = null;
        Ray _ray = MakeRay();
        if (Physics.Raycast(_ray, out hit))
        {
            hitObject = hit.transform.gameObject;
            ShowReceiver(hitObject);
        }        
    }

    private void UpdateHitObjects()
    {
        Ray _ray = MakeRay();
        var hits = Physics.RaycastAll(_ray);

        foreach (var item in hitObjects)
        {
            UnshowReceiver(item.hitCollider.gameObject);
        }
        hitObjects.Clear();
        foreach (var item in hits)
        {
            // 거리의 순서와 상관없이 저장됨
            hitObjects.Add(new HitObjectInformation(item.transform.name, item.distance, item.collider));
            ShowReceiver(item.collider.gameObject);            
            //Debug.LogFormat("{0} : {1}", item.transform.name, item.distance);
        }
    }

    private Ray MakeRay(float rayLenth = -1f)
    {
        float near = camera.nearClipPlane;
        float far = camera.farClipPlane;

        if (rayLenth < 0f || rayLenth > far)
            rayLenth = far;

        Ray _ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(_ray.origin, _ray.GetPoint(rayLenth),Color.red);
        return _ray;
    }

    // layerNames에서 검사할 레이어 추출
    private int CullingLayer()
    {
        int ret = 0;

        foreach (var item in layerNames)
        {
            ret = ret | LayerMask.GetMask(item);
        }
        Debug.LogFormat($"LayerCulling : {ret}");
        return ret;
    }
    
    private void ShowReceiver(GameObject p_Receiver_obj)
    {
        if (p_Receiver_obj == null)
            return;

        var _receiver = p_Receiver_obj.GetComponent<MyRayReciever>();
        if (_receiver != null)
        {
            _receiver.Show();
        }
    }

    private void UnshowReceiver(GameObject p_Receiver_obj)
    {
        if (p_Receiver_obj == null)
            return;

        var _receiver = p_Receiver_obj.GetComponent<MyRayReciever>();
        if (_receiver != null)
        {
            _receiver.UnShow();
        }
    }

}
