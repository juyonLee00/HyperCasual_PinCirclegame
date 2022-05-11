using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject square;
    [SerializeField]
    private float moveTime = 0.2f;

    public void SetInPinStuckToTarget()
    {
      StopCoroutine("MoveTo");

      square.SetActive(true);
    }

    public void MoveOnStep(float moveDistance)
    {
      StartCoroutine("MoveTo", moveDistance);
    }

    private IEnumerator MoveTo(float moveDistance)
    {
      Vector3 start = transform.position;
      Vector3 end = transform.position + Vector3.up * moveDistance;

      float current = 0;
      float percent = 0;

      while (percent < 1)
      {
        current += Time.deltaTime;
        percent = current / moveTime;

        transform.position = Vector3.Lerp(start, end, percent);

        yield return null;
      }
    }
}
