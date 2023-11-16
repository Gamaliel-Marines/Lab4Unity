using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern2 : MonoBehaviour
{
    private float angle = 0f;

    [SerializeField]
    private int bulletsAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin(angle * Mathf.Deg2Rad);
        float bulDirY = transform.position.y;
        float bulDirZ = transform.position.z + Mathf.Cos(angle * Mathf.Deg2Rad);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, bulDirZ);
        Vector3 bulDir = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

        GameObject bul = BulletPool.Instance.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = Quaternion.LookRotation(bulDir); // Use LookRotation to orient the bullet in the specified direction
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

        angle += 10f;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
