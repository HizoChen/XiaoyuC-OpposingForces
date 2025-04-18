using NodeCanvas.Framework;

using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SeekTask : ActionTask
	{

		public BBParameter<bool> hasTarget;
		public BBParameter<Vector3> targetPosition;
        public BBParameter<Transform> target;
    

		protected override void OnUpdate()
		{
			hasTarget.value = target != null;
			if (target == null) EndAction(true);
			targetPosition.value = target.value.position;
		}
	}
}