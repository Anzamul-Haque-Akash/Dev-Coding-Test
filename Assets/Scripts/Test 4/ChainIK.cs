using UnityEngine;

public class ChainIK : MonoBehaviour
{

    [SerializeField] private Transform m_Target;

    // TODO: implement chain ik system where the tip of the chain follows the m_Target

    //Anzamul Haque Akash------------------------------------------------------------------------------------------------Start
    [SerializeField] private GameObject[] m_chain; //Here I store chain objects
    [Range(1,20)]
    [SerializeField] private int m_topNodespeed; //Speed Range value(top node)

    //Fixed Update function
    private void FixedUpdate()
    {
        
        //If start to goal distance < then total chain distance this function is call
        if (Vector3.Distance(m_chain[0].transform.position, m_Target.position) < 12f && Vector3.Distance(m_chain[6].transform.position, m_Target.transform.position) > 0.4f)
        {
            DistanceLesserThenTotalChainDistance();
        }
        //If start to goal distance > then total chain distance this function is call
        if (Vector3.Distance(m_chain[0].transform.position, m_Target.position) != Vector3.Distance(m_chain[0].transform.position, m_chain[6].transform.position) + Vector3.Distance(m_chain[6].transform.position, m_Target.position))
        {
            if (Vector3.Distance(m_Target.transform.position, m_chain[0].transform.position) > 12f){
                DistanceBiggerThenTotalChainDistance();
            }
        }

        m_chain[6].transform.LookAt(m_Target.position); //Always top node look at the target node.

    }
    //================
    private void DistanceBiggerThenTotalChainDistance() //If start to goal distance bigger then total chain distance this function is call
    {
        Vector3 velocity = Vector3.zero;
        m_chain[6].transform.position = Vector3.SmoothDamp(m_chain[6].transform.position, m_Target.position, ref velocity, 0.1f);

    }
    //================

    //================
    private void DistanceLesserThenTotalChainDistance() //If start to goal distance lesser then total chain distance this function is call
    {
        Vector3 velocity = Vector3.zero;
        m_chain[6].transform.position = Vector3.SmoothDamp(m_chain[6].transform.position, m_Target.position, ref velocity, 0.05f);
    }
    //================
    //Anzamul Haque Akash------------------------------------------------------------------------------------------------End
}