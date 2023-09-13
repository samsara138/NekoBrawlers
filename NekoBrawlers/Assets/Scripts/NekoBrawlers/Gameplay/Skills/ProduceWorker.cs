using RTSFramework.WorldManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSFramework.Interactables.Skills
{
    public class ProduceWorker : RTSSkill
    {
        [SerializeField]
        private GameObject ProductionUnitPrefab;

        [SerializeField]
        private Transform ProductionUnitSpawnPoint;

        public override void UseSkill()
        {
            base.UseSkill();
            RTSWorldManager.Instance.RTSObjectSpawner.SpawnUnit(ProductionUnitPrefab, ProductionUnitSpawnPoint);
        }
    }
}

