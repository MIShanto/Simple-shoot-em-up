using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
       // public string objectName;
        [HideInInspector] public string objectName;

        public GameObject poolObject;

        [Tooltip("The default capacity the stack will be created with.")]
        public int poolStackSize;

        [Tooltip("The maximum size of the pool. When the pool reaches the max size then any further instances returned to the pool will be ignored and can be garbage collected. This can be used to prevent the pool growing to a very large size.")]
        public int poolMaxSize;

        public ObjectPool<GameObject> _pool;
    }

    public List<Pool> pools = new List<Pool>();

    public static PoolManager instance = null;

    Quaternion rotation = Quaternion.identity;
    private void Awake()
    {
        CreatePools();
    }

    private void CreatePools()
    {
        foreach (Pool pool in pools)
        {
            pool._pool = new ObjectPool<GameObject>(
                () =>
                {
                    GameObject obj = Instantiate(pool.poolObject, parent: transform);
                    obj.SetActive(false);

                    return obj;
                },
                (obj) =>
                {
                    obj.SetActive(true);
                },
                (obj) =>
                {
                    obj.SetActive(false);
                    obj.transform.position = Vector3.zero;
                },
                (obj) =>
                {
                    Destroy(obj);
                },
                false, pool.poolStackSize, pool.poolMaxSize);

            pool.objectName = pool.poolObject.name;
        }
    }

    private void OnTakeFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }
    private void onReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = Vector3.zero;
    }
    private void OnDestroyObj(GameObject obj)
    {
        Destroy(obj);
    }

    public GameObject GetObjFromPool(GameObject obj)
    {
        var pool =  pools.Find(x => x.objectName.Equals(obj.name));

        if (pool != null)
            return pool._pool.Get();
        else
        {
            Debug.LogError("No such pool to get");
            return null;
        }
    }
    public GameObject GetObjFromPool(GameObject obj, Quaternion rot)
    {
        rotation = rot;

        return GetObjFromPool(obj);

    }
    public void ReturnObjToPool(GameObject obj)
    {
        var pool = pools.Find(x => x.objectName.Equals(obj.name));

        if (pool != null)
            pool._pool.Release(obj);
        else
        {
            Debug.LogError("No such pool to return");
        }
    }
}
