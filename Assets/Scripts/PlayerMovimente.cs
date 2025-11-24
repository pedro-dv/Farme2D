using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PlayerMovimente : MonoBehaviour
{
    public float speed = 5f;
    private float moveHorizontal;
    public float xRange;   

    public GameObject projectilePrefab;

    public float launchSpeed = 40.0f;


   
   
   

  
    void Update()
    {
        
        if (transform.position.x < xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveHorizontal * speed * Time.deltaTime);




    //---------------------------------------------------------------------------------------------- resumo: Quando o Espaço é pressionado, o código cria (instancia) uma cópia do objeto projectilePrefab exatamente onde o jogador está, usando a rotação predefinida do projétil.
        if (Input.GetKeyDown(KeyCode.Space))
        {
        // 1. Instanciar e armazenar a referência
        // 'as GameObject' é um cast (conversão) para garantir que seja tratado como um GameObject
            Instantiate( projectilePrefab,transform.position,projectilePrefab.transform.rotation );
        }
    }
}
