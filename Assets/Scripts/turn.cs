using UnityEngine;

public class turn : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float xrot = 0f;
    public float sensitivity = 100f;
    public Transform body;

    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xrot -= y;
        xrot = Mathf.Clamp(xrot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrot, 0f, 0f);
        body.Rotate(Vector3.up * x);
    }
}
  