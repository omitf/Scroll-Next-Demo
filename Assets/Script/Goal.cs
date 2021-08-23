using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ParticleSystem Firework1;
    public ParticleSystem Firework2;
    public ParticleSystem Firework3;

    private Animator Anim;

    [Space]
    [Header("Button")]
    public Button Next;
    public Button Restart;
    public Button RestartAfterDeath;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

        Button btnNext = Next.GetComponent<Button>();
        btnNext.onClick.AddListener(NextTaskOnClick);

        Button btnRestart = Restart.GetComponent<Button>();
        btnRestart.onClick.AddListener(RestartTaskOnClick);

        Button btnRestartAfterDeath = RestartAfterDeath.GetComponent<Button>();
        btnRestartAfterDeath.onClick.AddListener(RestartAfterDeathTaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Firework1.Play();
            Firework2.Play();
            Firework3.Play();
            Anim.SetBool("Go", true);
        }

    }

    void NextTaskOnClick()
    {
        Firework1.Stop();
        Firework2.Stop();
        Firework3.Stop();
        Anim.SetBool("Go", false);
    }
    void RestartTaskOnClick()
    {
        Firework1.Stop();
        Firework2.Stop();
        Firework3.Stop();
        Anim.SetBool("Go", false);
    }
    void RestartAfterDeathTaskOnClick()
    {
        Firework1.Stop();
        Firework2.Stop();
        Firework3.Stop();
        Anim.SetBool("Go", false);
    }
}
