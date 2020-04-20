using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Interactions;

public class PaddleController : MonoBehaviour
{
    public Canvas canvas;
    public GameLevelManager gameLevelManager;
    public float moveSpeed;
    public float rotateSpeed;
    public float burstFireSpeed;
    public int burstFireMax;
    public float jumpPreload;
    public int jumpPreloadMax;

    public float jumpVariableHorizontal;
    public float jumpFixedHorizontal;
    public float jumpVertical;

    public GameObject projectile;

    public Vector3 lookAtOffset;
    public float followDistance;

    private NavMeshAgent m_FollowCamera;

    private PaddleControls m_Controls;
    private ArrayList m_LevelTokens;
    private int m_TotalNumLevelTokens;
    private bool m_IsGameOver;
    private bool m_Grounded;
    private bool m_FireCharging;
    private bool m_JumpPreloading;
    private Vector2 m_Rotation;
    private float m_CurrentMovementMagnitude;

    public void Awake()
    {
        m_Rotation = transform.localEulerAngles;

        m_FollowCamera = Camera.main.GetComponent<NavMeshAgent>();

        m_LevelTokens = new ArrayList();
        m_TotalNumLevelTokens = 0;
        foreach (CollectableObject co in FindObjectsOfType<CollectableObject>())
        {
            if (co.IsLevelToken)
                m_TotalNumLevelTokens++;
        }

        m_IsGameOver = false;

        m_Controls = new PaddleControls();

        m_Controls.gameplay.fire.performed +=
            ctx =>
            {
                if ((gameLevelManager.State == GameLevelManager.GameState.Playing) && (GameCoordinator.Instance.Health > 0))
                {
                    // if (ctx.interaction is SlowTapInteraction)
                    // {
                    //     StartCoroutine(BurstFire(1 + (int) (ctx.duration * burstFireSpeed)));
                    // }
                    // else
                    {
                        Fire();
                    }
                }

                m_FireCharging = false;
            };
        m_Controls.gameplay.fire.started +=
            ctx =>
            {
                if (GameCoordinator.Instance.Health > 0)
                {
                    if (ctx.interaction is SlowTapInteraction)
                        m_FireCharging = true;
                }
            };
        m_Controls.gameplay.fire.canceled +=
            ctx =>
            {
                //Debug.Log($"Fire cancelled");
                m_FireCharging = false;
            };

        m_Controls.gameplay.jump.performed +=
            ctx =>
            {
                //Debug.Log($"Jump {ctx.interaction.ToString()} performed for {ctx.duration}");

                if ((gameLevelManager.State == GameLevelManager.GameState.Playing) && (GameCoordinator.Instance.Health > 0) && m_Grounded)
                {
                    if (ctx.interaction is MultiTapInteraction multiTap)
                    {
                        Jump(1 + (int) (multiTap.tapCount * jumpPreload));
                    }
                    else if (ctx.interaction is SlowTapInteraction)
                    {
                        Jump(1 + (int) (ctx.duration * jumpPreload));
                    }
                    else
                    {
                        Jump(1);
                    }
                }

                m_JumpPreloading = false;
            };
        m_Controls.gameplay.jump.started +=
            ctx =>
            {
                if (GameCoordinator.Instance.Health > 0)
                {
                    if (ctx.interaction is SlowTapInteraction)
                        m_JumpPreloading = true;
                }
            };
        m_Controls.gameplay.jump.canceled +=
            ctx =>
            {
                //Debug.Log($"Jump cancelled");
                m_JumpPreloading = false;
            };
    }

    public void OnEnable()
    {
        m_Controls.Enable();
    }

    public void OnDisable()
    {
        m_Controls.Disable();
    }

    public void Start()
    {
        // Hack for development - without the Intro UI, we'll never leave the Intro state
        //if (!canvas.isActiveAndEnabled && (gameLevelManager.State == GameLevelManager.GameState.Intro))
        //{
        //    Debug.Log("Development: Forcing GameState.Playing");
        //    gameLevelManager.ChangeState(GameLevelManager.GameState.Playing);
        //}

        // if (GameCoordinator.Instance == null)
        // {
        //     Debug.Log($"Development: Adding GameCoordinator to {this.gameObject.name}");
        //     this.gameObject.AddComponent<GameCoordinator>();
        // }
    }

    //public void OnGUI()
    //{
    //    GUI.Label(new Rect(100, 40, 200, 100), $"ENERGY: {m_ChargeLevel}");
    //    GUI.Label(new Rect(100, 55, 200, 100), $"AMMO: {m_AmmoLevel}");

    //    GUI.Label(new Rect(100, 85, 200, 100), m_Grounded ? "GROUNDED" : "IN-AIR");

    //    if (m_FireCharging)
    //        GUI.Label(new Rect(100, 100, 200, 100), "Charging...");
    //    if (m_JumpPreloading)
    //        GUI.Label(new Rect(100, 100, 200, 100), "Preloading...");
    //}

