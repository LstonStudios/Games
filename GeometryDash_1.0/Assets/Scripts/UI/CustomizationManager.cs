using UnityEngine;
using UnityEngine.UI;

public class CustomizationManager : MonoBehaviour
{
    [SerializeField] private Image primaryColorPreview;
    [SerializeField] private Image secondaryColorPreview;
    [SerializeField] private Image playerPreview;

    private Color[] availableColors = new Color[]
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,
        Color.magenta,
        Color.cyan,
        Color.white
    };

    private int[] availableIcons = new int[] { 0, 1, 2, 3, 4 }; // Icon IDs
    private int currentPrimaryColor = 0;
    private int currentSecondaryColor = 1;
    private int currentIcon = 0;

    private void Start()
    {
        LoadPlayerCustomization();
        UpdatePreview();
    }

    private void LoadPlayerCustomization()
    {
        PlayerData data = PlayerProgressManager.Instance.GetPlayerData();
        currentPrimaryColor = data.primaryColor;
        currentSecondaryColor = data.secondaryColor;
        currentIcon = data.selectedIcon;
    }

    public void NextPrimaryColor()
    {
        currentPrimaryColor = (currentPrimaryColor + 1) % availableColors.Length;
        UpdatePreview();
    }

    public void PreviousPrimaryColor()
    {
        currentPrimaryColor = (currentPrimaryColor - 1 + availableColors.Length) % availableColors.Length;
        UpdatePreview();
    }

    public void NextSecondaryColor()
    {
        currentSecondaryColor = (currentSecondaryColor + 1) % availableColors.Length;
        UpdatePreview();
    }

    public void PreviousSecondaryColor()
    {
        currentSecondaryColor = (currentSecondaryColor - 1 + availableColors.Length) % availableColors.Length;
        UpdatePreview();
    }

    public void NextIcon()
    {
        currentIcon = (currentIcon + 1) % availableIcons.Length;
        UpdatePreview();
    }

    public void PreviousIcon()
    {
        currentIcon = (currentIcon - 1 + availableIcons.Length) % availableIcons.Length;
        UpdatePreview();
    }

    private void UpdatePreview()
    {
        primaryColorPreview.color = availableColors[currentPrimaryColor];
        secondaryColorPreview.color = availableColors[currentSecondaryColor];
        playerPreview.color = availableColors[currentPrimaryColor];
    }

    public void SaveCustomization()
    {
        PlayerProgressManager.Instance.SetPlayerColors(currentPrimaryColor, currentSecondaryColor);
        PlayerProgressManager.Instance.SetPlayerIcon(currentIcon);
        PlayerProgressManager.Instance.SavePlayerData();
        Debug.Log("Customization saved!");
    }
}
