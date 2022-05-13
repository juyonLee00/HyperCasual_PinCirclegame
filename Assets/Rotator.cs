using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float rotateSpeed = 50; //회전 속도 설정
    [SerializeField]
    private Vector3 rotateAngle = Vector3.forward; //회전 방향 설정


    // Update is called once per frame
    private void Update()
    {
      //오브젝트 회전식
    transform.Rotate(rotateAngle * rotateSpeed * Time.deltaTime);
    }

    public void Stop()
    {
      rotateSpeed = 0;
    }
}
