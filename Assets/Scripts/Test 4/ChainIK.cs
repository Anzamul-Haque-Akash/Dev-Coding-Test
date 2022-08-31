using UnityEngine;

public class ChainIK : MonoBehaviour
{

    [SerializeField] private Transform m_Target;


    // TODO: implement chain ik system where the tip of the chain follows the m_Target

    //Anzamul Haque Akash------------------------------------------------------------------------------------------------Start
    [SerializeField] private GameObject[] m_chain; //Here I store chain objects
    private double m_distanceStartFromGoal; // Distance Start From Goal variable
    [Range(1,30)]
    [SerializeField] private int m_topNodespeed;
    Vector3 m_topNodeLookTargetDirection;

    //Fixed Update function
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) //Left mouse button click
        {
            ChainMoveIK();
        }
        else if(Vector3.Distance(m_chain[0].transform.position, m_chain[6].transform.position) > 12f) //Set start node to top node in 12.. distance if goal distance > 12.. from start
        {
            m_topNodeLookTargetDirection = (m_chain[0].transform.position - m_chain[6].transform.position).normalized;
            m_chain[6].transform.Translate(m_topNodeLookTargetDirection * Time.deltaTime * m_topNodespeed);
        }



        //If start to goal distance lesser then total chain distance this function is call
        if (Vector3.Distance(m_chain[0].transform.position, m_Target.transform.position) < 12f && Vector3.Distance(m_chain[6].transform.position, m_Target.transform.position) > 0.4f)
        {
            DistanceLesserThenTotalChainDistance();
        }
        //##########################################################################################

    }
    //================
    private void ChainMoveIK() //Chain Move function
    {
        m_distanceStartFromGoal = Vector3.Distance(m_Target.transform.position, m_chain[0].transform.position); //Calculate start to goal distance

        if(m_distanceStartFromGoal >= 12f) //start to goal distance bigger then total chain distance 
        {
            DistanceBiggerThenTotalChainDistance();
        }
    }
    //================
    private void DistanceBiggerThenTotalChainDistance() //If start to goal distance bigger then total chain distance this function is call
    {
        float m_stopDistance = Vector3.Distance(m_chain[0].transform.position, m_Target.transform.position) - 12f;

        if (Vector3.Distance(m_chain[6].transform.position, m_Target.transform.position) > m_stopDistance){

            m_topNodeLookTargetDirection = (m_Target.position - m_chain[6].transform.position).normalized;
            m_chain[6].transform.Translate(m_topNodeLookTargetDirection * Time.deltaTime * m_topNodespeed);
        }
    }
    //================

    //================
    private void DistanceLesserThenTotalChainDistance() //If start to goal distance lesser then total chain distance this function is call
    {
        m_topNodeLookTargetDirection = (m_Target.position - m_chain[6].transform.position).normalized;
        m_chain[6].transform.Translate(m_topNodeLookTargetDirection * Time.deltaTime * m_topNodespeed);
    }
    //================
    //Anzamul Haque Akash------------------------------------------------------------------------------------------------End
}