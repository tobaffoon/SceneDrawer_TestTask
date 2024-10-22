using SceneDrawer.SceneObjects;

namespace SceneDrawer.Bitmap.BitmapObjects {
	public class BmPolygon : Polygon {

		public override void Draw(IDrawContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmPolygon)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			int x1, y1, x2, y2;
			// draw all lines until final point
			for (int i = 0; i < _points.Count-1; i++) {
				x1 = _points[i].Item1;
				y1 = _points[i].Item2;
				x2 = _points[i+1].Item1;
				y2 = _points[i+1].Item2;
				foreach ((int, int) coord in BitmapDrawUtils.GetLinePixelsGenerator(x1, y1, x2, y2)) {
					bmContext.SetUserScenePixel(coord.Item1, coord.Item2);
				}
			}

			// connect final point and first point
			x1 = _points[^1].Item1;
			y1 = _points[^1].Item2;
			x2 = _points[0].Item1;
			y2 = _points[0].Item2;
			foreach ((int, int) coord in BitmapDrawUtils.GetLinePixelsGenerator(x1, y1, x2, y2)) {
				bmContext.SetUserScenePixel(coord.Item1, coord.Item2);
			}
		}
	}
}
