using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class SwimAT : ActionTask {

		//enum for the different types of swimming
        public enum SwimDirection { Targeted, Explore}
		public SwimDirection swimDirection;

        public BBParameter<float> speed; //swim speed
        public float patrolRadius; //the max radius the turtle would be able to patrol to
		public BBParameter<Transform> target; //the target the turtle will swim to IF its swim direction is targeted

        private NavMeshAgent navAgent;
        private Animator animator;

        public BBParameter<bool> seaweedFound;
        public BBParameter<GameObject> currentSeaweed;

		protected override string OnInit() {
			animator = agent.GetComponentInChildren<Animator>();
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            animator.SetBool("Swimming", true);
            navAgent.speed = speed.value;

            if (seaweedFound.value)
            {
                //if the turtle has found a seaweed, override and make that the swim target
                target = currentSeaweed.value.transform;
            }
 
            if (swimDirection == SwimDirection.Targeted)
            {
                //swim to target
                navAgent.SetDestination(target.value.position);

            }
            else if (swimDirection == SwimDirection.Explore)
            {
                //patrol movement
                Vector3 randomPointDirection = Random.insideUnitSphere * patrolRadius;
                Vector3 randomPoint = randomPointDirection.normalized * patrolRadius + agent.transform.position;

                NavMeshHit navHit;
                if (!NavMesh.SamplePosition(randomPoint, out navHit, patrolRadius, NavMesh.AllAreas))
                {
                    return;
                }
                navAgent.SetDestination(navHit.position);
            }
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate() {
            //when arrived, end task
            if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
            animator.SetBool("Swimming", false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
            animator.SetBool("Swimming", false);
        }
	}
}