using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyroscope_managing : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion m_rota; // Quaternion pour la rotation

    private bool gyroEnabled; // Boolean pour vérifier si le gyroscope est activé
    private Gyroscope m_gyro; // Le gyroscope

    public bool m_start_moving; // bool pour le déplacement 

    void Start()
    {
        gyroEnabled =  EnableGyro(); // Vérifie si le gyroscope peut être utilisé
        m_start_moving = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled && m_start_moving) // Si actif
        {
            // Debug.Log("RENTRE DONC PAS OUF");
            transform.localRotation = GyroToUnity(m_gyro.attitude) * m_rota; // Rotation de la lance en fonction du gyro
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            m_gyro = Input.gyro; // Le gyroscope
            m_gyro.enabled = true; // Active le gyro

            //Lance.transform.rotation = Quaternion.Euler(90f, 90f, 0f); // Rotation au début pour mettre la lance dans le sens de visée
            m_rota = new Quaternion(0, 0, 1, 0); // 1 sur axe Y

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
