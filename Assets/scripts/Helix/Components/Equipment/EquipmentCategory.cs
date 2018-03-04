using System;
using System.Collections.Generic;

/// <summary>
/// Equipment category is an abstraction that allows us to limit number of simultaneously wielded equipment by categorizations.
/// An example would be that any operator can only wear one headdress at one time.
/// </summary>
namespace Helix.Components.Equipment
{
    public abstract class EquipmentCategory
    {
        public EQUIPMENT_CATEGORY_IDENTIFIER identifier;
        //Specifies the name of the category that is the current identifier

        public int max_slots;
        //Stores the max number of slots allowed in this category

        private List<Item> _equipped = new List<Item>();

        public EquipmentCategory(EQUIPMENT_CATEGORY_IDENTIFIER identifier, int max_slots)
        {
            this.identifier = identifier;
            this.max_slots = max_slots;
        }

        public bool Equip(Item item)
        {
            if (this._equipped.Count >= this.max_slots)
            {
                return false;
            }
            this._equipped.Add(item);
            return true;
        }

        public bool UnEquip(Item item)
        {
            this._equipped.Remove(item);
            return true;
        }

        public Dictionary<EQUIPMENTSTATS, float> GetStats()
        {
            var output = new Dictionary<EQUIPMENTSTATS, float>();
            foreach (var item in this._equipped)
            {
                output = Item.AddProperties(output, item.GetProperties());
            }

            return output;
        }

        public float GetProperty(EQUIPMENTSTATS eqstat)
        {
            float val = 0;
            foreach (var item in this._equipped)
            {
                val += item.GetProperty(eqstat); //Using simple summation for now. Can improve in the future to support multiplicative damage
            }
            return val;
        }
    }
}

