using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Space]
    [Header("EnemyPacks")]
    public GameObject[] EnemyPacksList;

    [Space]
    [Header("Ground")]
    public GameObject CurrentGround;
    public GameObject GroundClone;

    [Space]
    [Header("Level Number")]
    public int LevelNB;

    [Space]
    [Header("Player")]
    public JoystickPlayerExample JoystickPlayerExample;

    int i = 0;

    void Start()
    {

        if (CurrentGround)
        {
            Destroy(CurrentGround);
        }

        CurrentGround = Instantiate(GroundClone, transform.position, GroundClone.transform.rotation);
        CurrentGround.SetActive(true);
    }
    void OnEnable()
    {
        if (CurrentGround)
        {
            Destroy(CurrentGround);
        }

        CurrentGround = Instantiate(GroundClone, transform.position, GroundClone.transform.rotation);
        CurrentGround.SetActive(true);
    }

    void Update()
    {
    }
    public void Delete()
    {
        if (CurrentGround)
        {
            Destroy(CurrentGround);
        }

        CurrentGround = Instantiate(GroundClone, transform.position, GroundClone.transform.rotation);
        CurrentGround.SetActive(false);

    }
    public void Restart()
    {
        if (CurrentGround)
        {
            Destroy(CurrentGround);
        }

        CurrentGround = Instantiate(GroundClone, transform.position, GroundClone.transform.rotation);
    }

}
