using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CannonController : MonoBehaviour
{
    public string playerName = "Player 1";
    [SerializeField] TMP_Text playerNameTxt;
    public int playerID;
    [SerializeField] int ballWeight = 4;
    [SerializeField] TMP_Text ballWeightTxt;
    [SerializeField] Slider canonPowerSlider;
    GameManager manager;

    [SerializeField] int hp = 3;
    [SerializeField] int maxhp = 3;
    [SerializeField] TMP_Text hpTxt;
    [SerializeField] float lastShotLength = 0;
    [SerializeField] TMP_Text lastShotDistTxt;

    [SerializeField] TMP_Text enemyDistTxt;

    [Header("Gravity Calc")]
    [SerializeField] float g = 9.82f;
    [SerializeField] float canonAngle = 10f;
    [SerializeField] TMP_Text canonAngleTxt;
    [SerializeField] float canonPower = 5f;
    [SerializeField] TMP_Text canonPowerTxt;

    CannonController enemyController;
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
        for (int i = 0; i < manager.playerList.Count; i++)
        {
            if (manager.playerList[i].gameObject != this.gameObject) { 
                enemyController = manager.playerList[i];
                playerID = i+1;
                playerName = "Player " + playerID.ToString();
                playerNameTxt.text = playerName;
                break;
            }
        } 
        
        hp = maxhp;
        hpTxt.text = hp.ToString();
        canonAngleTxt.text = canonAngle.ToString("00");
        canonPowerSlider.value = canonPower;
        canonPowerTxt.text = canonPower.ToString("00");
        ballWeightTxt.text = ballWeight.ToString();
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
        manager.SwitchTurn();
        if (Mathf.Abs(ShotDistCalc() - manager.playerDistance) < distanceThresshold)
        {
            enemyController.TakeDamage(ballWeight);
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        hpTxt.text = hp.ToString();
        if (hp <= 0)
        {
            manager.GameOver(playerName);
            Debug.Log("Player " + playerName + " Died");
        }
    }
    private float ShotDistCalc()
    {
        lastShotLength = Mathf.RoundToInt(((canonPower * canonPower) * Mathf.Sin((2 * canonAngle * Mathf.PI)/ 180)) / g);
        Debug.Log("ShotCalc: " + lastShotLength.ToString("00.0"));
        return lastShotLength;
    }
}