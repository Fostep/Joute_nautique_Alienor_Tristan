using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyroscope_managing : MonoBehaviour
{
    [Header("Quaternion giro")]
    [SerializeField] [Tooltip("exemple")] float x;
    [SerializeField] float y;
    [SerializeField] float z;
    [SerializeField] float w;
    [SerializeField] float m_speed;

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
            Quaternion gyroQ = GyroToUnity(Input.gyro.attitude);
            //Vector3 gyro = gyroQ.eulerAngles;
            Quaternion quat = new Quaternion(x, y, z, w);
            //transform.localRotation = quat * (m_gyro.attitude * m_rota); // Rotation de la lance en fonction du gyro
            transform.rotation = Quaternion.Lerp(transform.rotation * quat, gyroQ * quat, Time.time * m_speed); // Rotation de la lance en fonction du gyro
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            m_gyro = Input.gyro; // Le gyroscope
            m_gyro.enabled = true; // Active le gyro

            transform.rotation = Quaternion.Euler(90f, 90f, 0f); // Rotation au début pour mettre la lance dans le sens de visée
            m_rota = new Quaternion(0, 0, 1, 0); // 1 sur axe Y

            return true;
        }
        return false;
    }


    // Change les valeurs du quaternion gyro à celui de Unity
    private static Quaternion GyroToUnity(Quaternion q)
    {
        //return new Quaternion(q.x, q.y, -q.z, -q.w);
        return new Quaternion(q.x, q.y, 0, -q.w);
    }

}
