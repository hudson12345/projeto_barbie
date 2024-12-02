using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fala : MonoBehaviour
{
    public TextMeshProUGUI dialogo;
    public GameObject painel;
    private bool perto = false;
    private bool ativo = false;
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            perto = true;
            painel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            perto = false;
            painel.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        painel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
