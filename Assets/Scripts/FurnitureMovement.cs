using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //the speed the furniture -- make this private tmrw
    public float speed = 5;

    //the direction the furniture is moving
    private Vector3 dir;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //create random vector to start from
        dir = Vector3.Normalize(new Vector3(Random.value, Random.value, Random.value));
        //regenerate values to prevent directly horizontal or stationary cases
        while (dir.x == 0 || dir.y == 0 || dir.z == 0 || dir.x == 1 || dir.y == 1 || dir.z == 1)
        {
            dir = Vector3.Normalize(new Vector3(Random.value, Random.value, Random.value));
        }

    }

    // Update is called once per frame
    void Update()
    {
        // move the furniture
        transform.Translate(dir * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //bounce the furniture
        Vector3 normal = collision.GetContact(0).normal;
        Vector3 reflected = Vector3.Reflect(dir, normal);
        reflected.z = 0;
        dir = Vector3.Normalize(reflected);
        if (dir == Vector3.right || dir == Vector3.left || dir == Vector3.down || dir == Vector3.up)
        {
            dir.y += 0.1f;
        }
        // make if fade out and in and turn red
        if (collision.gameObject.CompareTag("House"))
        {
            StartCoroutine("TurnRed");
        }
        


    }

    IEnumerator TurnRed()
    {
        //get list of renderers
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        float[,] colors = new float[renderers.Length,3];
        Material[] materials = new Material[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            materials[i] = renderers[i].material;
            colors[i, 0] = renderers[i].material.color.r;
            colors[i, 1] = renderers[i].material.color.g;
            colors[i, 2] = renderers[i].material.color.b;
        }
        //change color to red and fade out
  
        for (int i = 0; i < renderers.Length; i++)
        {
            Material mat = renderers[i].material;
            Color col = mat.color;
            mat.color = new Color(1, 0, 0, 0.7f);
            yield return new WaitForSeconds(0.2f);
            mat.color = new Color(colors[i,0], colors[i,1], colors[i,2], 1f);
        }
    



        yield return null;
    }
}
