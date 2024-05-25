using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private const float directionForceReduceRate = 0.99f;
    private const float directionForceMin = 0.001f;

    private bool isMoving;
    private bool isZooming;
    private Vector3 startPosition;
    private Vector3 directionForce;

    private Camera mainCamera;
    private float height;
    private float width;

    public int testLevel = 0;
    public List<Tilemap> blocks = new List<Tilemap>();

    public GameObject UI;


    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        height = mainCamera.orthographicSize;
        width = height * mainCamera.aspect;
        isMoving = false;
        isZooming = false;
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.timeManager.fever.isFever)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -10f), 0.2f);
            return;
        }
        if (isZooming) return;
        if (DragSlot.instance.isDragging) return;
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
        transform.position = Vector3.Lerp(currentPosition, targetPosition, 0.2f);
        float x = GameManager.instance.boundPerLevel[GameManager.instance.currentLevel].x - width;
        float y = GameManager.instance.boundPerLevel[GameManager.instance.currentLevel].y - height;
        float clampX = Mathf.Clamp(transform.position.x, -x, x);
        float clampY = Mathf.Clamp(transform.position.y, -y, y);
        transform.position = new Vector3(clampX, clampY, -10f);
    }
    public void LevelUp(int level)
    {
        StartCoroutine(ZoomIn(level));
    }
    IEnumerator ZoomIn(int level)
    {
        UI.SetActive(false);
        isZooming = true;
        float resizedWidth = width;
        while(resizedWidth < GameManager.instance.boundPerLevel[level].x)
        {
            mainCamera.orthographicSize += 0.1f;
            resizedWidth = mainCamera.orthographicSize * mainCamera.aspect;
            var offset = (new Vector3(0,0,-10f) - transform.position) * (mainCamera.orthographicSize / (GameManager.instance.boundPerLevel[level].x / mainCamera.aspect));
            var currentPos = transform.position;
            currentPos += offset;
            transform.position = currentPos;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(RemoveBlock(level));
    }
    IEnumerator RemoveBlock(int level)
    {
        while (blocks[level-1].color.a > 0)
        {
            blocks[level-1].color = new Color(1, 1, 1, blocks[level - 1].color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        blocks[level - 1].gameObject.SetActive(false);
        StartCoroutine(ZoomOut());
    }
    IEnumerator ZoomOut()
    {
        while(mainCamera.orthographicSize > 5)
        { 
            mainCamera.orthographicSize -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        mainCamera.orthographicSize = 5;
        isZooming = false;
        UI.SetActive(true);
    }
    public void RemoveBlocks()
    {
        for(int i = 0; i < GameManager.instance.currentLevel; i++)
        {
            blocks[i].gameObject.SetActive(false);
        }
    }
}
