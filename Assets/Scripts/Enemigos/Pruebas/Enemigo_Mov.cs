using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class Enemigo_Mov : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public GameObject target;
        public Vida vida_enemigo;// target to aim for


        private void Awake()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
            target=GameObject.FindWithTag("Player");
        }


        public void Update()
        {
            if (target != null)
                agent.SetDestination(target.transform.position);
            if(vida_enemigo.barra_vida.fillAmount > 0)
            {
                if (agent.remainingDistance > agent.stoppingDistance)
                {
                    character.Move(agent.desiredVelocity, false, false);
                }
                else
                {
                    character.Move(Vector3.zero, false, false);
                }
            }
            else
            {
                agent.Stop();
            }
            
               
        }


        public void SetTarget(GameObject target)
        {
            this.target = target;
        }
    }
}
