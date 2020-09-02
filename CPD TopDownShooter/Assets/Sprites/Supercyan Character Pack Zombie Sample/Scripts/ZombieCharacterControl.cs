using UnityEngine;
using System.Collections.Generic;

public class ZombieCharacterControl : MonoBehaviour
{

    [SerializeField] private float m_moveSpeed = 2;

    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;




    void Awake()
    {
        if(!m_animator) { gameObject.GetComponent<Animator>(); }
        if(!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void Update()
    {
        m_animator.SetFloat("MoveSpeed", 6);
    }



}
