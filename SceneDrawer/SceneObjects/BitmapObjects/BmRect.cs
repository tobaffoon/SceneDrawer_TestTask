using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmRect : Rect {
		public BmRect(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) {
		}

		public override void Draw(IDrawContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmRect)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}
		}
	}
}
