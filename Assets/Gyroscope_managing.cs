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

    void Start()
    {
        gyroEnabled = EnableGyro(); // Vérifie si le gyroscope peut être utilisé
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled) // Si actif
        {
            Lance.transform.localRotation = GyroToUnity(gyro.attitude) * rota; // Rotation de la lance en fonction du gyro
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro; // Le gyroscope
            gyro.enabled = true; // Active le gyro

            Lance.transform.rotation = Quaternion.Euler(90f, 90f, 0f); // Rotation au début pour mettre la lance dans le sens de visée
            rota = new Quaternion(0, 0, 1, 0); // 1 sur axe Y

            return true;
        }
        return false;
    }

    // Change les valeurs du quaternion gyro à celui de Unity
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
