using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public Tilemap tilemap;
    float time;
    public TextMeshProUGUI timeText;

    void Start()
    {
        for (int i = 0; i < 98; i++)
        {
            GetComponent<ObjectPool>().GetAllColor();
        }

        List<Vector3Int> positions = new List<Vector3Int>();

        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                positions.Add(new Vector3Int(x, y, 0));
            }
        }

        for (int i = 0; i < positions.Count; i++)
        {
            int rand = Random.Range(i, positions.Count);
            (positions[i], positions[rand]) = (positions[rand], positions[i]);
        }

        
        for (int i = 0; i < 98; i++)
        {
            GetComponent<ObjectPool>().pool[i].transform.position = positions[i]; 
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F2");

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Input.mousePosition;
            Debug.Log(pos);
        }
    }
}
