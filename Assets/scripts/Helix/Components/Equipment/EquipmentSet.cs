using System;
using System.Collections.Generic;

namespace Helix.Components.Equipment
{
    public class EquipmentSet
    {
        protected Dictionary<EQUIPMENT_CATEGORY_IDENTIFIER, EquipmentCategory> _currentEquipment = new Dictionary<EQUIPMENT_CATEGORY_IDENTIFIER, EquipmentCategory>();

        public EquipmentSet()
        {
            
        }

        public void Equip(Item item)
        {
            EQUIPMENT_CATEGORY_IDENTIFIER category = item.equipment_category;
            if (this._currentEquipment.ContainsKey(category))
            {
                EquipmentCategory current_cat_eq = this._currentEquipment[category];
                bool equipped = current_cat_eq.Equip(item);
            }
            else
            {
                EquipmentCategory new_cat_eq = new RightHandedCategory(); //To make this category
                bool equipped = new_cat_eq.Equip(item);
                this._currentEquipment.Add(category, new_cat_eq);
            }
        }

        public void UnEquip(Item item)
        {
            EQUIPMENT_CATEGORY_IDENTIFIER category = item.equipment_category;
            EquipmentCategory current_cat_eq = this._currentEquipment[category];
            bool equipped = current_cat_eq.UnEquip(item);
        }

        public float GetProperty(EQUIPMENTSTATS eqstat)
        {
            float value = 0;
            foreach (var kvp in this._currentEquipment)
            {
                value += kvp.Value.GetProperty(eqstat);
            }
            return value;
        }

        public Dictionary<EQUIPMENTSTATS, float> GetStats()
        {
            var stats = new Dictionary<EQUIPMENTSTATS, float>();

            //Run through all categories and sum their stats
            foreach (KeyValuePair<EQUIPMENT_CATEGORY_IDENTIFIER, EquipmentCategory> equipment_category in this._currentEquipment)
            {
                stats = Item.AddProperties(stats, equipment_category.Value.GetStats());
            }

            return stats;
        }
    }
}

