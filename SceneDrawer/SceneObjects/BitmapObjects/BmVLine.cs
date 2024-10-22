using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmVLine : VLine {
		public BmVLine(int x, int y1, int y2) : base(x, y1, y2) {
		}

		public override void Draw(IDrawContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmVLine)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}
		}
	}
}
