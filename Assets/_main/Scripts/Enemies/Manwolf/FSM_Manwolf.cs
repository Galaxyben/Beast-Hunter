using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Manwolf : MonoBehaviour
{
    public Stage m_currentStage;
    public States m_currentState;

    [Header("Colliders")]
    public BoxCollider2D punchBox;
    public BoxCollider2D areaBox;

    private bool m_enter = true;
    private float m_counter = 0f;
    private Animator anim;
    private EnemyBasics eb;
    [SerializeField]private Vector2 moveDirection;

    public enum Stage
    {
        MAN,
        WOLF
    }

    public enum States
    {
        IDLE,
        FOLLOW,
        MELEE_ATTACK,
        AREA_ATTACK,
        TRANSFORMING
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        eb = GetComponent<EnemyBasics>();
        anim.SetTrigger("Transform");

        m_currentStage = Stage.WOLF;
        m_currentState = States.IDLE;
    }

    void Update()
    {
        moveDirection = Vector2.zero;
        if(eb.distanceFromTarget < 12f)
        {
            Vector2 direction = eb.target.transform.position - transform.position;
            direction.y = 0;
            if(direction.magnitude > 0.8f)
            {
                moveDirection = direction.normalized;
            }
        }
        FSM();
    }

    private void FixedUpdate()
    {
        if (m_currentState == States.FOLLOW)
        {
            eb.rigi.velocity = new Vector2(moveDirection.x * eb.moveSpeed * Time.deltaTime, eb.rigi.velocity.y);
            anim.SetFloat("Speed", eb.rigi.velocity.x);
        }
    }

    public void FSM()
    {
        switch (m_currentState)
        {
            case States.IDLE:
                if (m_enter)
                {
                    m_counter = 0;
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = false;
                }

                m_counter++;
                if (m_counter >= 250)
                {
                    m_currentState = States.FOLLOW;
                }

                if (m_currentStage == Stage.MAN)
                {

                }
                else
                {

                }

                if (m_currentState != States.IDLE)
                {
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = true;
                }
                break;
            case States.FOLLOW:
                if (m_enter)
                {
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = false;
                }

                if (m_currentStage == Stage.MAN)
                {

                }
                else
                {
                    if(eb.distanceFromTarget < 1)
                    {
                        ChangeState(Random.Range(3, 4));
                    }
                }

                if (m_currentState != States.FOLLOW)
                {
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = true;
                }
                break;
            case States.MELEE_ATTACK:
                if (m_enter)
                {
                    anim.SetTrigger("Attack");
                    m_counter = 0;
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = false;
                }


                if (m_currentStage == Stage.MAN)
                {

                }
                else
                {

                }

                m_counter++;
                if (m_counter >= 250)
                {
                    m_currentState = States.IDLE;
                }

                if (m_currentState != States.MELEE_ATTACK)
                {

                    punchBox.enabled = false;
                    m_enter = true;
                }
                break;
            case States.AREA_ATTACK:
                if (m_enter)
                {
                    anim.SetTrigger("Area");
                    m_counter = 0;
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = false;
                }


                if (m_currentStage == Stage.MAN)
                {

                }
                else
                {

                }

                m_counter++;
                if (m_counter >= 250)
                {
                    m_currentState = States.IDLE;
                }

                if (m_currentState != States.AREA_ATTACK)
                {
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = true;
                }
                break;
            case States.TRANSFORMING:
                if (m_enter)
                {
                    punchBox.GetComponent<EnemyAttackBox>().damage = punchBox.GetComponent<EnemyAttackBox>().damage * 2;
                    areaBox.GetComponent<EnemyAttackBox>().damage = areaBox.GetComponent<EnemyAttackBox>().damage * 2;
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = false;
                }

                if (m_currentStage == Stage.MAN)
                {

                }
                else
                {

                }

                if (m_currentState != States.TRANSFORMING)
                {
                    if (m_currentStage == Stage.MAN)
                    {

                    }
                    else
                    {

                    }
                    m_enter = true;
                }
                break;
        }
    }

    public void ChangeState(States _state)
    {
        switch (_state)
        {
            case States.IDLE:
                m_currentState = States.IDLE;
                break;
            case States.FOLLOW:
                m_currentState = States.FOLLOW;
                break;
            case States.MELEE_ATTACK:
                m_currentState = States.MELEE_ATTACK;
                break;
            case States.AREA_ATTACK:
                m_currentState = States.AREA_ATTACK;
                break;
            case States.TRANSFORMING:
                m_currentState = States.TRANSFORMING;
                break;
        }
    }

    public void ChangeState(int _state)
    {
        switch (_state)
        {
            case 1:
                m_currentState = States.IDLE;
                break;
            case 2:
                m_currentState = States.FOLLOW;
                break;
            case 3:
                m_currentState = States.MELEE_ATTACK;
                break;
            case 4:
                m_currentState = States.AREA_ATTACK;
                break;
            case 5:
                m_currentState = States.TRANSFORMING;
                break;
        }
    }
}
