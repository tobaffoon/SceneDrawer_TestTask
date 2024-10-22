namespace SceneDrawer.BmpScene {
	public class BmpBitmap : IBitmap {
		public int Width { get; }
		public int Height { get; }

		public readonly uint[,] pixels;

		public BmpBitmap(int width, int height) {
			Width = width;
			Height = height;

			pixels = new uint[Width, Height];
			InitBitmap();
		}

		public void SetPixel(int x, int y, byte[] value) {
			pixels[x, y] = BitConverter.ToUInt32(value);
		}

		public byte[] GetPixel(int x, int y) {
			return BitConverter.GetBytes(pixels[x, y]);
		}

		private void InitBitmap() {
			for (int i = 0; i < Width; i++) {
				for (int j = 0; j < Height; j++) {
					pixels[i, j] = SceneBmpFileDrawer.WhitePixel;
				}
			}
		}
	}
}
