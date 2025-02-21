using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class VariableCheckCT : ConditionTask {

		public BBParameter<float> variable;
		public float minimumValue;

		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}


		protected override bool OnCheck() {
			return variable.value >= minimumValue; //to check if a variable has reached a minimum value
		}
	}
}