    public void FixedUpdate()
    {
        // int layerMask = LayerMask.GetMask(new String[] { "BaseLevel" });
        // if (Physics.Raycast(transform.position, Vector3.down, 1.0f, layerMask) ||
        //     Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 0.0f), Vector3.down, 1.0f, layerMask) ||
        //     Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 0.0f), Vector3.down, 1.0f, layerMask) ||
        //     Physics.Raycast(new Vector3(transform.position.x + 0.0f, transform.position.y, transform.position.z + 0.5f), Vector3.down, 1.0f, layerMask) ||
        //     Physics.Raycast(new Vector3(transform.position.x + 0.0f, transform.position.y, transform.position.z - 0.5f), Vector3.down, 1.0f, layerMask) ||
        //     this.GetComponent<Rigidbody>().IsSleeping())
        // {
        //     if (!m_Grounded)
        //     {
        //         this.GetComponent<Rigidbody>().freezeRotation = false;
        //         this.GetComponent<Rigidbody>().isKinematic = true;
        //
        //         this.GetComponent<NavMeshAgent>().enabled = true;
        //         this.GetComponent<NavMeshAgent>().Warp(this.transform.position);
        //
        //         m_Grounded = true;
        //     }
        // }
        // else
        // {
        //     if (!this.GetComponent<NavMeshAgent>().enabled)
        //     {
        //         m_Grounded = false;
        //     }
        // }

        //if (m_ChargeLevel > 0)
        //{
        //    m_ChargeLevel--;
        //}
    }

    public void Update()
    {
        var look = m_Controls.gameplay.look.ReadValue<Vector2>();
        // Update orientation first, then move. Otherwise move orientation will lag
        // behind by one frame.
        Look(look);

        var move = m_Controls.gameplay.move.ReadValue<Vector2>();
        Move(move);

        UpdateFollowCamera();
    }

    private void Move(Vector2 direction)
    {
        m_CurrentMovementMagnitude = 0.0f;

        if ((gameLevelManager.State == GameLevelManager.GameState.Playing) && (GameCoordinator.Instance.Health > 0) && !m_IsGameOver)
        {
            if ((Mathf.Abs(direction.x) > 0.01) || (Mathf.Abs(direction.y) > 0.01))
            {
                Vector3 inputDir = new Vector3(-direction.y, 0.0f, direction.x);
                Vector3 pos = transform.position + moveSpeed * Time.deltaTime * inputDir;

                pos.x = Mathf.Clamp(pos.x, -2.0f, 2.0f);
                pos.z = Mathf.Clamp(pos.z, -2.0f, 2.0f);
                transform.position = pos;
            }
            // if (Mathf.Abs(direction.x) > 0.01)
            // {
            //     // Rotate
            //     if (m_Grounded)
            //     {
            //         var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
            //         m_Rotation.y += direction.x * scaledRotateSpeed;
            //         transform.localEulerAngles = m_Rotation;
            //     }
            // }
            //
            // if (Mathf.Abs(direction.y) > 0.01)
            // {
            //     // Move
            //     m_CurrentMovementMagnitude = direction.y;
            //     if (m_Grounded)
            //     {
            //         transform.position += transform.forward * (m_CurrentMovementMagnitude * moveSpeed * Time.deltaTime);
            //     }
            // }
        }

        //if (direction.sqrMagnitude < 0.01)
        //    return;
        //// For simplicity's sake, we just keep movement in a single plane here. Rotate
        //// direction according to world Y rotation of player.
        //var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        //var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        //transform.position += move * scaledMoveSpeed;
    }

    private void UpdateFollowCamera()
    {
        if (m_FollowCamera != null)
        {
            m_FollowCamera.SetDestination(this.transform.position - this.transform.forward * followDistance);
            m_FollowCamera.gameObject.transform.LookAt(this.transform.position +
                                                       transform.TransformDirection(lookAtOffset));
        }
    }

    private void Look(Vector2 rotate)
    {
        //if (rotate.sqrMagnitude < 0.01)
        //    return;
        //var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        //m_Rotation.y += rotate.x * scaledRotateSpeed;
        //m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        //transform.localEulerAngles = m_Rotation;
    }

    private void CheckWinLossConditions()
    {
        if (m_LevelTokens.Count == m_TotalNumLevelTokens)
        {
            // Win!
            m_IsGameOver = true;
            Debug.Log("Win condition met!");

            gameLevelManager.ChangeState(GameLevelManager.GameState.Won);
        }
        else if (GameCoordinator.Instance.Health <= 0)
        {
            // Loss :(
            m_IsGameOver = true;
            Debug.Log("Loss condition met!");

            gameLevelManager.ChangeState(GameLevelManager.GameState.Lost);
        }
    }

