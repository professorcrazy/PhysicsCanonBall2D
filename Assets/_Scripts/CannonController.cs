using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CannonController : MonoBehaviour
{
    public string PlayerName = "Player1";
    [SerializeField] float canonAngle = 10f;
    [SerializeField] TMP_Text canonAngleTxt;
    [SerializeField] float canonPower = 5f;
    [SerializeField] TMP_Text canonPowerTxt;
    [SerializeField] float ballWeight = 5f;
    [SerializeField] TMP_Text BallWeightTxt;
    [SerializeField] Slider canonPowerSlider;
    [SerializeField] GameManager manager;

    [SerializeField] int hp = 3;
    [SerializeField] int maxhp = 3;

    [SerializeField] float lastShotLength = 0;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
    }

    public void GetLastShotLength()
    {

    }
    public void SetBallWeight(float weight)
    {
        ballWeight = weight;
        BallWeightTxt.text = weight.ToString();
    }
    public void AdjustAngle(float _angle)
    {
        canonAngle += _angle;
        canonAngleTxt.text = canonAngle.ToString();
    }

    public void AdjustCanonPower()
    {
        canonPower = canonPowerSlider.value;
        canonAngleTxt.text += canonPower.ToString();
    }
    public void Fire()
    {
        Debug.Log("Shoot Ball");
        manager.SwitchTurn();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("Player " + PlayerName + " Died");
        }
    }

}
