using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAttack : MonoBehaviour
{
    public float speed = 10f;
    public int attackDamage = 5;

    float movement;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        StartCoroutine(throwDistance());
    }

    IEnumerator throwDistance(){
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

   //Deletes the projectile when it hits something
    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacleComponent)){
            obstacleComponent.TakeDamage(attackDamage);
        }

        Destroy(gameObject);
    }
}
