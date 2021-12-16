using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class SpearsMove : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] [Tooltip("The delay during which the player cannot do an action after doing one (unit : seconds)")] private float m_delayBetweenActions = 0.2f;
    [SerializeField] [Tooltip("The duration of a player movement (unit : seconds")] private float m_movementDuration = 0.2f;
    [SerializeField] [Tooltip("The distance covered by one movement (unit : Unity meters")] private float m_movementDistance = 5f;
    [SerializeField] [Tooltip("The strength of the gyroscope movement that is needed to be detected (unit : arbitrary")] private float m_sensibilityGyro = 50.0f;
    [SerializeField] [Tooltip("!UNSTABLE YET! If you wanna include a multiplier to the movement distance of a specific direction \r\n First index is up and goes clockwise.")] private float[] m_multipliersByDirection = new float[4];
    [Header("Debug")]
    //[SerializeField] [Tooltip("The text in the canvas in which you want to display gyro info. NOT COMPULSORY, FOR DEBUG ONLY")] private TextMeshProUGUI m_text = null;
    private Vector3 m_deltaGyro = Vector3.zero;
    [SerializeField] private Quaternion m_coeff = new Quaternion(1,1,1,1);
    private float m_counterAction = 0.0f;
    private float m_counterMovement = 0.0f;
    private Vector3 m_movementDirection = Vector3.zero;
    private Rigidbody m_rb;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_counterAction = m_delayBetweenActions;
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion gyroQ = GyroToUnity(Input.gyro.attitude) * m_coeff;
        Vector3 gyro = gyroQ.eulerAngles;

        //if (m_text != null) {
        //    m_text.text = ($"X : {gyro.x}\nY : {gyro.y}\nZ : {gyro.z}");
        //}

        //Math.Abs --> absolute

        // Permet de savoir la direction du mouvement
        if ((Mathf.Abs(gyro.y - m_deltaGyro.y)/Time.deltaTime >= m_sensibilityGyro || Mathf.Abs(gyro.z - m_deltaGyro.z)/Time.deltaTime >= m_sensibilityGyro) && m_counterAction >= m_delayBetweenActions)
        {
            if (Mathf.Abs(gyro.y - m_deltaGyro.y) / Time.deltaTime >=
                Mathf.Abs(gyro.z - m_deltaGyro.z) / Time.deltaTime)
            {
                if (gyro.y > m_deltaGyro.y)
                {
                    m_movementDirection = Vector3.left;
                    Debug.Log("Left");
                }
                else
                {
                    m_movementDirection = Vector3.right;
                    Debug.Log("Right");
                }
            }
            else {
                if (gyro.z > m_deltaGyro.z)
                {
                    m_movementDirection = Vector3.up;
                    Debug.Log("Up");
                }
                else
                {
                    m_movementDirection = Vector3.down;
                    Debug.Log("Down");
                }
            }
            
            m_counterAction = 0.0f;
        }

        if (m_movementDirection != Vector3.zero && m_counterMovement <= m_movementDuration)
        {
            m_rb.velocity = Vector3.zero;
            transform.Translate(m_movementDirection * Time.deltaTime * m_movementDistance / m_movementDuration);
            m_counterMovement += Time.deltaTime;
        }
        else if (m_counterMovement > m_movementDuration)
        {
            m_counterMovement = 0.0f;
            m_movementDirection = Vector3.zero;
            m_counterAction = 0.0f;
        }
        else if(m_counterAction<= m_delayBetweenActions){
            m_counterAction += Time.deltaTime;
        }

        m_deltaGyro = gyro; // delta = gyro --> permet de vérifier la différence avec la futur position du gyro
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}