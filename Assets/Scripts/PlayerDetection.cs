using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] CrowdSystem crowdSystem;

    private void Update()
    {
        DetectDoor();
    }

    private void DetectDoor()
    {
        Collider[] detectedCollider = Physics.OverlapSphere(transform.position, crowdSystem.GetCrowdRadius());

        if(detectedCollider.Length > 0)
        {
            for(int i = 0; i < detectedCollider.Length; i++)
            {
                if (detectedCollider[i].TryGetComponent(out Doors doors))
                {
                    Debug.Log("kapıya çarptık");

                    int bonusAmount = doors.GetBonusAmount(transform.position.x);
                    BonusType bonusType = doors.GetBonusType(transform.position.x);


                    crowdSystem.ApplyBonus(bonusType, bonusAmount);

                    doors.GetComponent<Collider>().enabled = false;
                }

                else if (detectedCollider[i].CompareTag("Finish"))
                {
                    PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
