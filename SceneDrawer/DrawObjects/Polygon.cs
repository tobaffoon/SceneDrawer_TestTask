namespace SceneDrawer.DrawObjects {
	public class Polygon : DrawObject {
		public List<System.Drawing.Point> Points { get; } = new List<System.Drawing.Point>();

		public override void Draw() {
			throw new NotImplementedException();
		}
	}
}
