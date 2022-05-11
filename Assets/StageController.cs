using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner;
    [SerializeField]
    private int throwablePinCount;
    [SerializeField]
    private int stuckPinCount;

    private Vector3 firstTPinPosition = Vector3.down * 2;

    public float TPinDistance {private set; get;} = 1;

    private void Awake()
    {
      pinSpawner.Setup();
      for(int i = 0; i < throwablePinCount; ++i)
      {
        pinSpawner.SpawnThrowablePin(firstTPinPosition + Vector3.down * TPinDistance * i);
      }
      for(int i = 0; i < stuckPinCount; ++i)
      {
        float angle = (360 / stuckPinCount) * i;

        pinSpawner.SpawnStuckPin(angle);
      }
    }
    // Start is called before the first frame update

}
