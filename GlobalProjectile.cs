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
	public class GProjectile : GlobalProjectile {
		public override void OnHitNPC (Projectile projectile, NPC target, int damage, float knockback, bool crit) {
			target.immune[projectile.owner] = (int)Math.Max(target.immune[projectile.owner] / 2, 1);
		}
		
		public override void OnHitPlayer (Projectile projectile, Player target, int damage, bool crit) {
			target.immuneTime = (int)Math.Max(target.immuneTime / 2, 1);
		}
		
		public override void OnHitPvp (Projectile projectile, Player target, int damage, bool crit) {
			target.immuneTime = (int)Math.Max(target.immuneTime / 2, 1);
		}
		
		public override void AI(Projectile projectile) {
			if (projectile.aiStyle == 75) { return; }
			if (projectile.damage > 0) { projectile.tileCollide = true; }
		}
	}
}