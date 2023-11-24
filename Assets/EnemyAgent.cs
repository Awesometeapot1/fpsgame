using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    Gamecontroller gameController; // This will hold the reference to the GameController script.
    EnemyRespawner respawn;
    public Animator animator;
    public Transform goal;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Main Camera").GetComponent<Gamecontroller>();

        respawn = GameObject.Find("respawner").GetComponent<EnemyRespawner>();
        goal = GameObject.Find("SimplePeople_BusinessMan_Black").transform;
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>(); //5 
        agent.destination = goal.position; //6 
        animator.SetFloat("Speed_f", agent.velocity.magnitude);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            print("we hit an enemy");
            gameController.IncreaseScore(10);
            
            Destroy(gameObject);
            respawn.RespawnEnemy();
        }


    }
}
