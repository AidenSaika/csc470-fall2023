using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCode : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Opendoor();
    }
    public void Opendoor()
    {
        if (Body_Move.BodygetOutKey || aircraft.AirgetOutKey)
        {
            animator.SetBool("IsOutKey",true);
            animator.Play("Door_1");
        }
    }

}
