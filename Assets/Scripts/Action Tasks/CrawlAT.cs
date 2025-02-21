using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class CrawlAT : ActionTask {

        public BBParameter<float> speed; //crawl has a different speed than swim
        public BBParameter<Transform> target;

        private NavMeshAgent navAgent;
        private Animator animator;

        protected override string OnInit() {
            animator = agent.GetComponentInChildren<Animator>();
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            //set destination to the chosen target
            animator.SetBool("Crawling", true);
            navAgent.SetDestination(target.value.position);

            navAgent.speed = speed.value;
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
            animator.SetBool("Crawling", false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
            animator.SetBool("Crawling", false);
        }
	}
}