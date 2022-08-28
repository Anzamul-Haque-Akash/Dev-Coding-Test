using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField] private float m_Radius;
    public float Radius => m_Radius;

    [SerializeField] private Direction m_Direction;

    public Direction Direction => m_Direction;

    public Vector3 Position => transform.position;
}

public enum Direction
{
    Clockwise,
    CounterClockwise
}
