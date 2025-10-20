using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] int _Speed = 1;

    // Update is called once per frame
    void Update()
    {
        RotateObj();
    }
    private void RotateObj()
    {
        Quaternion quaternion = Quaternion.Euler(Vector3.forward * Time.deltaTime * _Speed); //어느방향으로 회전할지에 대한 정보를 명확히
        transform.rotation = transform.rotation * quaternion; //한후에 회전했기때문에 회전이 된다

        //transform.rotation = Quaternion.Euler(transform.rotation * Vector3.forward * Time.deltaTime * _Speed); //회전안함. 이유? .Euler값에 회전 값이 매우 작은 값으로 반환되기때문에 회전에 대한 정보가 매우 적은값이 반환됨
    }
}
