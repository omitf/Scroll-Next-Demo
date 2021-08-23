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
        //Debug.Log("Risk");
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = Scale.bounds.size.x / Scale.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            //Debug.Log("Risk2");
            Camera.main.orthographicSize = Scale.bounds.size.y / 2;
        }
        else
        {
            //Debug.Log("Risk3");
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = Scale.bounds.size.y / 2 * differenceInSize;
        }
    }

    void Update()
    {
        //float halfWidth = Mathf.Tan(0.5f * horizontalFoV * Mathf.Deg2Rad);

        //float halfHeight = halfWidth * Screen.height / Screen.width;

        //float verticalFoV = 2.0f * Mathf.Atan(halfHeight) * Mathf.Rad2Deg;

        //camera.fieldOfView = verticalFoV;

        if (target && !Goal)
         {
             transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(Distancex, Distancey, Distancez);
         }
        else if (target && Goal)
        {
            transform.position = Vector3.MoveTowards(transform.position, CamWinPos.position, speed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(Distancex, Distancey, Distancez);
        }
    }
    

}