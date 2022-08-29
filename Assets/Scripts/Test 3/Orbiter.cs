using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    [SerializeField] private Attractor m_AttractorA;
    [SerializeField] private Attractor m_AttractorB;

    [SerializeField] private float m_RPMSpeed;


    private Attractor _currentlyRotatingAround;

    private void Start()
    {
        ChangeAttractor(m_AttractorA);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentlyRotatingAround == m_AttractorA)
            {
                ChangeAttractor(m_AttractorB);
            }
            else
            {
                ChangeAttractor(m_AttractorA);
            }

            
        }

        KeepRotating();
    }


    private bool ChangeAttractor(Attractor attractor)
    {
        float distance = Vector3.Distance(transform.position, attractor.Position);
        if(distance > attractor.Radius) return false;
        
        _currentlyRotatingAround = attractor;

        // TODO: Implement rest of the function if needed

        //---------Anzamul Haque Akash-----------------------------Start
        
        //---------Anzamul Haque Akash-----------------------------End


        return true;
    }

    void KeepRotating()
    {
        // TODO: Implement the function for rotation

        //---------Anzamul Haque Akash-----------------------------Start

        transform.RotateAround(GameObject.Find("A").GetComponent<Transform>().transform.position, Vector3.up, m_RPMSpeed  * Time.deltaTime);

        //---------Anzamul Haque Akash-----------------------------End
    }
}
