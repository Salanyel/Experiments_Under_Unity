using System.Collections.Generic;
using UnityEngine;

namespace _04_ObjectsPool
{
    public class ObjectPool : MonoBehaviour
    {
        PooledObject _prefab;

        List<PooledObject> _availableObjects = new List<PooledObject>();
        /// <summary>
        /// Get the object saved
        /// </summary>
        /// <returns>PooledObject</returns>
        public PooledObject GetObject()
        {
            PooledObject obj;
            int lastAvailableIndex = _availableObjects.Count - 1;
            if (lastAvailableIndex >= 0)
            {
                obj = _availableObjects[lastAvailableIndex];
                _availableObjects.RemoveAt(lastAvailableIndex);
                obj.gameObject.SetActive(true);
            } 
            else
            {
                obj = Instantiate<PooledObject>(_prefab);
                obj.transform.SetParent(transform, false);
                obj.Pool = this;
            }
                    
            return obj;
        }

        /// <summary>
        /// Add an object to the pool
        /// </summary>
        /// <param name="p_obj"></param>
        public void AddObject(PooledObject p_obj)
        {
            p_obj.gameObject.SetActive(false);
            _availableObjects.Add(p_obj);
        }

        /// <summary>
        /// Get the pool of an object by adding it<!---->
        /// </summary>
        /// <param name="p_prefab">PooledObject</param>
        /// <returns>ObjectPool</returns>
        public static ObjectPool GetPool(PooledObject p_prefab)
        {
            GameObject obj = new GameObject(p_prefab.name + " Pool");
            ObjectPool pool = obj.AddComponent<ObjectPool>();
            pool._prefab = p_prefab;
            return pool;
        }
    }
}