using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmPolygon : Polygon {

		public override void Paint(IPaintContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmPolygon)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}
		}
	}
}
