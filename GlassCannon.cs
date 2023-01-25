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
	public class GlassCannon : Mod {
		public override void Unload() {
			Item.potionDelay = 3600;
			Item.restorationDelay = 3000;
			Player.manaSickTime = 300;
			Player.manaSickTimeMax = 900;
		}
		
		public override void Load() {
			On.Terraria.NPC.ScaleStats += (ScaleStats, npc, activePlayersCount, gameModeData, strengthOverride) => { return; };
			On.Terraria.Main.DamageVar += (DamageVar, dmg, luck) => { return (int)dmg; };
			On.Terraria.Main.CalculateDamageNPCsTake += (CalculateDamageNPCsTake, Damage, Defense) => {
				Damage = (int)(Math.Sqrt(Damage) * 5);
				if (Defense > 0) { Damage -= (int)((float)(((float)Defense / 2f) * (float)Damage) / 100f); }
				return (double)Math.Max(Damage, 1);
			};
			On.Terraria.Main.CalculateDamagePlayersTake += (CalculateDamagePlayersTake, Damage, Defense) => { return Main.CalculateDamageNPCsTake(Damage, Defense); };
		}
		
		public override void PostSetupContent() {
			if (ModLoader.TryGetMod("VariablePotionSickness", out var _)) {
				Item.potionDelay = 1800;
				Item.restorationDelay = 1500;
				Player.manaSickTime = 150;
				Player.manaSickTimeMax = 450;
			}
		}
	}
}