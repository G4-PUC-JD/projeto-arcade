using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class InimigosIA : MonoBehaviour
{
    public float RaioVisao = 20;
    public float velocidadeGiro = 1f;
    public GameObject balaCanhao;
    public Transform[] pontosTiro;
    private float tempoSpawn = 0f;
    public float tempoSumir = 3f;
    Transform alvo;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Barco").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(alvo.position, transform.position);
        if (distancia <= RaioVisao)
        {
            agent.SetDestination(alvo.position);
            if (distancia <= agent.stoppingDistance)
            {
                OlharAlvo();
                foreach(Transform Pontos in pontosTiro)
                {
                Atirar(Pontos);
                }
            }
        }
    }
    void OlharAlvo ()
    {
        Vector3 direcao = (alvo.position - transform.position).normalized;
        Quaternion girarAlvo = Quaternion.LookRotation(new Vector3(direcao.x, 0, direcao.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, girarAlvo, Time.deltaTime * velocidadeGiro);
    }
    void Atirar(Transform Pontos)
    {
        tempoSpawn -= Time.deltaTime;
        if (tempoSpawn <= 0)
        {
          GameObject clone = Instantiate(balaCanhao, Pontos.position, Pontos.rotation);
          Destroy(clone,tempoSumir);
          tempoSpawn = 2.5f;
          }
    }
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RaioVisao);
    }
}
