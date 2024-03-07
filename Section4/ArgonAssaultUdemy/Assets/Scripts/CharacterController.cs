using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Where is the player located right now
    // How can I move the player
    [Header("General Setup Settings from the Ship")]
    [Tooltip("Speed and Pitch/Yaw")]
    [SerializeField] private float justSpeed = 11.0f;
    [SerializeField] private float xRange = 7.0f;
    [SerializeField] private float yRange = 7.0f;
    [SerializeField] private float pitchFactorBasedOnThePositionOfTheScreen = -5f;
    [SerializeField] private float controlPitchFactor = -15f;
    [SerializeField] private float yawFactorBasedOnPositionOfTheScreen = -3f;
    [SerializeField] private float controlRollfactor = -10.0f;
    private float xThrow, yThrow;

    [Header("Lasers objects")]
    [Tooltip("Insert here the lasers as particle systems")]
    [SerializeField] private GameObject[] lasersObjects;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FnTranslation();
        FnRotation();
        FnFiring();
    }
    
    void FnRotation()
    {
        // It is important to avoid global rotation to avoid "changes on the camera"
        // the order matters.... let's use Quaternion!
        
        // pitch, yaw and roll
        
        // pitchDueToPosition = transform.localPosition.y * pitchFactor
        // pitchDueControlThrow = yThrow * controlPitchFactor
        
        float pitch = transform.localPosition.y * pitchFactorBasedOnThePositionOfTheScreen + yThrow*controlPitchFactor;
        float yaw = transform.localPosition.x * yawFactorBasedOnPositionOfTheScreen; // horizontal axis (x)
        float roll = xThrow * controlRollfactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
    void FnTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        // Debug.Log(xThrow);
        // Debug.Log(yThrow);

        float clampedPosX = Mathf.Clamp(transform.localPosition.x + justSpeed * xThrow * Time.deltaTime, -xRange, xRange);
        float clampedPosY = Mathf.Clamp(transform.localPosition.y + justSpeed * yThrow * Time.deltaTime, -yRange, yRange);
        

        transform.localPosition = new Vector3(
            clampedPosX, 
            clampedPosY, 
            transform.localPosition.z);
    }

    void FnFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            foreach (GameObject laser in lasersObjects)
            {
                // laser.SetActive(true);
                EnableEmissionParticles(laser, true);
            }
        }
        else
        {
            foreach (GameObject laser in lasersObjects)
            {
                // laser.SetActive(false);
                EnableEmissionParticles(laser, false);
            }
        }
            // then print shooting
        // else not
    }


    void EnableEmissionParticles(GameObject laser, bool action)
    {
        ParticleSystem.EmissionModule emissionParticleSystem = laser.GetComponent<ParticleSystem>().emission;
        emissionParticleSystem.enabled = action;
    }
    
}
