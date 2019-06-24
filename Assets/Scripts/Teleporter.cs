using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public enum TeleporterNumber
    {
        zero,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine
    }

    public enum TeleporterType
    {
        inbound,
        outbound
    }

    public enum TeleporterExit
    {
        Null,
        Left,
        Right
    }
    public TeleporterNumber linkTeleporter;
    public TeleporterType type;
    public TeleporterExit exitFrom;
    public bool teleportPlayer;

    Vector3 teleportPos;

    GameObject[] allTeleporters;
    public Teleporter linkedTeleporter;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            teleportPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            teleportPlayer = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        allTeleporters = GameObject.FindGameObjectsWithTag("Teleporter");
        for (int i = 0; i < allTeleporters.Length; i++)
        {
            linkedTeleporter = allTeleporters[i].GetComponent<Teleporter>();
            if (linkedTeleporter.linkTeleporter == linkTeleporter)
            {
                if (linkedTeleporter.type != type)
                {
                    break;
                }
            }

            if (i == allTeleporters.Length - 1)
            {
                Debug.LogError("Teleporter Link not found:" + linkTeleporter);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && teleportPlayer)
        {
            teleportPos = linkedTeleporter.transform.position;
            if (exitFrom == TeleporterExit.Left)
            {
                teleportPos.x -= 1.28f;
            }
            else if (exitFrom == TeleporterExit.Right)
            {
                teleportPos.x += 1.28f;
            }
            teleportPos.z = -10.0f;
            GetComponent<PlaySFX>().playSFX = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = teleportPos;
        }
    }
}
