using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Sirenix.OdinInspector;

public class SeasonChange : MonoBehaviour
{
    public Tilemap tilemap;
    public List<GameObject> tilemaps;
    public List<TileBase> spring;
    public List<TileBase> summer;
    public List<TileBase> autumn;
    public List<TileBase> winter;
    public List<Sprite> house;
    public List<Sprite> market;
    public List<Sprite> streetLight;
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
            child.GetComponent<Animator>().SetInteger("Season", 0);
        }
        foreach(Transform child in treeSParent)
        {
            child.GetComponent<Animator>().SetInteger("Season", 0);
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
                tilemaps[0].SetActive(false);
                tilemaps[1].SetActive(true);
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
                    child.GetComponent<Animator>().SetInteger("Season", 1);
                }
                foreach (Transform child in treeSParent)
                {
                    child.GetComponent<Animator>().SetInteger("Season", 1);
                }
                season++;
                break;
            case 1:
                tilemaps[1].SetActive(false);
                tilemaps[2].SetActive(true);
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
                    child.GetComponent<Animator>().SetInteger("Season", 2);
                }
                foreach (Transform child in treeSParent)
                {
                    child.GetComponent<Animator>().SetInteger("Season", 2);
                }
                season++;
                break;
            case 2:
                tilemaps[2].SetActive(false);
                tilemaps[3].SetActive(true);
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
                    child.GetComponent<Animator>().SetInteger("Season", 3);
                    child.GetChild(0).gameObject.SetActive(true);
                }
                season++;
                break;
            case 3:
                tilemaps[3].SetActive(false);
                tilemaps[0].SetActive(true);
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
                    child.GetComponent<Animator>().SetInteger("Season", 0);
                }
                foreach (Transform child in treeSParent)
                {
                    child.GetComponent<Animator>().SetInteger("Season", 0);
                    child.GetChild(0).gameObject.SetActive(false);
                }
                season = 0;
                break;
        }
    }
    [Button]
    public void Change_Summer()
    {
        for (int i = 0; i < spring.Count; i++)
            tilemap.SwapTile(spring[i], summer[i]);
    }
    [Button]
    public void Change_Autumn()
    {
        for (int i = 0; i < summer.Count; i++)
            tilemap.SwapTile(spring[i], autumn[i]);
    }
    [Button]
    public void Change_Winter()
    {
        for (int i = 0; i < autumn.Count; i++)
            tilemap.SwapTile(spring[i], winter[i]);
    }
}
