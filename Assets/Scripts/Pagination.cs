using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pagination : MonoBehaviour
{
    [SerializeField] private Button m_Previous;
    [SerializeField] private Button m_Next;

    public static Pagination Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        
        m_Next.onClick.AddListener(delegate
        {
            int nextBuildIndex = Mathf.Clamp(SceneManager.GetActiveScene().buildIndex + 1, 0, SceneManager.sceneCountInBuildSettings - 1);
            SceneManager.LoadScene(nextBuildIndex);
        });
        
        m_Previous.onClick.AddListener(delegate
        {
            int prevBuildIndex = Mathf.Clamp(SceneManager.GetActiveScene().buildIndex - 1, 0, SceneManager.sceneCountInBuildSettings - 1);
            SceneManager.LoadScene(prevBuildIndex);
        });
    }
}
