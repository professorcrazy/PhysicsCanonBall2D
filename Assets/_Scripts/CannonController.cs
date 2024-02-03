using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CannonController : MonoBehaviour
{
    public string PlayerName = "Player1";
    [SerializeField] int ballWeight = 4;
    [SerializeField] TMP_Text ballWeightTxt;
    [SerializeField] Slider canonPowerSlider;
    GameManager manager;

    [SerializeField] int hp = 3;
    [SerializeField] int maxhp = 3;

    [SerializeField] float lastShotLength = 0;
    [SerializeField] TMP_Text lastShotDistTxt;

    [SerializeField] TMP_Text enemyDistTxt;

    [Header("Gravity Calc")]
    [SerializeField] float g = 9.82f;
    [SerializeField] float canonAngle = 10f;
    [SerializeField] TMP_Text canonAngleTxt;
    [SerializeField] float canonPower = 5f;
    [SerializeField] TMP_Text canonPowerTxt;

    [SerializeField] CannonController enemyController;
    private float distanceThresshold = 0.5f;

    public float GetCannonAngle()
    {
        return canonAngle;
    }
    public float GetCannonPower()
    {
        return canonPower;
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
        hp = maxhp;
        canonAngleTxt.text = canonAngle.ToString("00");
        canonPowerSlider.value = canonPower;
        canonPowerTxt.text = canonPower.ToString("00");
        ballWeightTxt.text = ballWeight.ToString();
        foreach (CannonController c in FindObjectsOfType<CannonController>())
        {
            if (c != this) {
                enemyController = c;
            }
        }
    }
    public void GetEnemyDistance()
    {
        enemyDistTxt.text = manager.playerDistance.ToString("00,0");
        manager.SwitchTurn();
    }
    public void GetLastShotLength()
    {
        lastShotDistTxt.text = lastShotLength.ToString("00,0");
        manager.SwitchTurn();
    }
    public void SetBallWeight(int weight)
    {
        ballWeight = weight;
        ballWeightTxt.text = weight.ToString() + " kg";
    }
    public void AdjustAngle(float _angle)
    {
        canonAngle += _angle;
        canonAngleTxt.text = canonAngle.ToString("00");
    }

    public void AdjustCanonPower()
    {
        canonPower = canonPowerSlider.value;
        canonPowerTxt.text = canonPower.ToString("00");
    }
    public void Fire()
    {
        Debug.Log("Shoot Ball");
        manager.SwitchTurn();
        if (Mathf.Abs(ShotDistCalc() - manager.playerDistance) < distanceThresshold)
        {
            enemyController.TakeDamage(ballWeight);
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("Player " + PlayerName + " Died");
        }
    }
    private float ShotDistCalc()
    {
        lastShotLength = ((canonPower * canonPower) * Mathf.Sin(2 * canonAngle)) / g;
        return lastShotLength;
    }
}