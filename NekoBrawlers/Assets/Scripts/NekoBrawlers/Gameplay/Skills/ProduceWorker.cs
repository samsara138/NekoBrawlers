using RTSFramework.Interactables.Units;
using RTSFramework.WorldManagment;
using UnityEngine;

namespace RTSFramework.Interactables.Skills
{
    public class ProduceWorker : RTSSkill
    {
        [SerializeField]
        private GameObject ProductionUnitPrefab;

        [SerializeField]
        private Transform ProductionUnitSpawnPoint;

        [SerializeField]
        private GameObject RallyPointPrefab;

        private GameObject RallyPointObjectBuf;

        private Vector3 RallyPoint;

        private void Start()
        {
            RallyPoint = ProductionUnitSpawnPoint.position;
        }

        public override void OnClickGround(Vector3 Point)
        {
            RallyPoint = Point;
            RallyPointObjectBuf = RTSWorldManager.Instance.RTSObjectSpawner.SpawnObject(RallyPointPrefab, Point, Quaternion.identity, SpawnObjectType.Misc);
        }

        public override void UseSkill()
        {
            GameObject obj = RTSWorldManager.Instance.RTSObjectSpawner.SpawnObject(ProductionUnitPrefab, ProductionUnitSpawnPoint, SpawnObjectType.Unit);
            WorkerUnit unit = obj.GetComponent<WorkerUnit>();
            if (unit != null)
            {
                unit.MoveToPoint(RallyPoint);
            }
        }

        public override void OnDeselect()
        {
            Destroy(RallyPointObjectBuf);
        }
    }
}

