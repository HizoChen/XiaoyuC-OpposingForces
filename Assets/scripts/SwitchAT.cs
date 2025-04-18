using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SwitchAT : ActionTask {
        public BBParameter<float> switchTimer;
        public BBParameter<float> switchTime;

		public BBParameter<bool> isRest;
		public BBParameter<bool> isToWork;
  
        protected override string OnInit() {
			return null;
		}

	
		protected override void OnExecute() {

		}

		
		protected override void OnUpdate() {
			switchTimer.value += Time.deltaTime;//Simulate the operation of time and design their shift conditions
            if (isToWork.value)
			{
				EndAction(true);
			}
			if(switchTimer.value>=switchTime.value )
			{
				switchTimer.value = 0;
				isToWork.value = isRest.value;
				EndAction(true);
			}
			EndAction(false);
		}

	
		protected override void OnStop() {
			
		}

	
		protected override void OnPause() {
			
		}
	}
}