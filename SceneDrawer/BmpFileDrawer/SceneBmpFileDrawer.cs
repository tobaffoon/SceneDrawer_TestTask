namespace SceneDrawer.BmpFileDrawer {
	public class SceneBmpFileDrawer : ISceneDrawer {
		public const int BmpHeaderSizeInBytes = 14;
		public const int BmpInfoHeaderSizeInBytes = 40;
		public const uint BytesPerPixel = 3;
		public const uint PixelWordSize = 4;

		private readonly byte[] _magicNumbers = [0x42, 0x4D];
		private readonly byte[] _dataOffset = [0x36, 0x00, 0x00, 0x00];
		private readonly byte[] _headerReserved = [0x00, 0x00, 0x00, 0x00];
		private readonly byte[] _infoHeaderSize = [0x28, 0x00, 0x00, 0x00];
		private readonly byte[] _infoHeaderPlanes = [0x01, 0x00];
		private readonly byte[] _infoHeaderCompression = [0x00, 0x00, 0x00, 0x00];
		private readonly byte[] _infoHeaderResolutionX = [0x00, 0x00, 0x00, 0x00];
		private readonly byte[] _infoHeaderResolutionY = [0x00, 0x00, 0x00, 0x00];
		private readonly byte[] _infoHeaderColorIndex = [0x00, 0x00, 0x00, 0x00];
		private readonly byte[] _infoHeaderImportant = [0x00, 0x00, 0x00, 0x00];

		public readonly byte[] BlackPixel = [0x00, 0x00, 0x00];

		public void DrawScene(Scene scene, Stream oStream) {
			if (oStream is not FileStream fs) {
				throw new ArgumentException($"{nameof(SceneTextFileParser)} expected {typeof(FileStream)} but recieved {oStream.GetType()}");
			}

			DrawScene(scene, fs);
		}

		public void DrawScene(Scene scene, string path) {
			DrawScene(scene, new FileStream(path, FileMode.OpenOrCreate));
		}

		public void DrawScene(Scene scene, FileStream oStream) {
			using (BinaryWriter bw = new BinaryWriter(oStream)) {
				uint filesize = (uint)(BmpHeaderSizeInBytes + BytesPerPixel * scene.RequiredBmpWidth * scene.RequiredBmpHeight);
				WriteBmpHeader(filesize, bw);
			}
		}

		private void WriteBmpHeader(uint filesize, BinaryWriter bw) {
			#region Magic numbers
			bw.Write(_magicNumbers);
			#endregion

			#region File Size
			byte[] buffer = BitConverter.GetBytes(filesize);
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Reserved
			bw.Write(_headerReserved);
			#endregion

			#region Actual pixel data offset
			bw.Write(_dataOffset);
			#endregion
		}

		private void WriteBmpInfoHeader(uint widthInPixels, uint heightInPixels, BinaryWriter bw) {
			#region Info header size
			bw.Write(_infoHeaderSize);
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
			bw.Write(_infoHeaderPlanes);
			#endregion

			#region Bits per pixel
			buffer = BitConverter.GetBytes((ushort)(BytesPerPixel * 8));
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Compression method
			bw.Write(_infoHeaderCompression);
			#endregion

			#region Byte size of pixel data
			uint rawRowSize = widthInPixels * BytesPerPixel;
			uint dataSize = (rawRowSize + rawRowSize % PixelWordSize) * heightInPixels;
			buffer = BitConverter.GetBytes(dataSize);
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Print resolution (x coord)
			bw.Write(_infoHeaderResolutionX);
			#endregion

			#region Print resolution (y coord)
			bw.Write(_infoHeaderResolutionY);
			#endregion

			#region Byte size of pixel data
			bw.Write(_infoHeaderColorIndex);
			#endregion

			#region Byte size of pixel data
			bw.Write(_infoHeaderImportant);
			#endregion
		}
	}
}
