using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scriptNPC : MonoBehaviour
{

    private NavMeshAgent agente;
    public GameObject pc;
    public GameObject[] waypoints = new GameObject[5];
    private int index = 0;
    public float maxDist = 3;
    private bool perseguicao = false;
    public  float maxDistAlvo = 10;
    public LayerMask mascara;


    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        proximo();
    }

    private void proximo()
    {   
        agente.SetDestination(waypoints[index++].transform.position);

        if(index >= waypoints.Length)
            index = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //PERSEGUIÇÃO
        if(perseguicao || Vector3.Distance(transform.position, pc.transform.position) <= maxDistAlvo)
        {
            perseguicao = true;
            agente.SetDestination(pc.transform.position);
        } 
        else if(Vector3.Distance(transform.position, agente.destination) < maxDist)
            proximo();

        //MATA PLAYER
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, mascara))
        {
            Destroy(hit.collider.gameObject);
        }
    }

}
