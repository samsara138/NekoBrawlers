using UnityEngine;
using UnityEngine.AI;

namespace RTSFramework.Interactables.Units
{
    public class RTSUnit : MonoBehaviour
    {
        // Unit Attributes
        public string unitName = "Unit";
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


        public void MoveToPoint(Vector3 destination)
        {
            NavMeshAgent.SetDestination(destination);
        }

        public void OnSelect()
        {
        }
    }
}
