using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor.Search;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class LayEggsAT : ActionTask {

        private Animator animator;

        public float eggTime;
        private float eggTimer;

        public BBParameter<bool> spawnEgg;
        public BBParameter<float> eggProgress;

        protected override string OnInit() {
            //get components
            animator = agent.GetComponentInChildren<Animator>();
            return null;
		}


		protected override void OnExecute() {
            animator.SetBool("LayEggs", true); //start lay eggs animation
            spawnEgg.value = true; //triggers in the egg manager script to spawn the eggs

            eggTimer = 0f;
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            eggTimer += Time.deltaTime;
            if (eggTimer >= eggTime)
            {
                //once the laying egg timer has completed, reset egg progress and end the action
                eggProgress.value = 0;
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
            animator.SetBool("LayEggs", false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
            animator.SetBool("LayEggs", false);
        }
	}
}