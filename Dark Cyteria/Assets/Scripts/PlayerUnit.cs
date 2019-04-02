using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class PlayerUnit : NetworkBehaviour
{
    NavMeshAgent nma;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority)
        {
            DoMovement();
        }
    }

    void DoMovement()
    {
        if (nma == null)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100))
            {
                nma.destination = hitInfo.point;
            }
        }
    }
}
