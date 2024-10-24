﻿using SceneDrawer.SceneObjects;

namespace SceneDrawer.Bitmap.BitmapObjects {
	/// <summary>
	/// Class representing arbitrary line on bitmap.
	/// </summary>
	public class BmLine : Line {
		public BmLine(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) {
		}

		public override void Draw(IDrawContext dc) {
			if(dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmLine)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			foreach ((int, int) coord in BitmapDrawUtils.GetLinePixelsGenerator(X1, Y1, X2, Y2)) {
				bmContext.SetUserScenePixel(coord.Item1, coord.Item2);
			}
		}
	}
}
