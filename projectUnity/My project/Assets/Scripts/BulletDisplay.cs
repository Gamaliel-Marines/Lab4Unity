using TMPro;
using UnityEngine;

public class BulletDisplay : MonoBehaviour
{
    public TextMeshProUGUI bulletTextMesh;
    private int bulletCount;

    public int GetActiveBulletCount()
    {
        int count = 0;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            count++;
        }
        return count;
    }

    void Update()
    {
        if (bulletTextMesh != null)
        {
            bulletCount = GetActiveBulletCount();
            // Actualiza el TextMesh con la cantidad de balas
            // Aquí estoy asumiendo que tienes una manera de obtener la cantidad de balas
            // Por ejemplo, podría ser bulletPool.activeBulletCount o algo similar
            if (bulletCount >= 0)
            {
                bulletTextMesh.text = bulletCount.ToString();
            }
            else
            {
                bulletTextMesh.text = "0";
            }
        }
    }
}