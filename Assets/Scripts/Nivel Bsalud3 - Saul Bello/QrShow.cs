using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QrShow : MonoBehaviour
{
    float delta = 3f;
    float vIni, vFin,tIni;
    bool entrando,saliendo;
    Material m = null;



    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (entrando)
        {
            float val = Mathf.Lerp(vIni, vFin, (Time.time - tIni) / delta);
            m.SetFloat("_SliderTex", val);
            if (val>1)
            {
                entrando = false;
            }
        }
        if (saliendo)
        {
            float val = Mathf.Lerp(vIni, vFin, (Time.time - tIni) / delta);
            m.SetFloat("_SliderTex", val);
            if (val <= 0)
            {
                saliendo = false;
            }
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("TriggerCuadro"))
        {
            Debug.Log("ent");
            entrando=true;
            tIni = Time.time;
            vIni = 0;
            vFin = 1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("sal");
        if (other.gameObject.name.Equals("TriggerCuadro"))
        {
            saliendo = true;
            tIni = Time.time;
            vIni = 1;
            vFin = 0;
        }
    }
    
}
