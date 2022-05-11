using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Commons")]
    [SerializeField]
    private StageController stageController;
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

    [Header("Throwable Pin")]
    [SerializeField]
    private float bottomAngle = 270;
    private List<Pin> throwablePins; //던져야 할 핀 오브젝트 리스트


    public void Setup()
    {
      throwablePins = new List<Pin>();
    }


    private void Update(){
      if(Input.GetMouseButtonDown(0) && throwablePins.Count > 0)
      {
        SetInPinStuckToTarget(throwablePins[0].transform, bottomAngle);
        throwablePins.RemoveAt(0);

        for (int i = 0; i < throwablePins.Count; ++i)
        {
          throwablePins[i].MoveOneStep(stageController.TPinDistance); 
        }
      }
    }

    public void SpawnThrowablePin(Vector3 position)
    {
      GameObject clone = Instantiate(pinPrefab, position, Quaternion.identity);

      Pin pin = clone.GetComponent<Pin>();

      throwablePins.Add(pin);
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

      pin.SetParent(targetTransform);

      pin.GetComponent<Pin>().SetInPinStuckToTarget();
    }
}
