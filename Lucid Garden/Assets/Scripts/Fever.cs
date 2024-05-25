using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fever : MonoBehaviour
{
    public float feverTime = 5.0f;
    public int touchCount = 0;
    public bool isFever = false;
    public Image blockImage;
    public Button feverTree;
    public int dpPerTouch = 70;
    public Animator feverAnimator;
    private void Awake()
    {
        blockImage.gameObject.SetActive(false);
        gameObject.SetActive(false);
        feverTree.interactable = false;
        feverAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isFever)
        {
            feverTime -= Time.deltaTime;
            blockImage.gameObject.SetActive(true);
            feverTree.interactable = true;
            if (feverTime <= 0 || touchCount >= 30)
            {
                feverTree.interactable = false;
                isFever = false;
                feverTime = 5.0f;
                blockImage.gameObject.SetActive(false);
                gameObject.SetActive(false);
                GameManager.instance.statusManager.dreamPiece.AddDP(touchCount * dpPerTouch);
            }
        }
    }
    public void FeverStart()
    {
        isFever = true;
        touchCount = 0;
        gameObject.SetActive(true);
    }
    public void TouchCount()
    {
        touchCount++;
        feverAnimator.Play("Fever",-1,0f);
    }
}
