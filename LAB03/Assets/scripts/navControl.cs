using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class navControl : MonoBehaviour
{

    public GameObject Target;
    private NavMeshAgent agent;
    bool isWalking = true;
    private Animator animator;
    public GameObject Dragon;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            agent.destination = Target.transform.position;
            animator.speed = agent.speed - 1f;
        }
        else
        {
            agent.destination = transform.position;
            animator.speed = 1;
        }
        transform.LookAt(Dragon.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
     if (other.tag == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("Walk");
        }   
    }
}
