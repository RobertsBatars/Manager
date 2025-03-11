using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<TargetAnchor> targetAnchors;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < targetAnchors.Count; i++)
        {
            if (!targetAnchors[i].isCorrect)
            {
                return;
            }
        }
        GetComponent<SpriteRenderer>().color = Color.green;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
