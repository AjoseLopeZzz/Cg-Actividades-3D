using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DisparoRay : MonoBehaviour
{

    public Transform firePoint;
    public Transform casketPoint;
    public int damage = 25;

    public LineRenderer lineRenderer;

    private bool single = true;

    public GameObject shootFX, bloodFx;
    public GameObject casquillo;

    private float automatico;
    private float timeDisparo = 0.15f;

    // Start is called before the first frame update
    private void Start()
    {
        automatico = timeDisparo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Change"))
        {
            single = !single;
        }

        if (Input.GetButtonDown("Fire1") && !single)
        {
            StartCoroutine(Disparo());
        }

        if (Input.GetButtonDown("Fire1") && !single)
        {
            if (automatico <= 0)
            {
                StartCoroutine(Disparo());
                automatico = timeDisparo;

            }
        }

        automatico -= Time.deltaTime;
    }

    IEnumerator Disparo()
    {
        RaycastHit hit;
        bool hitInfo = Physics.Raycast(firePoint.position, firePoint.forward, out hit, 50f);

        if (hitInfo)
        {
            Enemigos enemigo = hit.transform.GetComponent<Enemigos>();

            if (enemigo != null)
            {
                Debug.Log("Enemigo impactado");
                enemigo.takeDamage(damage);
                Instantiate(bloodFx, hit.point, Quaternion.identity);
            }
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.forward * 20);
        }

        shootFX.SetActive(false);
        lineRenderer.enabled = true; 
        Instantiate(casquillo, casketPoint.position, casketPoint.rotation);

        yield return new WaitForSeconds(0.04f);

        shootFX.SetActive(false);
        LineRender.enabled = false;

    }
}
  

