using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickPlayerExample : MonoBehaviour
{
    [Space]
    [Header("Camera")]
    public CameraScript cam;

    [Space]
    [Header("Player")]
    public Transform PlayerOriginalPos;
    private Transform PlayerOrigPos;
    public Transform PlayerController;
    public Transform Goal;
    public float speed;
    public float SpeedTo;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    Vector3 movements;

    public bool AllowRun;
    public bool Finished;
    public bool Dead;
    private bool OneTime = true;
    public bool IsRunning;
    private Animator Anim;
    private int levelReached;

    [Space]
    [Header("Button")]
    public Button Starts;

    [Space]
    [Header("ScriptManager")]
    public ScriptManager scriptManager;
    public Text Status;

    void OnDrawGizmosSelected()
    {
    }
    public void Start()
    {
        PlayerOrigPos = PlayerOriginalPos;
        Anim = GetComponent<Animator>();
        Anim.SetBool("Idle", true);

        Button btnStart = Starts.GetComponent<Button>();
        btnStart.onClick.AddListener(StartTaskOnClick);
    }
    public void Update()
    {

        if (Dead == false && AllowRun && Finished == false)
        {
            movements.x = variableJoystick.Horizontal;
            movements.z = variableJoystick.Vertical;

            if (variableJoystick.Running == true && movements.x != 0 && movements.z != 0 && movements.z > 0)
            {
                if (OneTime)
                {
                    IsRunning = true;
                    OneTime = false;
                }
                transform.rotation = Quaternion.LookRotation(movements);
                transform.position = Vector3.MoveTowards(transform.position, PlayerController.position, speed * Time.deltaTime);
                Anim.SetBool("Run", true);
                Anim.SetBool("Idle", false);
            }
            else if ((movements.x == 0 && movements.z == 0) || movements.z < 0)
            {
                transform.LookAt(Goal);
                transform.position = Vector3.MoveTowards(transform.position, Goal.position, speed * Time.deltaTime);

                Anim.SetBool("Run", true);
                Anim.SetBool("Idle", false);
            }
        }
        else if(Dead)
        {
            Anim.SetBool("Idle", true);
            Anim.SetBool("Run", false);
        }

        if (Finished && AllowRun)
        {
            transform.LookAt(Goal);
            transform.position = Vector3.MoveTowards(transform.position, Goal.position, speed * Time.deltaTime);

            Anim.SetBool("Run", true);
            Anim.SetBool("Idle", false);
        }

        
    }
    void StartTaskOnClick()
    {
        scriptManager.Tutorial.SetActive(false);
        IsRunning = true;
        AllowRun = true;
        Starts.gameObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Helicopter")
        {
            Anim.SetBool("Run", false);
            Anim.SetBool("Idle", true);
            AllowRun = false;
            Status.text = "YOU WIN !";
            Status.gameObject.SetActive(true);
        }  
        if (other.gameObject.tag == "Goal")
        {
            cam.Goal = true;
            Finished = true;
            scriptManager.Next.gameObject.SetActive(true);
            scriptManager.Restart.gameObject.SetActive(true);
        }

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Border" && !Finished)
        {
            Status.text = "GAME OVER";
            Status.gameObject.SetActive(true);
            Dead = true;
            scriptManager.RestartAfterDeath.gameObject.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground" && IsRunning == true)
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Destroy(other.gameObject.gameObject, 2f);
        }
    }
    public void ResetPosition()
    {
        cam.Goal = false;
        Starts.gameObject.SetActive(true);
        rb.velocity = new Vector3(0, 0, 0);
        Finished = false;
        Dead = false;
        IsRunning = false;
        OneTime = true;
        AllowRun = false;
        gameObject.transform.position = PlayerOrigPos.position;
        Anim.SetBool("Run", false);
        Anim.SetBool("Idle", true);
        scriptManager.Tutorial.SetActive(true);
    }
}