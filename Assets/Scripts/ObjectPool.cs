using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    int maxPerColor = 14;

    public static GameObject red;
    public static GameObject orange;
    public static GameObject yellow;
    public static GameObject green;
    public static GameObject blue;
    public static GameObject navy;
    public static GameObject purple;

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
        
    }
}
