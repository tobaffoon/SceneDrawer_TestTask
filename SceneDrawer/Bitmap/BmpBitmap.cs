namespace SceneDrawer.Bitmap {
	/// <summary>
	/// Class that represent Bitmap that uses uint array to store pixel information.
	/// 
	/// This Bitmap is expected to be marshalled to .bmp file.
	/// </summary>
	public class BmpBitmap : IBitmap {
		public int Width { get; }
		public int Height { get; }

		public readonly uint[,] pixels;

		public BmpBitmap(int width, int height) {
			if (width <= 0 || height <= 0) {
				throw new ArgumentException($"Non-positive number was passed as size of Bitmap. Only positive numbers are allowed.\n Passed numbers: \n\tWidth:{width}\n\tHeight:{height})");
			}
			Width = width;
			Height = height;

			pixels = new uint[Width, Height];
			InitBitmap();
		}

		public void SetPixel(int x, int y, byte[] value) {
			CheckCoordinates(x, y);
			pixels[x, y] = BitConverter.ToUInt32(value);
		}

		public byte[] GetPixel(int x, int y) {
			CheckCoordinates(x, y);
			return BitConverter.GetBytes(pixels[x, y]);
		}

		/// <summary>
		/// Convenient method for setting bitmap pixel with uint value instead of byte[].
		/// </summary>
		public void SetPixelUInt(int x, int y, uint value = BmpBitmapDrawer.BlackPixel) {
			CheckCoordinates(x, y);
			pixels[x, y] = value;
		}

		/// <summary>
		/// Convenient method for getting uint bitmap pixel instead of byte[].
		/// </summary>
		public uint GetPixelUInt(int x, int y) {
			CheckCoordinates(x, y);
			return pixels[x, y];
		}

		private void InitBitmap() {
			for (int i = 0; i < Width; i++) {
				for (int j = 0; j < Height; j++) {
					pixels[i, j] = BmpBitmapDrawer.WhitePixel;
				}
			}
		}

		private void CheckCoordinates(int x, int y) {
			if (x < 0 || x >= Width || y < 0 || y >= Height) {
				throw new ArgumentException($"Invalid coordinates of pixel were passed. Expected range: x - [0, {Width}]; y - [0, {Height}]. However ({x}, {y}) were passed");
			}
		}
	}
}
