using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Inheritance
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy")]
        public Transform target;
        public int health = 100;
        public int damage = 20;
        public float attackRange = 2f;
        public float attackRate = 0.5f;
        public float attackDuration = 1f;

        protected Rigidbody rigid;
        protected NavMeshAgent nav;

        private float attackTimer = 0f;
        

        protected virtual void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }
        protected virtual void OnAttackEnd()
        {

        }
        protected virtual void Attack()
        {
            
        }           
        
        IEnumerator AttackDelay(float delay)
        {
            // stop navigation
            nav.Stop();
            yield return new WaitForSeconds(delay);
            // resume navigation
            nav.Resume();
            // Call OnAttackEnd()
            OnAttackEnd();
        }   
                
        protected virtual void Update()
        {
            if(target == null)
            {
                return;
            }
            // Increase Attack timer
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                // Get distance from enemy to target
                float distance = Vector3.Distance(transform.position, target.position);
                // IF distance < attack range
                if (distance < attackRange)
                {
                    // Call Attack()
                    Attack();
                    // reset attack timer
                    attackTimer = 0f;
                    // Start 
                    StartCoroutine(AttackDelay(attackDuration));
                }
            }               
                // Navigate to target
                nav.SetDestination(target.position);
            
        }
    }
}
