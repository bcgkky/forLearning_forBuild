using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onizleme : MonoBehaviour
{
    public GameObject hasObjem;
    RaycastHit hit;
    public Material material;
    public Material materialOlumsuz;
    bool olusurmu;

    void Start()
    {
        olusurmu = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,500, 1<<8))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y + .5f , hit.point.z);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("zemin"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialOlumsuz;
            olusurmu = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("zemin"))
        {
            gameObject.GetComponent<MeshRenderer>().material = material;
            olusurmu = true;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 500, 1<<8))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y + .5f, hit.point.z);
        }

        if (Input.GetMouseButton(0))
        {
            if (olusurmu)
            {
                Instantiate(hasObjem, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
