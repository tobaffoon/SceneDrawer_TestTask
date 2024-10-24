﻿using SceneDrawer.SceneObjects;

namespace SceneDrawer.Bitmap.BitmapObjects {
	/// <summary>
	/// Class representing pixel on bitmap.
	/// </summary>
	public class BmPoint : Point {
		public BmPoint(int x, int y) : base(x, y) {
		}

		public override void Draw(IDrawContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmPoint)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			bmContext.SetUserScenePixel(X, Y);
		}
	}
}
