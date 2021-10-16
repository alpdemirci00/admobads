using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameradonuss : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    public DynamicJoystick DY;
    public float sensivity;
    public GameObject Player;

    private Vector3 previousPosition;

    private void Update()
    {
        if (Player == null)
            Player = GameObject.FindWithTag("Player");
        previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = DY.Horizontal * sensivity; // camera moves horizontally
            float rotationAroundXAxis = DY.Vertical *sensivity;  //camera moves vertically

            cam.transform.position = Player.transform.position;

            //cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), -rotationAroundYAxis, Space.World);
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
            previousPosition = newPosition;
        
        
    }
}
