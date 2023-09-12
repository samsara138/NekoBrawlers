using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSFramework.WorldManagment
{
    [System.Serializable]
    public class RTSObjectSpawner
    {
        [SerializeField]
        private Transform UnitContainer;

        public GameObject SpawnUnit(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            GameObject obj = GameObject.Instantiate(prefab, position, rotation);
            obj.transform.SetParent(UnitContainer);
            return obj;
        }

        public GameObject SpawnUnit(GameObject prefab, Transform ObjectSpawnPoint)
        {
            GameObject obj = GameObject.Instantiate(prefab, ObjectSpawnPoint.position, ObjectSpawnPoint.rotation);
            obj.transform.SetParent(UnitContainer);
            return obj;
        }
    }
}

