using UnityEngine;
using System.Collections;

public class RandomItem : MonoBehaviour {

	private ElementalInventory inventory;
	public GameObject interFace;
//	public bool open;
    private void Start()
    {
        if (inventory == null)
        {
            inventory = FindAnyObjectByType(typeof(ElementalInventory)) as ElementalInventory;
			inventory.loadFromString(VarSave.GetString("EInventory"));
            //    inventory.gameObject.SetActive(false);
        }
    }
    void Update () {
		if (inventory == null) {
			inventory = FindAnyObjectByType (typeof(ElementalInventory)) as ElementalInventory;
		}
	//	if (Input.GetKeyDown (KeyCode.Tab)) {
		//	inventory.addItem (SimpleMethods.randomElement(), Random.Range(1, inventory.maxStack), new Color(Random.value/2f, Random.value/2f, Random.value/2f, 1f));
	//	}


		if (Input.GetKeyDown(KeyCode.F1))
		{
			VarSave.SetString("EInventory", inventory.convertToString());
		}

			if (Input.GetKeyDown (KeyCode.F2))
		{
			inventory.loadFromString (VarSave.GetString("EInventory"));
		}
      //  if (Input.GetKeyDown(KeyCode.Tab))
      //  {
      //      interFace.gameObject.SetActive (!interFace.activeSelf);
      // 	}

        //if (Input.GetKeyDown(KeyCode.Tab)) open = !open;
        //    if (!open) {
        //	inventory.gameObject.SetActive (false);
        //	}
        //	if (open) {
        //		inventory.gameObject.SetActive (true);
        //	}
    }

}