    private IEnumerator BurstFire(int burstAmount)
    {
        burstAmount = Mathf.Clamp(burstAmount, 1, burstFireMax);

        for (var i = 0; i < burstAmount; ++i)
        {
            Fire();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Fire()
    {
        // if (GameCoordinator.Instance.Ammo > 0)
        {
            // GameCoordinator.Instance.Ammo--;

            foreach (FlipperController flipper in gameLevelManager.Flippers)
            {
                flipper.ActivateFlipper();
            }

            // var transform = this.transform;
            // var newProjectile = Instantiate(projectile);
            // newProjectile.transform.position = transform.position + transform.forward * 1.5f;
            // newProjectile.transform.rotation = transform.rotation;
            // //const int size = 1;
            // //newProjectile.transform.localScale *= size;
            // //newProjectile.GetComponent<Rigidbody>().mass = Mathf.Pow(size, 3);
            // newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 32.0f, ForceMode.Impulse);
            // //newProjectile.GetComponent<MeshRenderer>().material.color =
            // //    new Color(Random.value, Random.value, Random.value, 1.0f);
        }
    }

    private void Jump(int jumpAmount)
    {
        jumpAmount = Mathf.Clamp(jumpAmount, 1, jumpPreloadMax);
        //Debug.Log($"Jumping {jumpAmount}!");

        this.GetComponent<NavMeshAgent>().enabled = false;
        this.GetComponent<Rigidbody>().freezeRotation = true;
        this.GetComponent<Rigidbody>().isKinematic = false;

        Vector3 velocity = (m_CurrentMovementMagnitude * jumpVariableHorizontal * transform.forward) +
                           (jumpFixedHorizontal * transform.forward);
        velocity.y += jumpVertical;

        velocity *= (float) jumpAmount;

        this.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);

        //Debug.Log("Jumping: " + velocity.ToString());

        //var transform = this.transform;
        //var newProjectile = Instantiate(projectile);
        //newProjectile.transform.position = transform.position + transform.forward * 0.6f;
        //newProjectile.transform.rotation = transform.rotation;
        //const int size = 1;
        //newProjectile.transform.localScale *= size;
        //newProjectile.GetComponent<Rigidbody>().mass = Mathf.Pow(size, 3);
        //newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);
        //newProjectile.GetComponent<MeshRenderer>().material.color =
        //    new Color(Random.value, Random.value, Random.value, 1.0f);
    }

    // Only called when one of the objects' RigidBody is non-kinematic!
    private void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        //Destroy(gameObject);

        ProcessCollision(collision.gameObject);
    }

    // Called regardless of if there are non-kinematic RigidBody's involved
    private void OnTriggerEnter(Collider other)
    {
        ProcessCollision(other.gameObject);
    }

    // Called regardless of if there are non-kinematic RigidBody's involved
    private void ProcessCollision(GameObject otherGameObject)
    {
        if (otherGameObject.layer == LayerMask.NameToLayer("BaseLevel"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Props"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            DamageObject damageObj = otherGameObject.GetComponentInParent<DamageObject>();
            if (damageObj != null)
            {
                if (GameCoordinator.Instance.Health > 0)
                {
                    GameCoordinator.Instance.Health -= damageObj.Value;
                    if (GameCoordinator.Instance.Health <= 0)
                    {
                        GameCoordinator.Instance.Health = 0;
                    }

                    Debug.Log($"Took damage {damageObj.Value} from enemy {otherGameObject.name}");

                    CheckWinLossConditions();
                }
            }
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Player"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("Collectables"))
        {
            if (!m_IsGameOver)
            {
                CollectableObject co = otherGameObject.GetComponentInParent<CollectableObject>();
                if (co != null)
                {
                    GameCoordinator.Instance.Health += co.RechargeValue;
                    GameCoordinator.Instance.Ammo += co.AmmoValue;

                    if (co.IsLevelToken)
                    {
                        m_LevelTokens.Add(otherGameObject.name);
                    }
                }

                Debug.Log("Collected " + otherGameObject.name);
                Destroy(otherGameObject);

                CheckWinLossConditions();
            }
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("PlayerProjectiles"))
        {
        }
        else if (otherGameObject.layer == LayerMask.NameToLayer("EnemyProjectiles"))
        {
            DamageObject damageObj = otherGameObject.GetComponentInParent<DamageObject>();
            if (damageObj != null)
            {
                if (GameCoordinator.Instance.Health > 0)
                {
                    GameCoordinator.Instance.Health -= damageObj.Value;
                    if (GameCoordinator.Instance.Health <= 0)
                    {
                        GameCoordinator.Instance.Health = 0;
                    }

                    Debug.Log($"Took damage {damageObj.Value} from projectile {otherGameObject.name}");

                    CheckWinLossConditions();
                }
            }
        }
    }
}
