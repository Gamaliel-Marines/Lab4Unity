using UnityEngine;
using TMPro;

public class AmmunitionCounter : MonoBehaviour
{
    public TextMeshProUGUI ammunitionDisplay;

    private PlayerShooting playerShooting;  // Reference to PlayerShooting component

    private void Awake()
    {
        // Attempt to find the PlayerShooting component
        playerShooting = GetComponentInParent<PlayerShooting>();

        if (playerShooting != null)
        {
            // Use the found component to initialize variables
            bulletsLeft = playerShooting.MagazineSize;
            magazineSize = playerShooting.MagazineSize;
        }
        else
        {
            Debug.LogError("AmmunitionCounter: PlayerShooting component not found in parent.");
        }
    }

    private void Update()
    {
        if (ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft + " / " + magazineSize);
        }
    }

    public void UpdateAmmunition(int bullets)
    {
        bulletsLeft = bullets;
    }
}
