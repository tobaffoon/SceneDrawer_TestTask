namespace SceneDrawer.BmpFileDrawer {
	public class SceneBmpFileDrawer : ISceneDrawer {
		public const int BmpHeaderSizeInBytes = 14;
		public const int BmpHeaderFileSizeOffset = 2;
		public const int BmpHeaderOffbitOffset = 2;
		public const int BmpHeaderReservedOffset = 2;
		public const int BytesPerPixel = 3;

		private readonly byte[] _magicNumbers = [0x42, 0x4D];

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
				uint offbit = 0;
				WriteBmpHeader(filesize, offbit, bw);
			}
		}

		private void WriteBmpHeader(uint filesize, uint offbit, BinaryWriter bw) {
			byte[] header = new byte[BmpHeaderSizeInBytes];
			byte[] buffer = new byte[4];

			_magicNumbers.CopyTo(header, 0);
			
			buffer = BitConverter.GetBytes(filesize);
			Array.Reverse(buffer);
			buffer.CopyTo(header, BmpHeaderFileSizeOffset);

			buffer = [0, 0, 0, 0];
			buffer.CopyTo(header, BmpHeaderReservedOffset);

			buffer = BitConverter.GetBytes(offbit);
			Array.Reverse(buffer);
			buffer.CopyTo(header, BmpHeaderOffbitOffset);

			bw.Write(header);
		}
	}
}
