using UnityEngine;
using UnityEngine.AI;

namespace RTSFramework.Interactables.Units
{
    public abstract class RTSUnit : RTSInteractable
    {
        // Unit Attributes
        public int health = 100;
        public int maxHealth = 100;
        public int damage = 10;
        public float moveSpeed = 5.0f;
        public float attackRange = 2.0f;

        // Unit State
        protected bool isAlive = true;
        protected bool isMoving = false;
        protected bool isAttacking = false;

        public NavMeshAgent NavMeshAgent;

        [SerializeField]
        private GameObject destinationIndicatorPrefab;

        public override void OnClickGround(Vector3 point)
        {
            MoveToPoint(point);
        }

        public void MoveToPoint(Vector3 destination)
        {
            NavMeshAgent.SetDestination(destination);
        }
    }
}
