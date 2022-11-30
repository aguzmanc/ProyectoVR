using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MjolnirActions : MonoBehaviour
{
    [SerializeField]
    bool agarrado;
    [SerializeField]
    float velocidad = 50;
    [SerializeField]
    Rigidbody rigidbody;
    [SerializeField]
    bool vuelo, simulacionAgarrado, habilitado, llamado, couroutineStarted, regreso;
    [SerializeField]
    Quaternion rot;
    [SerializeField]
    private Transform _mano, _camara;
    [SerializeField]
    float distancia = 1f;
    Vector3 direccion;
    Vector3 neutro = new Vector3(0,0,0);
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        vuelo = false;
        habilitado = true;
        simulacionAgarrado = false;
        llamado = false;
        couroutineStarted = false;
        regreso = false;
        direccion = neutro;
    }
    
    void Update()
    {
        Debug.DrawLine(_camara.position, _camara.forward * 50, Color.blue);
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0) simulacionAgarrado = true;
        else simulacionAgarrado = false;
        agarrado = (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0);
        if(agarrado) habilitado = true;
        if(habilitado) rigidbody.isKinematic = true;
        else rigidbody.isKinematic = false;
        if(!llamado && !agarrado && transform.position.y <= 0.6f) CancelarVuelo();
        if(!llamado && (transform.position.x >= 200 || transform.position.x <= -200 || transform.position.z >= 200 || transform.position.z <= -200))
            vuelo = false;
        else if(!agarrado && transform.position.y >= 1.4f) vuelo = true;
        if(vuelo && !llamado) VueloMartillo();
        if(simulacionAgarrado)
        {
            if(VerificadoRegreso())
            {
                llamado = true;
                habilitado = true;
                Vector3 piso = _mano.position - transform.position;
                Debug.DrawRay(transform.position, piso, Color.green);
                rot = Quaternion.LookRotation(piso);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
                if(!couroutineStarted)
                    StartCoroutine(EsperaSegundos(3));
                if(regreso)VueloRegresoMartillo();
            }
            else 
            {
                transform.position = _mano.transform.position;
                vuelo = false;
                habilitado = false;
            }
        }
        else CancelarRegreso();
    }

    private void VueloMartillo(){
        if(direccion == neutro){
            direccion = _camara.forward;
            transform.forward = direccion;
            transform.Rotate(90 , 0 , 0);
        }
        transform.Translate(new Vector3(0f,velocidad * Time.deltaTime,0f),Space.Self);
    }
    private void VueloRegresoMartillo(){
        direccion = neutro;
        transform.Translate(new Vector3(0f, 0,(velocidad * 2) * Time.deltaTime),Space.Self);
    }
    private void CancelarVuelo(){
        direccion = neutro;
        habilitado = false;
        vuelo = false;
    }
    private void CancelarRegreso()
    {
        llamado = false;
        regreso = false;
        couroutineStarted = false;
    }
    private bool VerificadoRegreso()
    {
        if((transform.position.x <= _mano.transform.position.x + distancia && transform.position.x >= _mano.transform.position.x - distancia) && (transform.position.z <= _mano.transform.position.z + distancia && transform.position.z >= _mano.transform.position.z - distancia))
            return false;
        return true;
    }
    private void LlamadoDeMartilloComponentesCalculoRotacion()
    {
        habilitado = false;
        vuelo = false;
    }
    IEnumerator EsperaSegundos(int seconds)
    {
      couroutineStarted = true;
      LlamadoDeMartilloComponentesCalculoRotacion();
      yield return new WaitForSeconds(seconds);
      regreso = true;
    } 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Terreno")
        CancelarVuelo();
    }
}
