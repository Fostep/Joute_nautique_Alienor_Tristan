using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    [SerializeField] float m_intervalGeneration;
    [SerializeField] GameObject[] m_nodesPrefabs;
    private GameObject m_parentL;
    private GameObject m_parentR;


    // Start is called before the first frame update
    void Start()
    {
        m_parentL = GameObject.Find("PartitionLeft");
        m_parentR = GameObject.Find("PartitionRight");

        InvokeRepeating("LaunchSpawn", 0f, 0.5f);
    }

    void LaunchSpawn()
    {
        StartCoroutine(NodeSpawn());
    }

    IEnumerator NodeSpawn()
    {
        yield return new WaitForSeconds(m_intervalGeneration);

        //Tire au sort
        GameObject nodePrefab = m_nodesPrefabs[Random.Range(0, m_nodesPrefabs.Length)];

        //Choix du parent
        IconMove node = nodePrefab.GetComponent<IconMove>();
        GameObject parent;
        if (node.m_iconType) {parent = m_parentL;}
        else {parent = m_parentR;}

        //Instanciation
        GameObject nodeInstance;
        nodeInstance  = Instantiate(nodePrefab, new Vector3(0f, 0f, 0f), transform.rotation);
        nodeInstance.transform.SetParent(parent.transform, false);
    }

}
