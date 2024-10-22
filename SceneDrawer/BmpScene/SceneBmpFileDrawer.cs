namespace SceneDrawer.BmpScene {
	public class SceneBmpFileDrawer : ISceneDrawer {
		public const int BmpHeaderSizeInBytes = 14;
		public const int BmpInfoHeaderSizeInBytes = 40;
		public const uint BytesPerPixel = 3;
		public const uint BpmRowAllignment = 4;
		public const uint BlackPixel = 0x000000FF;
		public const uint WhitePixel = 0xFFFFFFFF;
		public const ushort BpmMagicNumber = 0x424D;
		public const uint BpmHeaderReserved = 0x00000000;
		public const uint BpmDataOffset = 0x36000000;
		public const uint BpmInfoHeaderSize = 0x28000000;
		public const ushort BpmInfoHeaderPlanes = 0x0100;
		public const uint BpmInfoHeaderCompression = 0x00000000;
		public const uint BpmInfoHeaderResolutionX = 0x00000000;
		public const uint BpmInfoHeaderResolutionY = 0x00000000;
		public const uint BpmInfoHeaderColorIndex = 0x00000000;
		public const uint BpmInfoHeaderImportant = 0x00000000;

		public void DrawScene(Scene scene, IBitmap bm, Stream oStream) {
			if (oStream is not FileStream fs) {
				throw new ArgumentException($"{nameof(SceneBmpFileDrawer)} expected {typeof(FileStream)} but recieved {oStream.GetType()}");
			}

			DrawScene(scene, bm, fs);
		}

		public void DrawScene(Scene scene, IBitmap bm, string path) {
			DrawScene(scene, bm, new FileStream(path, FileMode.OpenOrCreate));
		}

		public void DrawScene(Scene scene, IBitmap bm, FileStream oStream) {
			using (BinaryWriter bw = new BinaryWriter(oStream)) {
				uint filesize = (uint)(BmpHeaderSizeInBytes + BytesPerPixel * bm.Width * bm.Height);
				WriteBmpHeader(filesize, bw);
				WriteBmpInfoHeader(bm.Width, bm.Height, bw);
			}
		}

		private void WriteBmpHeader(uint filesize, BinaryWriter bw) {
			#region Magic numbers
			bw.Write(BpmMagicNumber);
			#endregion

			#region File Size
			byte[] buffer = BitConverter.GetBytes(filesize);
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Reserved
			bw.Write(BpmHeaderReserved);
			#endregion

			#region Actual pixel data offset
			bw.Write(BpmDataOffset);
			#endregion
		}

		private void WriteBmpInfoHeader(int widthInPixels, int heightInPixels, BinaryWriter bw) {
			#region Info header size
			bw.Write(BpmInfoHeaderSize);
			#endregion

			#region Image width in pixels
			byte[] buffer = BitConverter.GetBytes(widthInPixels);
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Image height in pixels
			buffer = BitConverter.GetBytes(heightInPixels);
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Planes
			bw.Write(BpmInfoHeaderPlanes);
			#endregion

			#region Bits per pixel
			buffer = BitConverter.GetBytes((ushort)(BytesPerPixel * 8));
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Compression method
			bw.Write(BpmInfoHeaderCompression);
			#endregion

			#region Byte size of pixel data
			uint rawRowSize = (uint)widthInPixels * BytesPerPixel;
			uint dataSize = (rawRowSize + rawRowSize % BpmRowAllignment) * (uint)heightInPixels;
			buffer = BitConverter.GetBytes(dataSize);
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Print resolution (x coord)
			bw.Write(BpmInfoHeaderResolutionX);
			#endregion

			#region Print resolution (y coord)
			bw.Write(BpmInfoHeaderResolutionY);
			#endregion

			#region Byte size of pixel data
			bw.Write(BpmInfoHeaderColorIndex);
			#endregion

			#region Byte size of pixel data
			bw.Write(BpmInfoHeaderImportant);
			#endregion
		}

		private void WriteBitmap(BmpSceneBitmap bm, BinaryWriter bw) {
			
		}
	}
}
