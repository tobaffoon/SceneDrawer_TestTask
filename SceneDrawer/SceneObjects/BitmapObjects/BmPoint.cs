﻿using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmPoint : Point {
		public BmPoint(int x, int y) : base(x, y) {
		}

		public override void Paint(IPaintContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmPoint)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			bmContext.SetUserScenePixel(X, Y, SceneBmpFileDrawer.BlackPixel);
		}
	}
}
