namespace SceneDrawer.BmpFileDrawer {
	public class SceneBmpFileDrawer : ISceneDrawer {
		public const int BmpHeaderSizeInBytes = 14;
		public const int BmpInfoHeaderSizeInBytes = 40;
		public const int BytesPerPixel = 3;

		private readonly byte[] _magicNumbers = [0x42, 0x4D];
		private readonly byte[] _dataOffset = [0x36, 0x00, 0x00, 0x00];
		private readonly byte[] _infoHeaderSize = [0x28, 0x00, 0x00, 0x00];

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
			byte[] buffer = new byte[4];
			buffer = BitConverter.GetBytes(filesize);
			Array.Reverse(buffer);
			bw.Write(buffer);
			#endregion

			#region Reserved
			bw.Write([0, 0, 0, 0]);
			#endregion

			#region Actual pixel data offset
			bw.Write(_dataOffset);
			#endregion
		}

		private void WriteBmpInfoHeader(int widthInPixels, int heightInPixels, BinaryWriter bw) {

		}
	}
}
