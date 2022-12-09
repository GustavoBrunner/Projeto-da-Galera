using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : TransformController
{
    private Vector3 newPos;
    Transform Target;
    float TargetSpeed = 2f;
    
    protected override void Awake()
    {
        base.Awake();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    void LateUpdate()
    {
        UpdatePos();
    }
    void UpdatePos()
    {//armazena a posição do player em uma variável, depois interpola linearmente as posições do player nos eixos x, y, e a posição z da câmera
     //Basicamente faz a diferença entre um e outro. Transform.position = vector a, new vector 3 = vector b e time.deltatime = float
        
        newPos = new Vector3(Target.position.x, Target.position.y, tf.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, TargetSpeed*Time.deltaTime);
        
    }
}
