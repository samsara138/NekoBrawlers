using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSFramework.WorldManagment
{
    public enum SpawnObjectType
    {
        None = 0,
        Unit = 1,
        Building,
        Misc = 50
    }

    [System.Serializable]
    public class RTSObjectSpawner
    {
        [SerializeField]
        private Transform UnitContainer;

        [SerializeField]
        private Transform BuildingContainer;

        [SerializeField]
        private Transform MiscContainer;

        public GameObject SpawnObject(GameObject prefab, Transform ObjectSpawnPoint, SpawnObjectType spawnObjectType)
        {
            return SpawnObject(prefab, ObjectSpawnPoint.position, ObjectSpawnPoint.rotation, spawnObjectType);
        }

        public GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation, SpawnObjectType spawnObjectType)
        {
            GameObject obj = GameObject.Instantiate(prefab, position, rotation);
            switch (spawnObjectType)
            {
                case SpawnObjectType.None:
                    obj.transform.SetParent(MiscContainer);
                    break;
                case SpawnObjectType.Unit:
                    obj.transform.SetParent(UnitContainer);
                    break;
                case SpawnObjectType.Building:
                    obj.transform.SetParent(BuildingContainer);
                    break;
                case SpawnObjectType.Misc:
                    obj.transform.SetParent(MiscContainer);
                    break;
            }
            return obj;
        }

    }
}

