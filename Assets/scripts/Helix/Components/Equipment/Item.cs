using System;
using System.Collections.Generic;
using Helix.Components.Equipment;

/// <summary>
/// This class contains the definition for any piece of equipment that has stats
/// </summary>
namespace Helix.Components.Equipment
{
    public abstract class Item
    {
        public string name = "";
        public string description = "";
        private Dictionary<EQUIPMENTSTATS, float> _properties;

        public EQUIPMENT_CATEGORY_IDENTIFIER equipment_category;

        public Item(string name, string description, Dictionary<EQUIPMENTSTATS, float> properties, EQUIPMENT_CATEGORY_IDENTIFIER equipment_category)
        {
            this.name = name;
            this.description = description;
            this.equipment_category = equipment_category;
            this._properties = properties;
        }

        public float GetProperty(EQUIPMENTSTATS eqstat)
        {
            if (this._properties.ContainsKey(eqstat))
            {
                return this._properties[eqstat];
            }
            return -1; //This might need to be rewritten. Multiplicative functions would expect this to return 1, while additive functions would expect 0. Current checking is offloaded to the caller of this class. -1 may be incorrectly regarded as an incorrect input.
        }

        public Dictionary<EQUIPMENTSTATS, float> GetProperties()
        {
            return this._properties;
        }

        public static Dictionary<EQUIPMENTSTATS, float> AddProperties(Dictionary<EQUIPMENTSTATS, float> s1, Dictionary<EQUIPMENTSTATS, float> s2)
        {
            foreach (var stat in s2)
            {
                if (s1.ContainsKey(stat.Key))
                {
                    s1[stat.Key] += stat.Value; //Add the value to the output for that stat
                }
                else
                {
                    s1.Add(stat.Key, stat.Value); //Insert the item into the output dictionary array
                }
            }
            return s1;
        }

        public static Dictionary<EQUIPMENTSTATS, float> AddStats(Item item1, Item item2)
        {
            return Item.AddProperties(item1._properties, item2._properties);
        }
    }
}

