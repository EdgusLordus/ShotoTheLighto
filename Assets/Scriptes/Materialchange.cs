using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Materialchange : MonoBehaviour
{
    [SerializeField] Material selfoff;
    [SerializeField] Material selfon;
    [SerializeField] private GameObject Object;

    MeshRenderer Fenetre1;
    MeshRenderer Fenetre2;

    private bool allumer;
    private bool TouchedWindow;
    public int score;
    public int life;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    Camera m_Camera;

    void Awake()
    {
        m_Camera = Camera.main;
    }

    void Start()
    {
        allumer = false;
        TouchedWindow = false;
        score = 0;
        life = 4;
        SetScoreText();
        SetLifeText();
        StartCoroutine("Spawn0");
    }

    IEnumerator Wnd_Clicked()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0) && allumer == true && TouchedWindow == true)
            {
                Object.GetComponent<MeshRenderer>().material = selfoff;
                allumer = false;
                TouchedWindow = false;
                score = score + 1;
                SetScoreText();
            }
            yield return null;
        }
    }
    IEnumerator Spawn0()
    {
        while (true)
        {
            Object.GetComponent<MeshRenderer>().material = selfon;
            allumer = true;
            yield return new WaitForSecondsRealtime(0.5f);
            if (allumer == true)
            {
                life = life - 1;
                SetLifeText();
                if (life <= 0)
                {
                    Application.Quit();
                }
            }
            float v = Random.Range(0.0f, 10.0f);
            yield return new WaitForSecondsRealtime(v);
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score " + score.ToString();
    }

    void SetLifeText()
    {
        lifeText.text = "Life " + life.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                TouchedWindow = true;
                StartCoroutine("Wnd_Clicked");
            }
        }
    }
}