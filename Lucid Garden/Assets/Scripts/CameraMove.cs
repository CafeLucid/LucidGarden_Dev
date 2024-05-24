using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class CameraMove : MonoBehaviour
{
    private const float directionForceReduceRate = 0.99f;
    private const float directionForceMin = 0.001f;

    private bool isMoving;
    private Vector3 startPosition;
    private Vector3 directionForce;

    private Camera mainCamera;
    private float height;
    private float width;

    public int testLevel = 0;


    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        height = mainCamera.orthographicSize;
        width = height * mainCamera.aspect;
    }
    private void Update()
    {
        ControlCameraPosition();
        ReduceDirectionForce();
        UpdateCameraPosition();
    }
    private void ControlCameraPosition()
    {
        var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            CameraMoveStart(mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            CameraMoving(mousePosition);
        }
        else
        {
            CameraMoveEnd();
        }
    }
    private void CameraMoveStart(Vector3 mousePosition)
    {
        isMoving = true;
        startPosition = mousePosition;
        directionForce = Vector3.zero;
    }
    private void CameraMoving(Vector3 mousePosition)
    {
        if(!isMoving)
        {
            CameraMoveStart(mousePosition);
            return;
        }
        directionForce = startPosition - mousePosition;
    }
    private void CameraMoveEnd()
    {
        isMoving = false;
    }
    private void ReduceDirectionForce()
    {
        if (isMoving) return;
        directionForce *= directionForceReduceRate;
        if (directionForce.magnitude < directionForceMin)
        {
            directionForce = Vector3.zero;
        }
    }
    private void UpdateCameraPosition()
    {
        if(directionForce == Vector3.zero)
        {
            return;
        }
        var currentPosition = transform.position;
        var targetPosition = currentPosition + directionForce;
        transform.position = Vector3.Lerp(currentPosition, targetPosition, 0.01f);
        float x = GameManager.instance.boundPerLevel[(int)GameManager.instance.currentLevel/2].x - width;
        float y = GameManager.instance.boundPerLevel[(int)GameManager.instance.currentLevel/2].y - height;
        float clampX = Mathf.Clamp(transform.position.x, -x, x);
        float clampY = Mathf.Clamp(transform.position.y, -y, y);
        transform.position = new Vector3(clampX, clampY, -10f);
    }
}
