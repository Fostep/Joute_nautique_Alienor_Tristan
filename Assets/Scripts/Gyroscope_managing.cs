using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyroscope_managing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Lance; // Objet lance
    private Quaternion rota; // Quaternion pour la rotation

    private bool gyroEnabled;
    private Gyroscope gyro;

    public bool m_start_moving;

    void Start()
    {
        gyroEnabled = true;//EnableGyro(); // V�rifie si le gyroscope peut �tre utilis�
        m_start_moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled && m_start_moving) // Si actif
        {
            Debug.Log("RENTRE DONC PAS OUF");
            Lance.transform.localRotation = GyroToUnity(gyro.attitude) * rota; // Rotation de la lance en fonction du gyro
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro; // Le gyroscope
            gyro.enabled = true; // Active le gyro

            //Lance.transform.rotation = Quaternion.Euler(90f, 90f, 0f); // Rotation au d�but pour mettre la lance dans le sens de vis�e
            //rota = new Quaternion(0, 0, 1, 0); // 1 sur axe Y

            return true;
        }
        return false;
    }

    // Change les valeurs du quaternion gyro � celui de Unity
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
