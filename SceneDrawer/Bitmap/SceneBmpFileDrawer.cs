﻿namespace SceneDrawer.BmpScene {
	public class SceneToBmpMarshaller {
		public const int BmpHeaderSizeInBytes = 14;
		public const int BmpInfoHeaderSizeInBytes = 40;
		public const int BytesPerPixel = 3;
		public const int BmpRowAllignment = 4;
		public const uint BlackPixel = 0xFF000000;
		public const uint WhitePixel = 0xFFFFFFFF;
		public const ushort BmpMagicNumber = 0x4D42;
		public const uint BmpHeaderReserved = 0x00000000;
		public const uint BmpDataOffset = 0x00000036;
		public const uint BmpInfoHeaderSize = 0x00000028;
		public const ushort BmpInfoHeaderPlanes = 0x0001;
		public const uint BmpInfoHeaderCompression = 0x00000000;
		public const uint BmpInfoHeaderResolutionX = 0x00000000;
		public const uint BmpInfoHeaderResolutionY = 0x00000000;
		public const uint BmpInfoHeaderColorIndex = 0x00000000;
		public const uint BmpInfoHeaderImportant = 0x00000000;

		public void DrawScene(Scene scene, BmpSceneBitmap bm, string path) {
			DrawScene(scene, bm, new FileStream(path, FileMode.OpenOrCreate));
		}

		public void DrawScene(Scene scene, BmpSceneBitmap bm, FileStream oStream) {
			using (BinaryWriter bw = new BinaryWriter(oStream)) {
				uint filesize = (uint)(BmpHeaderSizeInBytes + BmpInfoHeaderSizeInBytes + (BytesPerPixel * bm.Width + GetPaddingPerRow(bm)) * bm.Height);
				WriteBmpHeader(filesize, bw);
				WriteBmpInfoHeader(bm, bw);
				bw.Flush();
				WritePixelData(bm, bw);
			}
		}

		private void WriteBmpHeader(uint filesize, BinaryWriter bw) {
			#region Magic numbers
			bw.Write(BmpMagicNumber);
			#endregion

			#region File Size
			byte[] buffer = BitConverter.GetBytes(filesize);
			bw.Write(buffer);
			#endregion

			#region Reserved
			bw.Write(BmpHeaderReserved);
			#endregion

			#region Actual pixel data offset
			bw.Write(BmpDataOffset);
			#endregion
		}

		private void WriteBmpInfoHeader(BmpSceneBitmap bm, BinaryWriter bw) {
			#region Info header size
			bw.Write(BmpInfoHeaderSize);
			#endregion

			#region Image width in pixels
			byte[] buffer = BitConverter.GetBytes((uint)bm.Width);
			bw.Write(buffer);
			#endregion

			#region Image height in pixels
			buffer = BitConverter.GetBytes((uint)bm.Height);
			bw.Write(buffer);
			#endregion

			#region Planes
			bw.Write(BmpInfoHeaderPlanes);
			#endregion

			#region Bits per pixel
			buffer = BitConverter.GetBytes((ushort)(BytesPerPixel * 8));
			bw.Write(buffer);
			#endregion

			#region Compression method
			bw.Write(BmpInfoHeaderCompression);
			#endregion

			#region Byte size of pixel data
			int dataSize = (BytesPerPixel * bm.Width + GetPaddingPerRow(bm)) * bm.Height;
			buffer = BitConverter.GetBytes(dataSize);
			bw.Write(buffer);
			#endregion

			#region Print resolution (x coord)
			bw.Write(BmpInfoHeaderResolutionX);
			#endregion

			#region Print resolution (y coord)
			bw.Write(BmpInfoHeaderResolutionY);
			#endregion

			#region Byte size of pixel data
			bw.Write(BmpInfoHeaderColorIndex);
			#endregion

			#region Byte size of pixel data
			bw.Write(BmpInfoHeaderImportant);
			#endregion
		}

		private void WritePixelData(BmpSceneBitmap bm, BinaryWriter bw) {
			// pixels in bmp are stored from top to bottom, from left to right
			// Thus we write bytes from the last row first
			for (int i = bm.Height - 1; i >= 0; i--) {
				WritePixelRow(i, bm, bw);
			}
		}

		private void WritePixelRow(int row, BmpSceneBitmap bm, BinaryWriter bw) {
			byte[] buffer;
			Index pixelIndex = Index.FromStart(BytesPerPixel);
			for (int i = 0; i < bm.Width; i++) {
				buffer = BitConverter.GetBytes(bm.pixels[i, row])[..pixelIndex];
				bw.Write(buffer);
			}

			// fix allignment
			int padding = GetPaddingPerRow(bm);
			for (int i = 0; i < padding; i++) {
				bw.Write((byte)0);
			}
		}

		private int GetPaddingPerRow(BmpSceneBitmap bm) {
			return (BmpRowAllignment - bm.Width * BytesPerPixel % BmpRowAllignment) % BmpRowAllignment;
		}
	}
}