using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
    public class NavigationTask : ActionTask
    {
        NavMeshAgent navAgent;
        public BBParameter<float> speed;
        public BBParameter<float> originalSpeed = 10f;
        public BBParameter<Vector3> destination;
        public BBParameter<List<Transform>> waypoints;
        public BBParameter<bool> isRest;
        public BBParameter<Transform> rest;
        protected override string OnInit()//Initialize, by confirming their status and letting them reach the corresponding position
        {
            navAgent = agent.GetComponent<NavMeshAgent>();
            if (isRest.value)
            {
                
                destination.value = rest.value.position;
            }
            else
            {
                destination.value = waypoints.value[0].position;

            }
            speed.value = originalSpeed.value;
            return null;
        }

        protected override void OnExecute()
        {
            
        }

        protected override void OnUpdate()
        {
            navAgent.speed = speed.value;
            navAgent.SetDestination(destination.value);
            //update speed and destination to agent
        }
    }
}