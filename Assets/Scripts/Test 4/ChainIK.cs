using UnityEngine;

public class ChainIK : MonoBehaviour
{
    [SerializeField] private Transform m_Target;

    // TODO: implement chain ik system where the tip of the chain follows the m_Target

    //Anzamul Haque Akash------------------------------------------------------------------------------------------------Start
    [SerializeField] private GameObject[] m_chain; //Here I store chain objects

    //Fixed Update function
    private void FixedUpdate()
    {
        ChildNodeUpdatePosition(); //Child Nodes update position function call

        //If start to goal distance < then total chain distance then this function is call
        if (Vector3.Distance(m_chain[0].transform.position, m_Target.position) < 12f)
        {
            DistanceLesserThenTotalChainDistance();
        }
        //If start to goal distance > then total chain distance then this function is call
        if (Vector3.Distance(m_chain[0].transform.position, m_Target.position) > 12f)
        {
            if (Input.GetMouseButton(0))
            {
                DistanceBiggerThenTotalChainDistance();
            }
            else if(Vector3.Distance(m_chain[0].transform.position, m_chain[6].transform.position) > 12f)
            {
                Vector3 velocity = Vector3.zero;
                m_chain[6].transform.position = Vector3.SmoothDamp(m_chain[6].transform.position, m_chain[0].transform.position, ref velocity, 0.1f);
            }
        }
    }
    //================
    private void DistanceBiggerThenTotalChainDistance() //If start to goal distance bigger then total chain distance then this function is call
    {
        m_chain[6].transform.LookAt(m_Target.position); //Always top node look at the target node.
        Vector3 velocity = Vector3.zero;
        m_chain[6].transform.position = Vector3.SmoothDamp(m_chain[6].transform.position, m_Target.position, ref velocity, 0.3f);
    }
    //================

    //================
    private void DistanceLesserThenTotalChainDistance() //If start to goal distance lesser then total chain distance then this function is call
    {
        m_chain[6].transform.LookAt(m_Target.position); //Always top node look at the target node.
        Vector3 velocity = Vector3.zero;
        m_chain[6].transform.position = Vector3.SmoothDamp(m_chain[6].transform.position, m_Target.position, ref velocity, 0.05f);
    }
    //================



    public void ChildNodeUpdatePosition() //Child Nodes update position function
    {
        for(int i=5; i>0; i--)
        {
            m_chain[i].transform.LookAt(m_chain[i+1].transform.position);

            if (Vector3.Distance(m_chain[i].transform.position, m_chain[i+1].transform.position) > 2f) {
                Vector3 velocity = Vector3.zero;
                m_chain[i].transform.position = Vector3.SmoothDamp(m_chain[i].transform.position, m_chain[i+1].transform.position, ref velocity, 0.06f);
            }

        }

        for (int i=1; i < 6 ; i++)
        {
            if (Vector3.Distance(m_chain[i].transform.position, m_chain[i - 1].transform.position) > 2f)
            {
                Vector3 velocity = Vector3.zero;
                m_chain[i].transform.position = Vector3.SmoothDamp(m_chain[i].transform.position, m_chain[i - 1].transform.position, ref velocity, 0.06f);
            }

        }

        m_chain[0].transform.LookAt(m_chain[1].transform.position);
    }
    //Anzamul Haque Akash------------------------------------------------------------------------------------------------End

}