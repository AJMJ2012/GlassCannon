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

namespace GlassCannon {
	public class MPlayer : ModPlayer {
		public override void PostUpdate() {
			Player.statLifeMax2 = (int)(Player.statLifeMax2 / 5) + 20;
			if (Player.statLife > Player.statLifeMax2) { Player.statLife = Player.statLifeMax2; }
			Player.statManaMax2 = (int)(Player.statManaMax2 / 2);
			if (Player.statMana > Player.statManaMax2) { Player.statMana = Player.statManaMax2; }
		}
		
		public override void UpdateLifeRegen () {
			if (Player.lifeRegen > 0) { Player.lifeRegen /= 4; }
			if (Player.lifeRegen < 0) { Player.lifeRegen *= 2; }
		}
		
		public override void OnHitNPC (Item item, NPC target, int damage, float knockback, bool crit) {
			target.immune[Player.whoAmI] = (int)Math.Max(target.immune[Player.whoAmI] / 2, 1);
		}
		
		public override void OnHitPvp (Item item, Player target, int damage, bool crit) {
			target.immuneTime = (int)Math.Max(target.immuneTime / 2, 1);
		}
	}
}