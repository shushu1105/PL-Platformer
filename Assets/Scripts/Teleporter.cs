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

    public TeleporterNumber linkTeleporter;
    public TeleporterType type;

    GameObject[] allTeleporters;
    public Teleporter linkedTeleporter;

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
                    Debug.Log(linkTeleporter);
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

    }
}
