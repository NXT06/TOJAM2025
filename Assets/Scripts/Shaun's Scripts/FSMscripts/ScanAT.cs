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
        public BBParameter<SpriteRenderer> spriteRenderer;
        public BBParameter<Animator> animator;
        public BBParameter<Light> visionConeLight;
        public BBParameter<AudioSource> audioSource;
        Transform targetSeat; 
        protected override void OnExecute()
        {
            playerTransform.value = GameObject.FindWithTag("Player").transform;
            audioSource.value = GameObject.FindWithTag("Audio").GetComponent<AudioSource>();

            navAgent.value = agent.GetComponent<NavMeshAgent>();
            visionConeLight.value = agent.GetComponentInChildren<Light>();
            animator.value = agent.GetComponentInChildren<Animator>();
            spriteRenderer.value = agent.GetComponentInChildren<SpriteRenderer>();


            
           // if (targetSeat = null) 
                targetSeat = DeskBehavior.CheckOccupied();

            targetTransform.value = targetSeat.transform;
           
            EndAction(true);
        }
    }
}