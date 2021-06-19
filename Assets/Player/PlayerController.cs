using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove;
    public float moveSpeed = 5f;

    [HideInInspector]
    public Rigidbody2D rb;

    [Header("Animations")]
    public Animator animator;

    [Header("Equipment")]
    public Hats hatSlot;
    public Chests chestSlot;
    public LegWear legSlot;

    [Header("Slot")]
    public GearPart headPart;
    public GearPart chestPart;
    public GearPart legPart;

    Vector2 move;


    // Start is called before the first frame update
    void Start()
    {
        // ANNEX RIGIDBODY
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // DETECT INPUT KEYS
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);

        if (hatSlot != null)
            AnimateHead();

        if (chestSlot != null)
            AnimateChest();

        if (legSlot != null)
            AnimateLegs();

    }

    void FixedUpdate()
    {
        // MUST NOT MOVE WHEN DOING ACTION
        if (canMove)
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // SET EQUIP
    public void SetEquipHead(Hats newHat)
    {
        hatSlot = newHat;
        headPart.mySprite.sprite = hatSlot.itemImage;
        headPart.partAnimator.runtimeAnimatorController = hatSlot.animatorController;
    }

    // ANIMATE HEAD
    void AnimateHead()
    {
        headPart.partAnimator.SetFloat("Horizontal", move.x);
        headPart.partAnimator.SetFloat("Vertical", move.y);
        headPart.partAnimator.SetFloat("Speed", move.sqrMagnitude);
    }

    public void SetEquipChest(Chests newChest)
    {
        chestSlot = newChest;
        chestPart.mySprite.sprite = chestSlot.itemImage;
        chestPart.partAnimator.runtimeAnimatorController = chestSlot.animatorController;
    }

    // ANIMATE CHEST
    void AnimateChest()
    {
        chestPart.partAnimator.SetFloat("Horizontal", move.x);
        chestPart.partAnimator.SetFloat("Vertical", move.y);
        chestPart.partAnimator.SetFloat("Speed", move.sqrMagnitude);
    }

    public void SetEquipBoots(LegWear newLegs)
    {
        legSlot = newLegs;
        legPart.mySprite.sprite = legSlot.itemImage;
        legPart.partAnimator.runtimeAnimatorController = legSlot.animatorController;
    }

    // ANIMATE BOOT
    void AnimateLegs()
    {
        legPart.partAnimator.SetFloat("Horizontal", move.x);
        legPart.partAnimator.SetFloat("Vertical", move.y);
        legPart.partAnimator.SetFloat("Speed", move.sqrMagnitude);
    }
}
