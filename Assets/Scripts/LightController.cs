using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour
{

    private bool isFlickering;
    private float timeDelay; //delay between flickers

    private Material lightBulbMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFlickering = false;
        lightBulbMaterial = this.transform.parent.gameObject.GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine("FlickeringLight");
            //flicker lights when not flickering
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false; //turns off light
        lightBulbMaterial.SetColor("_EmissionColor", Color.black);
        timeDelay = Random.Range(0.01f, 1f);//random time delay
        yield return new WaitForSeconds(timeDelay); 
        this.gameObject.GetComponent<Light>().enabled = true; //turns on light
        lightBulbMaterial.SetColor("_EmissionColor", Color.white);
        timeDelay = Random.Range(0.01f, 1f); //random time delay
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false; //sets isflickering to false to flicker again
        yield return null;
    }
}
