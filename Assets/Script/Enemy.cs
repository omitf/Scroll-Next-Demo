using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Space]
    [Header("Enemy")]
    public bool BigEnemy;
    public bool BeginAttacks;
    public Transform Player;
    public Transform EnemyOriginalPos;
    private Transform OriginalPos = null;
    private Animator Anim;
    public float InitialMoveSpeed;
    public float MoveSpeed;
    Rigidbody rb;

    [Space]
    [Header("Player")]
    public JoystickPlayerExample player;

    [Space]
    [Header("ScriptManager")]
    public ScriptManager scriptManager;

    [Space]
    [Header("Button")]
    public Button Next;
    public Button Restart;
    public Button RestartAfterDeath;


    void Start()
    {
        OriginalPos = EnemyOriginalPos.transform;
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Anim.SetBool("Idle", true);

        Button btnNext = Next.GetComponent<Button>();
        btnNext.onClick.AddListener(NextTaskOnClick);

        Button btnRestart = Restart.GetComponent<Button>();
        btnRestart.onClick.AddListener(RestartTaskOnClick);

        Button btnRestartAfterDeath = RestartAfterDeath.GetComponent<Button>();
        btnRestartAfterDeath.onClick.AddListener(RestartAfterDeathTaskOnClick);
    }
     
    void Update()
    {
        if (player.IsRunning && !player.Dead)
        {
            BeginAttacks = true;
            transform.LookAt(Player);
            InitialMoveSpeed-= 0.025f + Time.deltaTime;

            if (InitialMoveSpeed < MoveSpeed)
            {
                InitialMoveSpeed = MoveSpeed;
            }

            if (BigEnemy)
            {
                transform.LookAt(player.gameObject.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, InitialMoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.position + new Vector3(0, 0, 1), InitialMoveSpeed * Time.deltaTime);
            }
            Anim.SetBool("Run", true);
            Anim.SetBool("Idle", false);
        }
        else if (player.Dead)
        {
            BeginAttacks = false;
            Anim.SetBool("Run", false);
            Anim.SetBool("Idle", true);
        }
    }

    public void ResetPosition()
    {
        gameObject.transform.position = OriginalPos.position;
        Anim.SetBool("Run", false);
        Anim.SetBool("Idle", true);
        gameObject.SetActive(true);
        rb.velocity = new Vector3(0,0,0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            Anim.SetBool("Run", false);
            Anim.SetBool("Idle", true);
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Trap" && !player.Dead)
        {
            rb.AddForce(Vector3.back * InitialMoveSpeed * 100);
        }

    }

    void NextTaskOnClick()
    {

    }
    void RestartTaskOnClick()
    {
        ResetPosition();
    }
    void RestartAfterDeathTaskOnClick()
    {
        ResetPosition();
    }
}
