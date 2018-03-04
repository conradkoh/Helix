using System;
using System.Collections.Generic;

namespace Helix.Components.Equipment
{
    public class TestItem1 : Item
    {
        public TestItem1(Dictionary<EQUIPMENTSTATS, float> test_item_properties)
            : base("TEST ITEM 1", "TEST ITEM 1", test_item_properties, EQUIPMENT_CATEGORY_IDENTIFIER.WEAPON_RIGHTHAND)
        {
            var x = 1;
        }
    }
}

