using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SeasonChange : MonoBehaviour
{
    public Tilemap tilemap;
    public List<TileBase> spring;
    public List<TileBase> summer;
    public List<TileBase> autumn;
    public List<TileBase> winter;
    public List<Sprite> house;
    public List<Sprite> market;
    public List<Sprite> streetLight;
    public List<AnimatorController> treeRAnim;
    public List<AnimatorController> treeSAnim;
    public SpriteRenderer marketRenderer;
    public Transform houseParent;
    public Transform streetLightParent;
    public Transform treeRParent;
    public Transform treeSParent;
    public int season = 0;
    public float currentTime = 0f;
    public float changeTime = 5f;
    void Awake()
    {
        season = 0;
        foreach(Transform child in houseParent)
        {
            child.GetComponent<SpriteRenderer>().sprite = house[0];
        }
        foreach(Transform child in streetLightParent)
        {
            child.GetComponent<SpriteRenderer>().sprite = streetLight[0];
        }
        marketRenderer.sprite = market[0];
        foreach(Transform child in treeRParent)
        {
            child.GetComponent<Animator>().runtimeAnimatorController = treeRAnim[0];
        }
        foreach(Transform child in treeSParent)
        {
            child.GetComponent<Animator>().runtimeAnimatorController = treeSAnim[0];
            child.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= changeTime)
        {
            ChangeSeason();
            currentTime = 0f;
        }
    }
    public void ChangeSeason()
    {
        switch (season)
        {
            case 0:
                for (int i = 0; i < spring.Count; i++)
                    tilemap.SwapTile(spring[i], summer[i]);
                foreach (Transform child in houseParent)
                {
                    child.GetComponent<SpriteRenderer>().sprite = house[1];
                }
                foreach (Transform child in streetLightParent)
                {
                    child.GetComponent<SpriteRenderer>().sprite = streetLight[0];
                }
                marketRenderer.sprite = market[1];
                foreach (Transform child in treeRParent)
                {
                    child.GetComponent<Animator>().runtimeAnimatorController = treeRAnim[1];
                }
                foreach (Transform child in treeSParent)
                {
                    child.GetComponent<Animator>().runtimeAnimatorController = treeSAnim[1];
                }
                season++;
                break;
            case 1:
                for (int i = 0; i < summer.Count; i++)
                    tilemap.SwapTile(summer[i], autumn[i]);
                foreach (Transform child in houseParent)
                {
                    child.GetComponent<SpriteRenderer>().sprite = house[2];
                }
                foreach (Transform child in streetLightParent)
                {
                    child.GetComponent<SpriteRenderer>().sprite = streetLight[0];
                }
                marketRenderer.sprite = market[2];
                foreach (Transform child in treeRParent)
                {
                    child.GetComponent<Animator>().runtimeAnimatorController = treeRAnim[2];
                }
                foreach (Transform child in treeSParent)
                {
                    child.GetComponent<Animator>().runtimeAnimatorController = treeSAnim[2];
                }
                season++;
                break;
            case 2:
                for (int i = 0; i < autumn.Count; i++)
                    tilemap.SwapTile(autumn[i], winter[i]);
                foreach (Transform child in houseParent)
                {
                    child.GetComponent<SpriteRenderer>().sprite = house[3];
                }
                foreach (Transform child in streetLightParent)
                {
                    child.GetComponent<SpriteRenderer>().sprite = streetLight[1];
                }
                marketRenderer.sprite = market[3];
                foreach (Transform child in treeSParent)
                {
                    child.GetComponent<Animator>().runtimeAnimatorController = treeSAnim[3];
                    child.GetChild(0).gameObject.SetActive(true);
                }
                season++;
                break;
            case 3:
                for (int i = 0; i < winter.Count; i++)
                    tilemap.SwapTile(winter[i], spring[i]);
                foreach (Transform child in houseParent)
                {
                    child.GetComponent<SpriteRenderer>().sprite = house[0];
                }
                foreach (Transform child in streetLightParent)
                {
                    child.GetComponent<SpriteRenderer>().sprite = streetLight[0];
                }
                marketRenderer.sprite = market[0];
                foreach (Transform child in treeRParent)
                {
                    child.GetComponent<Animator>().runtimeAnimatorController = treeRAnim[0];
                }
                foreach (Transform child in treeSParent)
                {
                    child.GetComponent<Animator>().runtimeAnimatorController = treeSAnim[0];
                    child.GetChild(0).gameObject.SetActive(false);
                }
                season = 0;
                break;
        }
    }
}
