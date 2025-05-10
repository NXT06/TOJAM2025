using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Unity.IO.LowLevel.Unsafe;


namespace NodeCanvas.Tasks.Actions {

	public class ScanAT : ActionTask {

        public BBParameter<NavMeshAgent> navAgent;
        public BBParameter<Transform> targetTransform;
        public BBParameter<Transform> playerTransform;

        protected override void OnExecute()
        {
            playerTransform.value = GameObject.FindWithTag("Player").transform;
            navAgent.value = agent.GetComponent<NavMeshAgent>();

            Transform target = DeskBehavior.CheckOccupied();

            targetTransform.value = target.transform;
           
           
            EndAction(true);
        }
    }
}