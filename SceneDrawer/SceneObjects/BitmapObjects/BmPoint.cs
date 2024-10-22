using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmPoint : Point {
		public BmPoint(int x, int y) : base(x, y) {
		}

		public override void Draw(IDrawContext dc) {
			if (dc is not BmpBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmPoint)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpBitmap)}");
			}
		}
	}
}
