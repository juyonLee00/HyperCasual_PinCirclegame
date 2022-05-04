using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject square;

    public void SetInPinStuckToTarget()
    {
      square.SetActive(true);
    }
}
