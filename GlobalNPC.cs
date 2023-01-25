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
	public class GNPC : GlobalNPC {
		public override void SetDefaults(NPC npc) {
			npc.lifeMax = (int)(Math.Sqrt(npc.lifeMax) * 10 * (npc.boss ? 2 : 1));
			npc.value = (int)(Math.Sqrt(npc.value) * 10 * (npc.boss ? 2 : 1));
			npc.life = npc.lifeMax;
		}

		public override void OnHitNPC (NPC npc, NPC target, int damage, float knockback, bool crit) {
			target.immune[255] = (int)Math.Max(target.immune[255] / 2, 1);
		}
		
		public override void OnHitPlayer (NPC npc, Player target, int damage, bool crit) {
			target.immuneTime = (int)Math.Max(target.immuneTime / 2, 1);
		}
		
		public override void UpdateLifeRegen (NPC npc, ref int damage) {
			if (npc.lifeRegen > 0) { npc.lifeRegen /= 4; }
			if (npc.lifeRegen < 0) { npc.lifeRegen *= 2; }
		}
	}
}