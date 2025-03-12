using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int id;
    private void Start()
    {
        Invoke("Despawn", 10f);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-2, 0, 0)*Time.deltaTime;
    }
    void Despawn()
    {
        SimplePool2.Despawn(this.gameObject);
        Invoke("Despawn", 10f);
    }

}
