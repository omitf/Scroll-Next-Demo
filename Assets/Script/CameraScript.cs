using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera camera;
    public float horizontalFoV = 90.0f;
    public Transform target;
    public Transform CamWinPos;
    public float Distancex;
    public float Distancey;
    public float Distancez;
    public bool Goal;
    public float speed;

    public SpriteRenderer Scale;

    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = Scale.bounds.size.x / Scale.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = Scale.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = Scale.bounds.size.y / 2 * differenceInSize;
        }
    }

    void Update()
    {

        if (target && !Goal)
         {
             transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(Distancex, Distancey, Distancez);
         }
        else if (target && Goal)
        {
            transform.position = Vector3.MoveTowards(transform.position, CamWinPos.position, speed * Time.deltaTime);
        }
    }
    

}