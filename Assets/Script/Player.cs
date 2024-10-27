using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpsForce;
    bool m_isGround;
    Rigidbody2D m_rb;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip jumpsound, losesound;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKey(KeyCode.Space);
        if (isJumpKeyPressed && m_isGround && !m_gc.Is_GameOver())
        { 
            
            m_rb.AddForce(Vector2.up * jumpsForce);
            m_isGround = false;
            if (aus && jumpsound && !m_gc.Is_GameOver())
            {
                aus.PlayOneShot(jumpsound);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }            
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            if (aus && losesound && !m_gc.Is_GameOver())
            {
                aus.PlayOneShot(losesound);
            }
            m_gc.SetGameOverState(true);
            
            
            Debug.Log("Da va cham voi chuong ngai vat");
        }
    }
}
