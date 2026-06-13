using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public Tilemap tilemap;
    public static float time;
    public static float bestTime;
    public TextMeshProUGUI timeText;
    GameObject[] colors;
    GameObject shouldColor;
    int shouldColorNumber;
    public int colorNumber = 98;
    
    public AudioSource audioSource;
    public AudioClip correct1;
    public AudioClip correct2;
    public AudioClip wrong;

    void Start()
    {
        time = 0;

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

        ObjectPool pool = GetComponent<ObjectPool>();

        colors = new GameObject[]
        {
        pool.red,
        pool.orange,
        pool.yellow,
        pool.green,
        pool.blue,
        pool.navy,
        pool.purple
        };

        shouldColor = colors[0];
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F2");

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D colorHit = Physics2D.OverlapPoint(worldPos, LayerMask.GetMask("RainbowTile"));
            Collider2D tileHit = Physics2D.OverlapPoint(worldPos, LayerMask.GetMask("BG"));

            if (colorHit != null)
            {
                if (colorHit.gameObject.name.Replace("(Clone)", "") == shouldColor.name)
                {
                    audioSource.PlayOneShot(correct1);

                    colorHit.gameObject.SetActive(false);
                    colorNumber -= 1;

                    if (colorNumber == 0)
                    {
                        if (bestTime == 0)
                        {
                            bestTime = time;
                        }
                        if (time < bestTime)
                        {
                            bestTime = time;
                        }

                        SceneManager.LoadScene("GameOverScene");
                    }

                    if (shouldColorNumber < 6)
                    {
                        shouldColorNumber += 1;
                    }
                    else
                    {
                        shouldColorNumber = 0;
                    }

                    shouldColor = colors[shouldColorNumber];
                }
                else
                {
                    audioSource.PlayOneShot(wrong);
                    time += 1;
                }
            }
            else if (tileHit != null)
            {
                audioSource.PlayOneShot(wrong);
                time += 1;
            }
        }
    }
}
