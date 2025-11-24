using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerMovimente : MonoBehaviour
{
    public float speed = 5f;
    private float moveHorizontal;
    public float xRange;   

    public GameObject projectilePrefab;

    public float launchSpeed = 40.0f;

    private float zLimit = 30.0f;
   
   
   

  
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
            GameObject newProjectile = Instantiate(
                projectilePrefab, 
                transform.position, 
                projectilePrefab.transform.rotation
            );

            // 2. Obter o componente Rigidbody do novo projétil
        // 2. Obter o Rigidbody do NOVO OBJETO
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            
            // 3. Aplicar a velocidade
            if (rb != null)
            {
                // O jogador é quem está atirando.
                // Assumindo que você quer que o projétil vá na direção FORWARD (Z positivo, ou para onde o jogador aponta).
                rb.velocity = transform.forward * launchSpeed; 
            }  

            if (transform.position.z > zLimit)
            {
                Destroy(gameObject);                
            
            }
            
        }
    }
}
