﻿using UnityEngine;

public class BarrelDrop : MonoBehaviour
{
    public GameObject Object;
    public CharacterController Controller;

    private const int _range = 4;

    public void Update()
    {
        var dropBarrels = Input.GetKey(KeyCode.B);
        if (!dropBarrels) 
            return;

        var height = Controller.transform.position.y +20.0f;

        for (var x = -_range; x <= _range; x++)
        {
            var positionX = Controller.transform.position.x + x;
            for (var z = _range; z <= _range; z++)
            {
                var positionZ = Controller.transform.position.z + z;
                var position = new Vector3(positionX, height, positionZ);
                var newObject = Instantiate(Object, position, Quaternion.identity);
                RandomlyRotate(newObject);
            }
        }
    }


    private static void RandomlyRotate(GameObject o)
    {
        var randomX = Random.Range(0.0f, 45.0f);
        var randomZ = Random.Range(0.0f, 45.0f);
        o.transform.Rotate(randomX, 0.0f, randomZ);
    }
}