using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
    public class GemCheckAT : ActionTask
    {
        public BBParameter<Transform> gemcheckpoint;
        public BBParameter<Vector3> destination;
        public BBParameter<bool> isChasing;
        public BBParameter<bool> isGemExist;
        public BBParameter<NavMeshAgent> navAgent;



        protected override string OnInit()
        {

            return null;
        }

        protected override void OnExecute()
        {
            navAgent.value.SetDestination(gemcheckpoint.value.position);
            isChasing.value = !isGemExist.value;
        }

        protected override void OnUpdate()
        {
            if (!navAgent.value.pathPending &&
                          navAgent.value.remainingDistance <= navAgent.value.stoppingDistance)
            {
                EndAction(true);
            }
        }
    }
}