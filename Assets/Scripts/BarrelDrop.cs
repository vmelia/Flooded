using UnityEngine;

public class BarrelDrop : MonoBehaviour
{
    public GameObject Object;
    public CharacterController Controller;

    private const int _count = 10;

    public void Update()
    {
        var dropBarrels = Input.GetKey(KeyCode.B);
        if (!dropBarrels) 
            return;

        var startX = Controller.transform.position.x - _count / 2.0f;
        var startZ = Controller.transform.position.z - _count / 2.0f;
        var height = Controller.transform.position.y +100.0f;

        for (var x = startX; x < startX + _count; x++)
        {
            for (var z = startZ; z < startZ + _count; z++)
            {
                var position = new Vector3(x, height, z);
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