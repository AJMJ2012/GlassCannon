using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria;
using System.Text.RegularExpressions;

namespace GlassCannon {
	public class GItem : GlobalItem {
		public override void SetDefaults(Item item) {
			if (item.type == ItemID.Heart || item.type == ItemID.CandyApple || item.type == ItemID.CandyCane || item.type == ItemID.Star || item.type == ItemID.SoulCake || item.type == ItemID.SugarPlum) {
				item.SetDefaults(0, false);
			}
			if (item.healLife > 0) { item.healLife = (int)Math.Max(item.healLife / 5, 1); }
			if (item.healMana > 0) { item.healMana = (int)Math.Max(item.healMana / 2, 1); }
		}
	}
}
