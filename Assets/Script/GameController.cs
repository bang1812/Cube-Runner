using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnTime;
    float m_spawnTime;
    int m_score;
    bool is_GameOver;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindFirstObjectByType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (is_GameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void SpawnObstacle()
    {
        float randYpos = Random.Range(-3.5f, -1.4f);
        Vector2 spawnPos = new Vector2(11, randYpos);
        if (obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public int Score()
    {
        return m_score;
    }
    public bool Is_GameOver()
    {
        return is_GameOver;
    }
    public void ScoreIncrement()
    {
        if (is_GameOver)
        {
            return;
        }
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
        
    }
    public void SetGameOverState(bool value)
    {
        is_GameOver = value;
    }
}
