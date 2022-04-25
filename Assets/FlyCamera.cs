using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour
{

    public Camera cam; // камера
    public float cam_sens_rotate; // скорость поворота
    public float cam_sens_move; // скорость движения
    public float cam_wheel;

    private float camX;
    private float camY;
    private float camZ;
    private Transform camTr;
    private bool Fire1Press;



    // Use this for initialization
    void Start()
    {
        camX = cam.transform.eulerAngles.x;
        camY = cam.transform.eulerAngles.y;
        camTr = cam.transform;
        camZ = Vector3.Distance(Vector3.zero, camTr.position);
    }

    // Update is called once per frame
    void Update()
    {
        camX = 0f;
        camY = 0f;
        camZ = 0f;
        // берем состояние мыши
        // а конкретно - именованных осей
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");
        // и колесо мышки
        float mW = Input.GetAxis("Mouse Wheel");

        if (Input.GetKey("escape"))  // если нажата клавиша Esc (Escape)
        {
            Application.Quit();    // закрыть приложение
        }

        // если нажата правая мышка
        if (Input.GetAxis("Fire2") > 0)
        {
            if (mX != 0)
            {
                camX += mX * cam_sens_rotate;
                camTr.transform.rotation = Quaternion.AngleAxis(-mX*2, Vector3.up) * transform.rotation; // крутим оси "вверх"
            }
        }
        // если крутили крутили колесо мыши
        if (mW != 0)
        {
            camZ = mW * cam_wheel;
            camTr.transform.position += (camZ > 0 ? Vector3.down * 3 : Vector3.up * 3);
        }

        // если нажата средняя мышка
        if (Input.GetAxis("Fire3") > 0)
        {
            if (mY != 0)
            {
                camY += mY * cam_sens_rotate;
                camTr.transform.Rotate(Vector3.left, (int)camY); // крутим оси "вверх"
            }
        }
        if (camTr.transform.eulerAngles.x <= 30)
        {
            transform.rotation =
Quaternion.Euler(30, 0, 0);
        }
        if (camTr.transform.eulerAngles.x >= 80)
        {
            transform.rotation =
Quaternion.Euler(80, 0, 0);
        }

        if (Input.GetAxis("Fire1") > 0)
        {
            mX = -mX * cam_sens_move * (camTr.position.y / 70);
            mY = -mY * cam_sens_move *(camTr.transform.eulerAngles.x / 30) * (camTr.position.y/70);
            camTr.position += 
                (mX > 0 ? Vector3.ProjectOnPlane(transform.right, Vector3.up) * mX : Vector3.ProjectOnPlane(-transform.right, Vector3.up) * (-mX)) +          
                (mY > 0 ? Vector3.ProjectOnPlane(transform.forward, Vector3.up) *mY : Vector3.ProjectOnPlane(-transform.forward, Vector3.up) * (-mY));
        }
        if (camTr.position.x <= 0) camTr.position = new Vector3(0, camTr.position.y, camTr.position.z);
        if (camTr.position.y <= 10) camTr.position = new Vector3(camTr.position.x, 10, camTr.position.z);
        if (camTr.position.z <= 0) camTr.position = new Vector3(camTr.position.x, camTr.position.y, 0);
        if (camTr.position.x >= 1000) camTr.position = new Vector3(1000, camTr.position.y, camTr.position.z);
        if (camTr.position.y >= 200) camTr.position = new Vector3(camTr.position.x, 200, camTr.position.z);
        if (camTr.position.z >= 1000) camTr.position = new Vector3(camTr.position.x, camTr.position.y, 1000);
    }
}
