namespace SceneDrawer.BmpScene {
	public class Bitmap {
		public int Width { get; }
		public int Height { get; }
		public readonly bool[,] pixels;

		public Bitmap(int width, int height) {
			Width = width;
			Height = height;
			pixels = new bool[Width, Height];
		}

		public void SetPixel(int x, int y, bool value = true) {
			pixels[x, y] = value;
		}

		public bool GetPixel(int x, int y) {
			return pixels[x, y];
		}
	}
}
