using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [Space]
    [Header("SpinningTrap")]
    public bool SpinningTrap;
    public Transform RotateArroundTrap;
    public Transform RotatorTrap;
    public float SpinningTrapSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpinningTrap)
        {
            RotatorTrap.transform.RotateAround(RotateArroundTrap.position, Vector3.down, SpinningTrapSpeed * Time.deltaTime);
        }
        
    }
}
