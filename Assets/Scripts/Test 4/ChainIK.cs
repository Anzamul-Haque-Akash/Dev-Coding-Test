using UnityEngine;

public class ChainIK : MonoBehaviour
{

    [SerializeField] private Transform m_Target;


    // TODO: implement chain ik system where the tip of the chain follows the m_Target

    //Anzamul Haque Akash------------------------------------------------------------------------------------------------Start
    [SerializeField] private GameObject[] m_chain; //Here I store chain objects
    private float m_distanceStartFromGoal; // Distance Start From Goal variable

    //Update function
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ChainMoveIK();
        }
    }
    //================
    private void ChainMoveIK() //Chain Move function
    {
        m_distanceStartFromGoal = Vector3.Distance(m_Target.transform.position, m_chain[0].transform.position); //Calculate start to goal distance

        if(m_distanceStartFromGoal >= 12f) //start to goal distance bigger then total chain distance 
        {
            DistanceBiggerThenTotalChainDistance();
        }
        else //start to goal distance lesser then total chain distance 
        {
            DistanceLesserThenTotalChainDistance();
        }
    }
    //================
    private void DistanceBiggerThenTotalChainDistance() //If start to goal distance bigger then total chain distance this function is call
    {
        m_chain[0].transform.LookAt(m_Target); //Root Node jast use LookAt(Buildin) function
    }
    //================
    private void DistanceLesserThenTotalChainDistance() //If start to goal distance lesser then total chain distance this function is call
    {

    }
    //Anzamul Haque Akash------------------------------------------------------------------------------------------------End
}