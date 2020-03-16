using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class ObjectDrop : MonoBehaviour
{
    public GameObject Object;
    public CharacterController Player;

    private const int _range = 4;

    private IList<GameObject> _objects = new List<GameObject>();

    public void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            DropBarrels();
        }

        if(Input.GetKey(KeyCode.C))
        {
            ClearBarrels();
        }
    }

    private void DropBarrels()
    {
        var height = Player.transform.position.y + 20.0f;

        for (var x = -_range; x <= _range; x++)
        {
            var positionX = Player.transform.position.x + x;
            for (var z = _range; z <= _range; z++)
            {
                var positionZ = Player.transform.position.z + z;
                var position = new Vector3(positionX, height, positionZ);
                var newObject = Instantiate(Object, position, Quaternion.identity);
                RandomlyRotate(newObject);
                _objects.Add(newObject);
                EventBroker.CallObjectAdded();
            }
        }
    }

    private void ClearBarrels()
    {
        while (_objects.Any())
        {
            Destroy(_objects[0]);
            _objects.RemoveAt(0);
        }

        EventBroker.CallObjectsCleared();
    }

    private static void RandomlyRotate(GameObject o)
    {
        var randomX = Random.Range(0.0f, 45.0f);
        var randomZ = Random.Range(0.0f, 45.0f);
        o.transform.Rotate(randomX, 0.0f, randomZ);
    }
}