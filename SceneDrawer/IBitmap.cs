namespace SceneDrawer.BmpScene {
	public interface IBitmap : IDrawContext {
		public int Width { get; }
		public int Height { get; }

		public void SetPixel(int x, int y, byte[] value);

		public byte[] GetPixel(int x, int y);
	}
}
