using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Commons")]
    [SerializeField]
    private GameObject pinPrefab;

    [Header("Stuck Pin")]
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private Vector3 targetPosition = Vector3.up * 2;
    [SerializeField]
    private float targetRadius = 0.8f;
    [SerializeField]
    private float pinLength = 1.5f;

    public void SpawnThrowablePin(Vector3 position)
    {
      Instantiate(pinPrefab, position, Quaternion.identity);
    }

    public void SpawnStuckPin(float angle)
    {
      GameObject clone = Instantiate(pinPrefab);

      SetInPinStuckToTarget(clone.transform, angle);
    }


    private void SetInPinStuckToTarget(Transform pin, float angle)
    {
      pin.position = Utils.GetPositionFromAngle(targetRadius+pinLength, angle) + targetPosition;

      pin.rotation = Quaternion.Euler(0, 0, angle);

      pin.setParent(targetTransform);

      pin.GetComponent<Pin>().SetInPinStuckToTarget();
    }
}
