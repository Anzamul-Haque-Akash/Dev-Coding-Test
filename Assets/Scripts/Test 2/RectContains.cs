using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectContains : MonoBehaviour
{
    [SerializeField] private RectTransform m_A;
    [SerializeField] private RectTransform m_B;
    [SerializeField] private RectTransform m_C;
    [SerializeField] private RectTransform m_D;

    [SerializeField] private RectTransform m_LinePrefab;
    [SerializeField] private Material m_LineMat;
    
    
    
    void Start()
    {
        DrawRect();
    }

    private void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y) -
                                (new Vector2(Screen.width, Screen.height) / 2f); 
        

        if (CheckIfInsideRect(m_A.anchoredPosition, m_B.anchoredPosition, m_C.anchoredPosition, m_D.anchoredPosition,
                mousePosition))
        {
            m_LineMat.SetColor("_Color", Color.red);
        }
        else
        {
            m_LineMat.SetColor("_Color", Color.white);
        }
    }

    private bool CheckIfInsideRect(Vector2 posA, Vector2 posB, Vector2 posC, Vector2 posD, Vector2 positionToCheck)
    {
        // TODO: Implement this function

        //---------Anzamul Haque Akash-----------------------------Start
        static float area(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            return (float)Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        }

        static bool check(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, float x, float y)
        {

            //area ABCD
            float A = area(x1, y1, x2, y2, x3, y3) + area(x1, y1, x4, y4, x3, y3);

            //area XAB
            float A1 = area(x, y, x1, y1, x2, y2);

            //area XBC
            float A2 = area(x, y, x2, y2, x3, y3);

            //area XCD
            float A3 = area(x, y, x3, y3, x4, y4);

            //Area XAD
            float A4 = area(x, y, x1, y1, x4, y4);

            //return true if sum of A + A2 + A3 + A4 == A
            return (A == A1 + A2 + A3 + A4);
        }


        if (check(posA.x, posA.y, posB.x, posB.y, posC.x, posC.y, posD.x, posD.y, positionToCheck.x, positionToCheck.y))
        {
            return true;
        }

        //---------Anzamul Haque Akash-----------------------------End

        return false;
    }

    private void DrawRect()
    {
        DrawLine(m_A, m_B);
        DrawLine(m_B, m_C);
        DrawLine(m_C, m_D);
        DrawLine(m_D, m_A);
        
        void DrawLine(RectTransform a, RectTransform b)
        {
            RectTransform line1 = Instantiate(m_LinePrefab, transform);
            line1.localScale = new Vector3(1, (a.anchoredPosition - b.anchoredPosition).magnitude, 1);
            Vector2 delta = (b.anchoredPosition - a.anchoredPosition);
            line1.anchoredPosition = a.anchoredPosition + (delta / 2f);

            float angle = Mathf.Atan(delta.y / delta.x) * Mathf.Rad2Deg;
            line1.localEulerAngles = new Vector3(0, 0, 90 + angle);
            
            line1.transform.SetAsFirstSibling();
        }
    }

}
