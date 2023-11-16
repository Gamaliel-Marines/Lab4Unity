using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedFire1 : MonoBehaviour
{
    private enum ShootingPattern
    {
        Linear,
        Star,
        Circular
    }

    private ShootingPattern currentPattern = ShootingPattern.Linear;

    [SerializeField]
    private int bulletsAmount = 3;

    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;

    private float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangePattern", 10f, 10f); // Change pattern every 10 seconds
        InvokeRepeating("Fire", 0f, 1f); // Start firing
    }

    private void ChangePattern()
    {
        currentPattern = (ShootingPattern)(((int)currentPattern + 1) % 3); // Cycle through patterns
        CancelInvoke("Fire");
        InvokeRepeating("Fire", 0f, 1f); // Update fire rate
    }

    private void Fire()
    {
        switch (currentPattern)
        {
            case ShootingPattern.Linear:
                FireFisrtPattern();
                break;
            case ShootingPattern.Star:
                FireSecondPattern();
                break;
            case ShootingPattern.Circular:
                FireFourLinesPattern();
                break;
        }
    }

    private void FireSecondPattern()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float currentAngle = startAngle;

        for (int i = 0; i < bulletsAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180f);
            float bulDirZ = transform.position.z + Mathf.Cos((currentAngle * Mathf.PI) / 180f);
            float bulDirY = 1f;

            Vector3 bulMoveVector = new Vector3(bulDirX, transform.position.y, bulDirZ);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool1.Instance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            currentAngle += angleStep;
        }
    }

    private void FireFourLinesPattern()
    {
        int linesAmount = 4;
        int bulletsPerLine = bulletsAmount / linesAmount;
        float angleStep = (endAngle - startAngle) / bulletsPerLine;

        for (int line = 0; line < linesAmount; line++)
        {
            float lineStartAngle = startAngle + (line * 90f); // 90 degrees between each line

            for (int i = 0; i < bulletsPerLine; i++)
            {
                float currentAngle = lineStartAngle + i * angleStep;

                float bulDirX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180f);
                float bulDirZ = transform.position.z + Mathf.Cos((currentAngle * Mathf.PI) / 180f);
                float bulDirY = 1f;

                Vector3 bulMoveVector = new Vector3(bulDirX, transform.position.y, bulDirZ);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool1.Instance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            }
        }
    }




    private void FireFisrtPattern()
    {
            float bulDirX = transform.position.x + Mathf.Sin(angle * Mathf.Deg2Rad);
            float bulDirY = transform.position.y;
            float bulDirZ = transform.position.z + Mathf.Cos(angle * Mathf.Deg2Rad);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, bulDirZ);
            Vector3 bulDir = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

            GameObject bul = BulletPool1.Instance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = Quaternion.LookRotation(bulDir); // Use LookRotation to orient the bullet in the specified direction
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += 10f;
    }


}
