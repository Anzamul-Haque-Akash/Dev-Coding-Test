using UnityEngine;
using UnityEngine.UI;

public class RectCorners : MonoBehaviour
{
    [SerializeField] private RectTransform m_Rect;

    private Vector2 a, b, c, d;

    [SerializeField] private RectTransform m_DA;
    [SerializeField] private RectTransform m_DB;
    [SerializeField] private RectTransform m_DC;
    [SerializeField] private RectTransform m_DD;

    [SerializeField] private Slider m_Slider;
    [SerializeField] private Button m_Button;
    
    
    
    void Start()
    {
        m_Slider.onValueChanged.AddListener(delegate(float value)
        {
            m_Rect.eulerAngles = new Vector3(0, 0, value * 360);
        });
        
        m_Button.onClick.AddListener(delegate
        {
            FindPoints();
            SetPoints();
        });
    }

    void FindPoints()
    {
        // TODO: set the positions of a, b, c, d 
        // Vector2 rectPos = m_Rect.anchoredPosition

        //---------Anzamul Haque Akash-----------------------------Start
        Vector3[] rectPos = new Vector3[4];
        m_Rect.GetWorldCorners(rectPos);

        a = new Vector2(rectPos[0].x - 960f, rectPos[0].y - 540f);
        b = new Vector2(rectPos[1].x - 960f, rectPos[1].y - 540f);
        c = new Vector2(rectPos[2].x - 960f, rectPos[2].y - 540f);
        d = new Vector2(rectPos[3].x - 960f, rectPos[3].y - 540f);
        //---------Anzamul Haque Akash-----------------------------End

    }


    private void SetPoints()
    {
        m_DA.anchoredPosition = a;
        m_DB.anchoredPosition = b;
        m_DC.anchoredPosition = c;
        m_DD.anchoredPosition = d;
    }
}
