using UnityEngine;

public class EggController : MonoBehaviour
{
    [SerializeField] GameObject _full;
    [SerializeField] GameObject _damaged;
    [SerializeField] private ParticleSystem _particleSystem;

    public GameObject[] aranas;

    private void Start()
    {
        if (transform.tag=="HuevoMarron")
        {
            Destroy();
            GameObject enemigo =
            (GameObject)Instantiate(aranas[0], new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
        }
        else if(transform.tag == "HuevoVerde")
        {
            Destroy();
            GameObject enemigo =
            (GameObject)Instantiate(aranas[1], new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
        }
        else if (transform.tag == "HuevoRojo")
        {
            Destroy();
            GameObject enemigo =
            (GameObject)Instantiate(aranas[2], new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
        }
        
    }
    void OnMouseOver()
    {
        Destroy();
    }

    public void Clear()
    {
        _full.gameObject.SetActive(true);
        _damaged.gameObject.SetActive(false); 
    }
    public void Destroy()
    {
        _full.gameObject.SetActive(false);
        _damaged.gameObject.SetActive(true);
        _particleSystem.Play();
    }

}