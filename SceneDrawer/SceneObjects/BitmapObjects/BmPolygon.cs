using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmPolygon : Polygon {

		public override void Paint(IPaintContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmPolygon)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			int x1, y1, x2, y2;
			// draw all lines until final point
			for (int i = 0; i < Points.Count-1; i++) {
				x1 = Points[i].Item1;
				y1 = Points[i].Item2;
				x2 = Points[i+1].Item1;
				y2 = Points[i+1].Item2;
				foreach ((int, int) coord in BitmapPaintUtils.GetLinePixelsGenerator(x1, y1, x2, y2)) {
					bmContext.SetUserScenePixel(coord.Item1, coord.Item2, SceneBmpFileDrawer.BlackPixel);
				}
			}

			// connect final point and first point
			x1 = Points[^1].Item1;
			y1 = Points[^1].Item2;
			x2 = Points[0].Item1;
			y2 = Points[0].Item2;
			foreach ((int, int) coord in BitmapPaintUtils.GetLinePixelsGenerator(x1, y1, x2, y2)) {
				bmContext.SetUserScenePixel(coord.Item1, coord.Item2, SceneBmpFileDrawer.BlackPixel);
			}
		}
	}
}
