using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemies;

    [Space]
    [Header("Button")]
    public Button Next;
    public Button Restart;
    public Button RestartAfterDeath;

    // Start is called before the first frame update
    void Start()
    {
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
            Enemies.SetActive(true);
        }

    }

    void NextTaskOnClick()
    {
        Enemies.SetActive(false);
    }
    void RestartTaskOnClick()
    {
        Enemies.SetActive(false);
    }
    void RestartAfterDeathTaskOnClick()
    {
        Enemies.SetActive(false);
    }
}
