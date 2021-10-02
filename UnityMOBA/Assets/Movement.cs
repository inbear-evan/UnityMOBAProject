using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    public float rotayeSpeedMove = 0.1f;
    float rotateVelocity;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y,ref rotateVelocity, rotayeSpeedMove *(Time.deltaTime*5));

                transform.eulerAngles = new Vector3(0, rotY, 0);
            }

        }
    }
}
