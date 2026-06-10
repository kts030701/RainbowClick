using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    int maxPerColor = 14;

    public GameObject red;
    public GameObject orange;
    public GameObject yellow;
    public GameObject green;
    public GameObject blue;
    public GameObject navy;
    public GameObject purple;

    public List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        CreateColor(red);
        CreateColor(orange);
        CreateColor(yellow);
        CreateColor(green);
        CreateColor(blue);
        CreateColor(navy);
        CreateColor(purple);
    }

    void CreateColor(GameObject color)
    {
        for (int i = 0; i < maxPerColor; i++)
        {
            GameObject obj = Instantiate(color);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetAllColor()
    {
        foreach (GameObject color in pool)
        {
            if (!color.activeSelf)
            {
                color.SetActive(true);
                return color;
            }
        }

        return null;
        
    }

void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null)
            {
                hit.gameObject.SetActive(false);
            }
        }
    }
}
