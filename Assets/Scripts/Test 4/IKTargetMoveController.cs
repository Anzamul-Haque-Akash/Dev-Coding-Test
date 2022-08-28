using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTargetMoveController : MonoBehaviour
{
    private Vector3 _lastPosition;

    [SerializeField] private float m_MoveSpeed;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _lastPosition;
            transform.position += new Vector3(delta.x, 0, delta.y) * m_MoveSpeed / Screen.dpi * Time.deltaTime;
        }
    }
}
