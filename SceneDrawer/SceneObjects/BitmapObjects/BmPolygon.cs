﻿using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmPolygon : Polygon {

		public override void Draw(IDrawContext dc) {
			if (dc is not BmpBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmPolygon)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpBitmap)}");
			}
		}
	}
}
