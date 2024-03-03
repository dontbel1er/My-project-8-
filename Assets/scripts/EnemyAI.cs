using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerController player;
    private bool _isPlayerNoticed;
    public float viewAngle;
    public float damage = 30;
    private HealthBar _playerHealth;
    // Start is called before the first frame up
    // date
     private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
      
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = FindObjectOfType<HealthBar>();
    }

    private void Update()
    {
        ChaseUpdate();
        NoticePlayer();
        PatroUpdate();
        AttackUpdate();
    }


    // Update is called once per frame
    private void NoticePlayer()
    {
        var direction = player.transform.position - transform.position;
         if (Vector3.Angle(transform.forward, direction) < viewAngle) 
      {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
                else
                {
                    _isPlayerNoticed = false;
                }


            }
            else
            {
                _isPlayerNoticed = false;
            }

        }
        else
        {
            _isPlayerNoticed = false;
        }
         
        PatroUpdate();



    } 


    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }


   private void PatroUpdate()
    { if (!_isPlayerNoticed)
        {





            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();

            }


        }
    }
    private void ChaseUpdate()
    {
        if(_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <=_navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }
    
}

















