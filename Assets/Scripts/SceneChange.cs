using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public SphereCollider triggerBox;
    public GameObject Door;
    public Vector3 initialPosition;
    public Vector3 moveTowardsPosition;
    public Vector3 moveLeftPosition;

    bool isOpen = false;
    bool hasMovedForward = false;

    void Start()
    {
        initialPosition = Door.transform.position;
        moveTowardsPosition = initialPosition + new Vector3(0f, 0f, 3f);
        moveLeftPosition = moveTowardsPosition + new Vector3(-3f, 0f, 0f);
    }

    void Update()
    {
        if (isOpen)
        {
            if (!hasMovedForward)
            {
                Door.transform.position = Vector3.Lerp(Door.transform.position, moveTowardsPosition, Time.deltaTime * 2);
                if (Vector3.Distance(Door.transform.position, moveTowardsPosition) < 0.1f)
                {
                    hasMovedForward = true;
                }
            }
            else
            {
                Door.transform.position = Vector3.Lerp(Door.transform.position, moveLeftPosition, Time.deltaTime * 2);
            }
        }
        else
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, initialPosition, Time.deltaTime * 2);
            hasMovedForward = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isOpen = !isOpen;
    }
}
