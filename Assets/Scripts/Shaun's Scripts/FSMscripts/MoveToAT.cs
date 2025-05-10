using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToAT : ActionTask {

        public BBParameter<NavMeshAgent> navAgent;
        public BBParameter<Transform> destination;

        protected override void OnExecute()
        {

            navAgent.value.SetDestination(destination.value.position);
        }

        protected override void OnUpdate()
        {
            if (!navAgent.value.pathPending)
            {
                if (navAgent.value.remainingDistance <= navAgent.value.stoppingDistance)
                {
                    if (!navAgent.value.hasPath || navAgent.value.velocity.sqrMagnitude == 0)
                        EndAction(true);
                }
            }
        }

        protected override void OnStop()
        {
            navAgent.value.ResetPath();
        }
    }
}