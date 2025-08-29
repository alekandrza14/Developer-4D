using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class ElementalInventory : MonoBehaviour {

    //Cell massive
    public Cell[] Cells;
    //Max element stack
    public int maxStack;
    public GameObject elementPrefab;
    private Transform choosenItem;
    public string[] nunamesA;
    public static string[] itemtags;
    public static string[] itemnames;
    public int select = 0;
    public Cell activeItem;
    public bool planets;
    bool sh;
    public bool deletecell;
    public bool nosell;
    public bool nomainiventory;
    static ElementalInventory ei;
    public static ElementalInventory main()
    {
       if(ei==null) ei = FindFirstObjectByType<ElementalInventory>();
        return ei;
    }
    public GameObject inv2(string name)
    {
        GameObject g1 = Resources.Load<GameObject>("death_point");
        for (int i = 0; i < nunamesA.Length; i++)
        {
            if (i < nunamesA.Length)
            {


                if (nunamesA[i] != name)
                {
                    g1 = Resources.Load<GameObject>("items/" + name);
                    i = nunamesA.Length;



                }
            }
            if (i < nunamesA.Length)
            {
                if (nunamesA[i] == name)
                {


                    g1 = Resources.Load<GameObject>("itms/room" + SceneManager.GetActiveScene().buildIndex + "/" + name);
                    i = nunamesA.Length;
                }
            }


        }
        if (nunamesA.Length == 0)
        {

            for (int i = 0; i < itemnames.Length; i++)
            {
                if (i < itemnames.Length)
                {


                    if (itemnames[i] != name)
                    {


                        g1 = Resources.Load<GameObject>("items/" + name);

                    }
                }
                if (i < itemnames.Length)
                {



                    g1 = Resources.Load<GameObject>("items/" + name);


                }

            }
        }


        int t = 0;
        for (int i = name.Length - 1; i > 0; i--)
        {
            if (name[i] == 'x')
            {
                t++;
            }
            if (name[i] != 'x' && t != 0)
            {
                string namet = name.Remove((name.Length) - t);
                Debug.Log(namet);
                if (true)
                {


                    GameObject p = Resources.Load<GameObject>("items/" + namet);
                    if (p)
                    {

                        if (true)
                        {


                            g1 = p;
                        }
                    }
                }
                i = 0;


            }

        }

        if (true)
        {


            GameObject p = Resources.Load<GameObject>("death_point");
            p = Resources.Load<GameObject>("items/" + name);


        }






        t = 0;
        return g1;
    }
    GameObject elementrandom()
    {
        GameObject g = Resources.Load<GameObject>("items/Ti");
        int i = Random.Range(0, 7);
        if (i == 0)
        {
            g = Resources.Load<GameObject>("items/Ti");
        }
        else if (i == 1)
        {
            g = Resources.Load<GameObject>("items/He");
        }
        else if (i == 2)
        {
            g = Resources.Load<GameObject>("items/Fr");
        }
        else if (i == 3)
        {
            g = Resources.Load<GameObject>("items/C");
        }
        else if (i == 4)
        {
            g = Resources.Load<GameObject>("items/Cr");
        }
        else if (i == 5)
        {
            g = Resources.Load<GameObject>("items/Au");
        }
        else if (i == 6)
        {
            g = Resources.Load<GameObject>("items/U");
        }
        return g;

    }
    public string toname(string name)
    {

        int s = 0;


        for (int i2 = 0; i2 < itemtags.Length; i2++)
        {

            if (itemtags[i2] == name)
            {
                s = i2;
            }




        }
        return itemnames[s];

    }
    public bool tag1(string name)
    {

        bool s2 = false;


        for (int i2 = 0; i2 < itemtags.Length; i2++)
        {

            if (itemtags[i2] == name)
            {
                s2 = true;
            }





        }
        return s2;

    }
    public string fullname(RaycastHit h)
    {
        string s = "";
        string s1 = "";
        int x = 0;

        //(clone)
        if (h.collider.name[h.collider.name.Length - 1] == ')')
        {
            s1 = h.collider.name.Remove(h.collider.name.Length - 7);
        }
        s += s1;



        Destroy(h.collider.gameObject);




        return s;
    }
    public bool tag2(GameObject name)
    {

        bool s2 = true;




        if ("enemies" == LayerMask.LayerToName(name.layer))
        {
            s2 = false;
        }






        return s2;

    }
    public string nameItem(string name)
    {

        bool s2 = true;
        string rawname1 = name.Replace(" ", "_");

        string fullname = "";
        int t = 0;
        for (int i = rawname1.Length - 1; i > 0; i--)
        {
            if (rawname1[i] == 'x')
            {
                t++;
            }
            if (rawname1[i] != 'x' && t != 0)
            {
                fullname = rawname1.Remove((rawname1.Length) - t);

                if (true)
                {



                }
                i = 0;


            }
            if (rawname1[i] != 'x' && t == 0)
            {
                fullname = rawname1;

                if (true)
                {



                }
                i = 0;


            }

        }






        return fullname;

    }
    public void getallitems()
    {
        getallitemsroom();
        GameObject[] g = complsave.t3;

        itemnames = new string[g.Length];
        itemtags = new string[g.Length];
        for (int i = 0; i < g.Length; i++)
        {
            itemnames[i] = g[i].name;
            itemtags[i] = g[i].tag;

        }



    }
    public void getallitemsroom()
    {
        GameObject[] g = Resources.LoadAll<GameObject>("itms/room" + SceneManager.GetActiveScene().buildIndex);
        nunamesA = new string[g.Length];
        for (int i = 0; i < nunamesA.Length; i++)
        {
            nunamesA[i] = g[i].name;

        }
    }

    public bool contains(string name, int count, Color color) {
        int inventoryCount = 0;
        for (int i = 0; i < Cells.Length; i++) {
            if (Cells[i].elementCount != 0 && Cells[i].elementName == name && Cells[i].elementColor == color) {
                inventoryCount += Cells[i].elementCount;
            }
        }
        if (count <= inventoryCount) {
            return true;
        } else {
            return false;
        }
    }
    public int LayItem()
    {
        int i = 0;
        int i2 = 0;

        if (activeItem)
        {
            foreach (Cell cell in Cells)
            {
                if (cell.name == activeItem.name)
                {
                    i2 = i;
                }
                if (activeItem)
                {
                    if (cell.name != activeItem.name)
                    {
                        i++;
                    }
                }
            }
        }
        if (!activeItem)
        {
            i2 = 1;

        }

        return i2;
    }
    void UseItem()
    {
        RaycastHit hit = MainRay.MainHit;
        fristPersonControler player = fristPersonControler.main();
        Vector3 gun = player.transform.forward * 5;
        itemName hititem = hit.collider.GetComponent<itemName>();
        if (Input.GetKey(KeyCode.E))
        {
            if (Globalprefs.item == "FlyMetla" && Globalprefs.count != 0)
            {
                player.transform.position += player.g[1].transform.forward * 5;
            }
        }
           
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Globalprefs.item == "MagicStick(sample)" && Globalprefs.count != 0)
            {
                Instantiate(Resources.Load<GameObject>("effect/fireball"), player.transform.position + gun + Vector3.up, player.g[1].transform.rotation);
            }
            if (Globalprefs.item == "Medic" && Globalprefs.count != 0)
            {
                
                Globalprefs.uncount += 1;
            }
            if (Globalprefs.item == "MagicStick(Gas)" && Globalprefs.count != 0)
            {
                Instantiate(Resources.Load<GameObject>("effect/FireGas"), player.transform.position + gun + Vector3.up, player.g[1].transform.rotation);
            }
            if (Globalprefs.item == "MagicStick(MetaBubble)" && Globalprefs.count != 0)
            {
                Instantiate(Resources.Load<GameObject>("effect/MetaBubble"), player.transform.position + gun + Vector3.up, player.g[1].transform.rotation);
            }
            if (Globalprefs.item == "MagicStick(InfectionBubble)" && Globalprefs.count != 0)
            {
                Instantiate(Resources.Load<GameObject>("effect/InfectionBubble"), player.transform.position + gun + Vector3.up, player.g[1].transform.rotation);
            }
            if (Globalprefs.item == "MagicStick(AlphaBall)" && Globalprefs.count != 0)
            {
                Instantiate(Resources.Load<GameObject>("effect/AlphaBall"), player.transform.position + gun + Vector3.up, player.g[1].transform.rotation);
            }
            if (Globalprefs.item == "MagicStick(staticpublicBall)" && Globalprefs.count != 0)
            {
                Instantiate(Resources.Load<GameObject>("effect/staticpublicBall"), player.transform.position + gun + Vector3.up, player.g[1].transform.rotation);
            }
            if (Globalprefs.item == "MagicSlingshot(bird)" && Globalprefs.count != 0)
            {
                Instantiate(Resources.Load<GameObject>("effect/AngryBird"), player.transform.position + gun + Vector3.up, player.g[1].transform.rotation);
            }
            if (Globalprefs.item == "MagicStick(Block)" && Globalprefs.count != 0)
            {
                Instantiate(Resources.Load<GameObject>("effect/sampleBlock"), player.transform.position + gun + Vector3.up, player.g[1].transform.rotation);
            }
          
            if (Globalprefs.item == "LifeStone" && Globalprefs.count != 0)
            {
              if(hititem!=null)  if (hititem._Name == "Greave") 
                {
                    if (!string.IsNullOrEmpty(hititem.ItemData)) Instantiate(Resources.Load<GameObject>("items/" + hititem.ItemData), hititem.transform.position, hititem.transform.rotation);
                    if (string.IsNullOrEmpty(hititem.ItemData)) Instantiate(Resources.Load<GameObject>("items/coin"), hititem.transform.position, hititem.transform.rotation);
                    hititem.gameObject.AddComponent<deleter1>();
                    Globalprefs.uncount += 1;
                }
            }
        }
    }
    private void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                SelectLayItem();
            }
            if (i == 1)
            {
                DeselectLayItem();
            }
        }
        select = LayItem();
        Globalprefs.item = Cells[select].elementName;
        if (Globalprefs.uncount!=0)
        {
            Cells[select].elementCount -= Globalprefs.uncount; Globalprefs.uncount = 0;
            Cells[select].UpdateCellInterface();
        }
        Globalprefs.count = Cells[select].elementCount; UseItem();
        if (Input.GetKeyDown(KeyCode.Tab) && !nosell)
        {



            Globalprefs.selectitem = "";
            RaycastHit hit = MainRay.MainHit;
            bool item = Cells[select].elementCount == 0 || hit.collider.name.Replace("(Clone)", "") == Cells[select].elementName;
            if (hit.collider && item && tag2(hit.collider.gameObject) && hit.collider.GetComponent<itemName>())
            {

                if (!VarSave.ExistenceVar("researchs/" + fullname(hit)))
                {
                    Directory.CreateDirectory("unsave/var/researchs");


                    VarSave.LoadMoney("research", 1);

                    Globalprefs.research = VarSave.GetMoney("research");
                    VarSave.SetInt("researchs/" + fullname(hit), 0);

                }

                setItem(fullname(hit), 1+ Cells[select].elementCount, Color.red, hit.collider.GetComponent<itemName>().ItemData, select);
                Cells[select].UpdateCellInterface();
                sh = true;

            }
        }

       if (Cells[select].elementCount != 0) euclideanray();
        sh = false;
    }
    public IEnumerator seteuclideanitem(RaycastHit hit)
    {


        yield return new WaitForSeconds(0.5f);

       
        if (hit.collider && Cells[select].elementCount >= 1)
        {

            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem(Cells[select].elementName, Cells[select].elementCount-1, Color.red, select);
            Cells[select].UpdateCellInterface();

        }







    }
    float mouseDoubele;
    float mouseDoubele2;
    private void euclideanray()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !sh && !nosell)
        {
            Globalprefs.selectitem = "";
            RaycastHit hit = MainRay.MainHit;


            StartCoroutine(seteuclideanitem(hit));




        }
    }

    public itemName it;
    public void SelectLayItem()
    {
        if (it == null)
        {


            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<itemName>()  && !nosell)
                {


                    for (int i = 0; i < hit.collider.gameObject.name.Length - 7; i++)
                    {


                        if (hit.collider.gameObject.name[i] != '_')
                        {
                            Globalprefs.ItemPrise = (decimal)hit.collider.GetComponent<itemName>().ItemPrise;
                            Globalprefs.selectitemobj = hit.collider.GetComponent<itemName>();


                            Globalprefs.selectitem += hit.collider.gameObject.name[i];

                        }
                        if (hit.collider.gameObject.name[i] == '_')
                        {

                            Globalprefs.ItemPrise = 0;

                            Globalprefs.selectitemobj = null;
                            Globalprefs.selectitem += " ";

                        }


                    }

                    it = hit.collider.GetComponent<itemName>();
                }
            }
        }
      
        
    }
    public void DeselectLayItem()
    {
        if (it != null)
        {
            RaycastHit hit = MainRay.MainHit;
            if (!hit.collider.GetComponent<itemName>() && !nosell)
            {


                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                it = null;
            }

         

        }
       




    }
    public void setItemLink(string name, int count, Color color, string data, Transform cell)
    {
        Cell thisCell = cell.GetComponent<Cell>();
        thisCell.elementName = name;
        thisCell.elementCount = count;
        thisCell.elementColor = color;
        thisCell.elementData = data;
    }

    public Cell GetCell(string name, int count)
    {
        Cell solution = null;

        for (int i =0;i< Cells.Length;i++)
        {
            Cell c = Cells[i];
            if (c.elementName == name)
            {
                if (c.elementCount > count)
                {
                    return solution = Cells[i];
                }
            }
        }
        return solution;
    }
    //Set item from link
    public void setItemLink (string name, int count, Color color, Transform cell) {
		Cell thisCell = cell.GetComponent<Cell> ();
		thisCell.elementName = name;
		thisCell.elementCount = count;
		thisCell.elementColor = color;
	}
    
    
    //Moves item
    public void moveItem(int moveFrom, int moveTo)
    {
        foreach (string onlyitem in Cells[moveTo].elementList) {
            if (Cells[moveFrom].elementName==onlyitem)
            {
                rawMoveItem(moveFrom, moveTo);
            }
        }
        if (Cells[moveTo].elementList.Length==0)
        {
            rawMoveItem(moveFrom, moveTo);
        }
    }

    private void rawMoveItem(int moveFrom, int moveTo)
    {
        setItem(Cells[moveFrom].elementName, Cells[moveFrom].elementCount, Cells[moveFrom].elementColor, Cells[moveFrom].elementData, moveTo);
        setItem("", 0, new Color(), moveFrom);
    }

    //Moves item with link
    //First - element, second - cell

    public void moveItemLink(Transform moveFrom, Transform moveTo)
    {
        if (moveFrom != null && moveTo != null)
        {
            Cell moveFromCell = moveFrom.parent.GetComponent<Cell>();
            Cell moveToCell = moveTo.GetComponent<Cell>();
          if(moveToCell && moveFromCell)  foreach (string onlyitem in moveToCell.elementList)
            {
                if (moveFromCell.elementName == onlyitem)
                {
                    rawMoveItemLink(moveFrom, moveTo);
                }
            }
            if (moveToCell) if (moveToCell.elementList.Length == 0)
            {
                rawMoveItemLink(moveFrom, moveTo);
                }
                else if(!moveToCell)
                {
                    rawMoveItemLink(moveFrom, moveTo);
                }
           
        }
    }

    private void rawMoveItemLink(Transform moveFrom, Transform moveTo)
    {
      
            Cell moveFromCell = moveFrom.parent.GetComponent<Cell>();
            moveTo.GetComponent<Cell>().elementTransform = moveFromCell.elementTransform;
            moveFromCell.elementTransform = null;
            setItemLink(moveFromCell.elementName, moveFromCell.elementCount, moveFromCell.elementColor, moveFromCell.elementData, moveTo);
            moveFromCell.elementCount = 0;
            moveFrom.parent = moveTo;
            moveFrom.localPosition = new Vector3(0, 0, 0);
       
    }

    public void moveItemLinkFirst(Transform t)
    {

      


            choosenItem = t;
       
    }

    public void moveItemLinkSecond(Transform t)
    {
       
            moveItemLink(choosenItem, t);
            choosenItem = null;
        
    }

    //Sets item
    public void setItem(string name, int count, Color color, int cellId)
    {
        Cells[cellId].ChangeElement(name, count, color);
        Cells[cellId].UpdateCellInterface();

    }
    public void setItem(string name, int count, Color color, string data, int cellId)
    {
        Cells[cellId].ChangeElement(name, count, color, data);
        Cells[cellId].UpdateCellInterface();

    }



    //Sets item


    public void loadFromString(string s_Inventory)
    {
        string[] splitedInventory = s_Inventory.Split("\n"[0]);
        for (int i = 0; i < Cells.Length; i++)
        {
            string[] splitedLine = splitedInventory[i].Split(" "[0]);
            setItem(splitedLine[0], int.Parse(splitedLine[1]), SimpleMethods.stringToColor(splitedLine[2]), splitedLine[3], i);
        }
    }

    //Returns inventory as string
    public string convertToString()
    {
        string s_Inventory = "";
        for (int i = 0; i < Cells.Length; i++)
        {
            s_Inventory += Cells[i].elementName + " ";
            s_Inventory += Cells[i].elementCount + " ";
            s_Inventory += SimpleMethods.colorToString(Cells[i].elementColor) + " ";
            s_Inventory += Cells[i].elementData;
            if (i != Cells.Length)
            {
                s_Inventory += "\n";
            }
        }
        return s_Inventory;
    }

    //Clear inventory
    public void clear () {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount != 0) {
				Cells [i].elementCount = 0;
				Cells [i].UpdateCellInterface ();
			}
		}
	}

	//Add element to inventory
	public void addItem (string name, int count, Color color) {
		int cellId = getEquals (name, color);
		if (cellId != -1) {
			Cells [cellId].elementCount = count;
		} else {
			cellId = getFirst ();
			if (cellId == -1) {
				return;
			}
			Cells [cellId].elementCount += count;
		}
		//Set up element count
		if (Cells [cellId].elementCount > maxStack) {
			int remain = Cells [cellId].elementCount - maxStack;
			Cells [cellId].elementCount = maxStack;
			addItem (name, remain, color);
		} else {
			Cells [cellId].elementCount = count;
		}
		Cells [cellId].elementName = name;
		Cells [cellId].elementColor = color;
		Cells [cellId].UpdateCellInterface ();
	}

	//Returns id of first clear cell
	public int getFirst () {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount == 0) {
				
				return i;
			}
		}
		return -1;
	}

	//Returns id of first same element cell
	public int getEquals (string name, Color color) {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount != 0 && Cells [i].elementCount <= maxStack && Cells [i].elementName == name && Cells [i].elementColor == color) {
				return i;
			}
		}
		return -1;
	}

}
