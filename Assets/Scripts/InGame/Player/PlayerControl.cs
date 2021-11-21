using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [Header("Game Contol")]
    public GameController gameControl;

    [Header("Battle Contol")]
    public BattleController battleControl;
    public GameObject BattlePanel;

    [Header("UI")]
    public GameObject playerpanel;
    public GameObject pausePanel;
    public GameObject openInventory;
    public GameObject inventoryDetail;
    public GameObject quest;
    public GameObject equipment;
    public GameObject shop;
    public GameObject UIBattle;
    public GameObject UIPlayerAttribute;
    public GameObject info;
    public GameObject infoObj;

    [Header("Inventory")]
    [SerializeField]
    private UI_Inventory ui_Inventory;

    public Inventory inventory;

    [Header("Player Speed")]
    [SerializeField]
    private float speed;

    [Header("Attribute")]
    public PlayerAttribute battleAttribute;
    private PlayerAttribute attribute;


    [Header("Enemy Probability")]
    public int enemyProbability;

    //default img equip
    private GameObject playerEquipment;
    private Sprite Head;
    private Sprite Body;
    private Sprite Hand;
    private Sprite Foot;
    private Sprite Accessories;
    private Sprite Shield;
    private Sprite Weapon;
    public bool equipped;


    [Header("NPC")]
    public GameObject NPC_obj;
    private bool inRangeNPC = false;


    public void Awake()
    {
        print("Dir:" + Application.dataPath);
        inventory = new Inventory();
        ui_Inventory.SetInventory(inventory);
        
        attribute = gameObject.GetComponent<PlayerAttribute>();
        setAttribute();

        playerEquipment = UIPlayerAttribute.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
        foreach(Transform child in playerEquipment.transform)
        {
            switch (child.name)
            {
                case "Head":
                    Head = child.transform.GetChild(0).GetComponent<Image>().sprite;
                    break;
                case "Body":
                    Body = child.transform.GetChild(0).GetComponent<Image>().sprite;
                    break;
                case "Hand":
                    Hand = child.transform.GetChild(0).GetComponent<Image>().sprite;
                    break;
                case "Foot":
                    Foot = child.transform.GetChild(0).GetComponent<Image>().sprite;
                    break;
                case "Shield":
                    Shield = child.transform.GetChild(0).GetComponent<Image>().sprite;
                    break;
                case "Accessories1":
                    Accessories = child.transform.GetChild(0).GetComponent<Image>().sprite;
                    break;
                case "Accessories2":
                    Accessories = child.transform.GetChild(0).GetComponent<Image>().sprite;
                    break;
                case "Weapon":
                    Weapon = child.transform.GetChild(0).GetComponent<Image>().sprite;
                    break;
            }
        }

        /*ItemWorld.SpawnItemWorld(new Vector3(-7, -3), new Items { itemType = Items.ItemType.Coin, amount = 1 });*/
    }

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        //Tes Inventory
        /*for (int i = 0; i < 6; i++)
        {
            inventory.AddItem(ItemAsset.AllItem[1]);
        }*/
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            /*StartCoroutine(Wait());*/
            EnemySpawn SpawnControl = collider.GetComponent<EnemySpawn>();
            int randomVar = UnityEngine.Random.Range(1, 10);
            if (randomVar <= enemyProbability)
            {
                Debug.Log("Colider Enemy "+ randomVar);
                BattlePanel.SetActive(true);
                battleControl.RandomEnemy();
                Time.timeScale = 1;
                gameControl.BattleMode = true;
                gameControl.WalkMode = false;
                /*SpawnControl.canBattle = false;*/
            }
        }
        else if (collider.tag == "NPC")
        {
            inRangeNPC = true;
            Debug.Log("NPC: " + inRangeNPC);
        }
        else
        {
            ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
            if (itemWorld != null)
            {
                inventory.AddItem(collider.GetComponent<Items>()/*itemWorld.GetItem()*/);
                Items getItem = itemWorld.GetComponent<Items>();
                GameObject newInfo = Instantiate(infoObj, info.transform);
                newInfo.SetActive(true);
                newInfo.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "You get "+getItem.amount+" x "+getItem.itemName;
                itemWorld.DestroySelf();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "NPC")
        {
            inRangeNPC = false;
            Debug.Log("NPC: " + inRangeNPC);
        }
    }
    private void setAttribute()
    {
        UI_PlayerAttribute newUIPlayerAttribute = UIPlayerAttribute.GetComponent<UI_PlayerAttribute>();
        UIBattle.GetComponent<UI_BattleAttribute>().setAttribute(attribute);
        battleControl.playerAttribute = attribute;
        if (attribute.Exp >= attribute.Maxexp)
        {
            newUIPlayerAttribute.poinValue += 1;
        }
        newUIPlayerAttribute.setAttribute(attribute);
        newUIPlayerAttribute.setImage(gameObject.GetComponent<SpriteRenderer>().sprite);
    }

    public void updatePoin(int poin)
    {
        attribute.PoinUp = poin;
    }
    public void updateAttribute(String name,int poin)
    {
        switch (name)
        {
            case "HP":
                attribute.MaxHP +=  poin * 10;
                break;
            case "MP":
                attribute.MaxMP +=  poin * 10;
                break;
            case "LUCK":
                attribute.Luck +=  poin ;
                break;
            case "DEF":
                attribute.defense +=  poin*5 ;
                break;
            case "P.ATCK":
                attribute.phisicalAttack+=  poin*5 ;
                break;
            case "M.ATCK":
                attribute.magicAttack +=  poin*5 ;
                break;
        }
    }

    public void SellItem(Items item)
    {
        inventory.SellItem(item);
    }

    public void Unequip(Items item)
    {
        
        resetEquip(item.itemAttribute.MaxHP, item.itemAttribute.MaxMP, item.itemAttribute.Defense, item.itemAttribute.M_Attack, item.itemAttribute.P_Attack, item.itemAttribute.Luck);
        item.itemName = null;
        item.amount = 0;
        item.equiped = false;
        item.index = 0;
        item.itemAttribute = null;
        item.level = 0;
    }

    public void EquipItem(Items items,string btn_name,GameObject btn)
    {
        //head
        Image imageHead = playerEquipment.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        TextMeshProUGUI LVHead = playerEquipment.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        Items itemHead = playerEquipment.transform.GetChild(0).GetComponent<Items>();
        //body
        Image imageBody = playerEquipment.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        TextMeshProUGUI LVBody = playerEquipment.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        Items itemBody = playerEquipment.transform.GetChild(1).GetComponent<Items>();
        //hand
        Image imageHand = playerEquipment.transform.GetChild(2).GetChild(0).GetComponent<Image>();
        TextMeshProUGUI LVHand = playerEquipment.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        Items itemhand = playerEquipment.transform.GetChild(2).GetComponent<Items>();
        //foot
        Image imageFoot = playerEquipment.transform.GetChild(3).GetChild(0).GetComponent<Image>();
        TextMeshProUGUI LVFoot = playerEquipment.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        Items itemFoot = playerEquipment.transform.GetChild(3).GetComponent<Items>();
        //shield
        Image imageShield = playerEquipment.transform.GetChild(6).GetChild(0).GetComponent<Image>();
        TextMeshProUGUI LVShield = playerEquipment.transform.GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>();
        Items itemShield = playerEquipment.transform.GetChild(6).GetComponent<Items>();
        //weapon
        Image imageWeapon = playerEquipment.transform.GetChild(7).GetChild(0).GetComponent<Image>();
        TextMeshProUGUI LVWeapon = playerEquipment.transform.GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>();
        Items itemWeapon = playerEquipment.transform.GetChild(7).GetComponent<Items>();
        //Accessories1
        Image imageAccessories1 = playerEquipment.transform.GetChild(4).GetChild(0).GetComponent<Image>();
        TextMeshProUGUI LVAccessories1 = playerEquipment.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
        Items itemAccessories1 = playerEquipment.transform.GetChild(4).GetComponent<Items>();
        //Accessories2
        Image imageAccessories2 = playerEquipment.transform.GetChild(5).GetChild(0).GetComponent<Image>();
        TextMeshProUGUI LVAccessories2 = playerEquipment.transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>();
        Items itemAccessories2 = playerEquipment.transform.GetChild(5).GetComponent<Items>();

        if (btn_name == "Unequip")
        {
            switch (items.itemType)
            {
                case Items.ItemType.HeadArmor:
                    imageHead.sprite = Head;
                    imageHead.color = Color.black;
                    Unequip(itemHead);
                    LVHead.gameObject.SetActive(false);
                    break;
                case Items.ItemType.BodyArmor:
                    imageBody.sprite = Body;
                    imageBody.color = Color.black;
                    Unequip(itemBody);
                    LVBody.gameObject.SetActive(false);
                    break;
                case Items.ItemType.HandArmor:
                    imageHand.sprite = Hand;
                    imageHand.color = Color.black;
                    Unequip(itemhand);
                    LVHand.gameObject.SetActive(false);
                    break;
                case Items.ItemType.FootArmor:
                    imageFoot.sprite = Foot;
                    imageFoot.color = Color.black;
                    Unequip(itemFoot);
                    LVFoot.gameObject.SetActive(false);
                    break;
                case Items.ItemType.Shield:
                    imageShield.sprite = Shield;
                    imageShield.color = Color.black;
                    Unequip(itemShield);
                    LVShield.gameObject.SetActive(false);
                    break;
                case Items.ItemType.Weapon:
                    imageWeapon.sprite = Weapon;
                    imageWeapon.color = Color.black;
                    Unequip(itemWeapon);
                    LVWeapon.gameObject.SetActive(false);
                    break;
                case Items.ItemType.Accessories:
                    if(btn.tag == "Accessories1")
                    {
                        imageAccessories1.sprite = Accessories;
                        imageAccessories1.color = Color.black;
                        Unequip(itemAccessories1);
                        LVAccessories1.gameObject.SetActive(false);
                    }
                    else
                    {
                        imageAccessories2.sprite = Accessories;
                        imageAccessories2.color = Color.black;
                        Unequip(itemAccessories2);
                        LVAccessories2.gameObject.SetActive(false);
                    }
                    
                    break;
            }
        }
        else
        {
            equipped = false;
        }
        if(items.itemType != Items.ItemType.UseItem)
        {
            inventory.EquipItem(items);
        }
        else
        {
            if(items.itemName == "Health Potion")
            {
                attribute.HP += 50;
                inventory.useItem(items);
            }
            else
            {
                attribute.MP += 50;
                foreach (Items temp in inventory.itemList)
                {
                    if (temp.itemName == items.itemName)
                    {
                        temp.amount -= 1;
                    }
                }
            }
        }
        
    }
   
    public void resetEquip(int maxHP, int maxMP, int def, int MAtck, int PAtck, int luck)
    {
        attribute.MaxHP -= maxHP;
        attribute.MaxMP -= maxMP;
        attribute.defense -= def;
        attribute.magicAttack -= MAtck;
        attribute.phisicalAttack -= PAtck;
        attribute.Luck -= luck;
    }
    public void changeEquip(int maxHP, int maxMP, int def, int MAtck, int PAtck, int luck)
    {
        attribute.MaxHP += maxHP;
        attribute.MaxMP += maxMP;
        attribute.defense += def;
        attribute.magicAttack += MAtck;
        attribute.phisicalAttack += PAtck;
        attribute.Luck += luck;
    }
    public void getDamage(int damage)
    {
        if (attribute.HP > 0)
        {
            attribute.HP -= damage;
            UIBattle.GetComponent<UI_BattleAttribute>().setAttribute(attribute);
        }
    }
    public void useSkill(int MPCost)
    {
        attribute.MP -= MPCost;
    }
    public void getExp(int exp)
    {
        if (attribute.Exp < attribute.Maxexp)
        {
            attribute.Exp += exp;
        }
    }
    public void getItem(Items newItem)
    {
        inventory.AddItem(newItem);
    }

    public void cekQuest(string enemyName)
    {
        Debug.Log("Kill "+enemyName);
        NPC_obj.GetComponent<NPC>().UpdateQuest(enemyName);
    }

    public void refreshInventory(Inventory inventory)
    {

    }
    public void OpenPlayerPanel (char key , bool openPanel)
    {
        switch (openPanel)
        {
            case true:
                
                switch (key)
                {
                    case 'I':
                        quest.SetActive(false);
                        equipment.SetActive(false);
                        openInventory.SetActive(true);
                        shop.SetActive(false);
                        gameControl.ShopMode = false;
                        gameControl.ItemMode = true;
                        break;
                    case 'Q':
                        openInventory.SetActive(false);
                        inventoryDetail.SetActive(false);
                        equipment.SetActive(false);
                        quest.SetActive(true);
                        shop.SetActive(false);
                        gameControl.ItemMode = true;
                        break;
                    case 'E':
                        openInventory.SetActive(false);
                        inventoryDetail.SetActive(false);
                        quest.SetActive(false);
                        equipment.SetActive(true);
                        shop.SetActive(false);
                        gameControl.ItemMode = true;
                        gameControl.ShopMode = false;
                        break;
                    case 'B':
                        openInventory.SetActive(false);
                        inventoryDetail.SetActive(false);
                        quest.SetActive(false);
                        playerpanel.SetActive(false);
                        equipment.SetActive(false);
                        shop.SetActive(true);
                        gameControl.ShopMode = true;
                        break;
                    case 'X':
                        inventoryDetail.SetActive(false);
                        gameControl.WalkMode = true;
                        gameControl.ItemMode =false;
                        gameControl.ShopMode = false;

                        openInventory.SetActive(false);
                        shop.SetActive(false);
                        quest.SetActive(false);
                        equipment.SetActive(false);
                        playerpanel.SetActive(false);
                        Time.timeScale = 1;
                        break;
                }
                break;
            case false:
                Time.timeScale = 0;
                gameControl.WalkMode = false;
                if (gameControl.BattleMode == false)
                {
                    switch (key)
                    {
                        case 'I':
                            openInventory.SetActive(true);
                            playerpanel.SetActive(true);
                            gameControl.ItemMode = true;
                            break;
                        case 'Q':
                            quest.SetActive(true);
                            inventoryDetail.SetActive(false);
                            playerpanel.SetActive(true);
                            gameControl.ItemMode = true;
                            break;
                        case 'E':
                            equipment.SetActive(true);
                            inventoryDetail.SetActive(false);
                            playerpanel.SetActive(true);
                            gameControl.ItemMode = true;
                            break;
                        case 'B':
                            shop.SetActive(true);
                            inventoryDetail.SetActive(false);
                            gameControl.ShopMode= true;
                            break;
                        case 'X':
                            inventoryDetail.SetActive(false);
                            if (pausePanel.activeInHierarchy==true)
                            {
                                pausePanel.SetActive(false);
                                Time.timeScale = 1;
                                gameControl.WalkMode = true;
                                gameControl.PauseMode = false;
                            }
                            else
                            {
                                pausePanel.SetActive(true);
                                gameControl.PauseMode = true;
                            }
                            
                            break;
                    }
                }
                else
                {
                    
                }
                break;
        }
                    
    }

   public void playermenu(Button button)
    {
        switch (button.name)
        {
            case "InventoryButton":
                OpenPlayerPanel('I', playerpanel.activeInHierarchy);
                break;
            case "AttributeButton":
                OpenPlayerPanel('E', playerpanel.activeInHierarchy);
                break;
            case "QuestButton":
                OpenPlayerPanel('Q', playerpanel.activeInHierarchy);
                break;
        }
    }

    void Update()
    {
        if (attribute.HP <= 0)
        {
            SceneManager.LoadScene(2);
        }
        setAttribute();
        if (Time.timeScale == 1)
        {
            gameControl.WalkMode = true;
            myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        
            myAnim.SetFloat("moveX", myRB.velocity.x);
            myAnim.SetFloat("moveY", myRB.velocity.y);

            if ( Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                myAnim.SetFloat("lastMoveX" , Input.GetAxisRaw("Horizontal"));
                myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }

            
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            OpenPlayerPanel('I', playerpanel.activeInHierarchy);
        }
        else if (Input.GetKeyUp(KeyCode.Q) )
        {
            OpenPlayerPanel('Q', playerpanel.activeInHierarchy);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            OpenPlayerPanel('E', playerpanel.activeInHierarchy);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            OpenPlayerPanel('X', playerpanel.activeInHierarchy);
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            OpenPlayerPanel('B', playerpanel.activeInHierarchy);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && inRangeNPC == true)
        {
            NPC_obj.GetComponent<NPC>().Interact();
            Debug.Log("Get Quest");

        }


    } 
}

