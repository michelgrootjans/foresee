using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace Support.Test.Test
{
    public static class ByteStreamExtensions
    {
        public static void ShouldBeSameAs(this byte[] actual, byte[] expected)
        {
            try
            {
                Assert.AreEqual(expected.Length, actual.Length, "Byte arrays have different lengths.");
                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i], actual[i], "Byte value differs at position {0}.", i + 1);
                }
            }
            catch
            {
                DebugWrite(expected, "Expected");
                DebugWrite(actual, "Actual");
                DebugWriteIndexes(Math.Max(expected.Length, actual.Length));
                throw;
            }
        }

        public static void ShouldBeSameAs(this Stream actual, Stream expected)
        {
            expected.Position = 0;
            actual.Position = 0;

            try
            {
                Assert.AreEqual(expected.Length, actual.Length, "Streams have different lengths.");
            }
            catch
            {
                DebugWrite(expected, "Expected");
                DebugWrite(actual, "Actual");
                DebugWriteIndexes(Math.Max((int)expected.Length, (int)actual.Length));
                throw;
            }

            byte[] actualBuffer = new byte[actual.Length];
            byte[] expectedBuffer = new byte[expected.Length];

            expected.Read(expectedBuffer, 0, (int)expected.Length);
            actual.Read(actualBuffer, 0, (int)actual.Length);

            actualBuffer.ShouldBeSameAs(expectedBuffer);
        }

        public static void ShouldBeSameAs(this Stream actual, byte[] expected, bool resetPosition)
        {
            try
            {
                if (resetPosition) actual.Position = 0;

                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i], actual.ReadByte(), "Byte value differs at position {0}.", i + 1);
                }
            }
            catch
            {
                DebugWrite(expected, "Expected");
                DebugWrite(actual, "Actual");
                DebugWriteIndexes(Math.Max(expected.Length, (int)actual.Length));
                throw;
            }
        }

        private static void DebugWrite(Stream stream, string category)
        {
            Debug.Write(string.Format("{0,-10}: ", category));
            long currentPosition = stream.Position;
            stream.Position = 0;

            int b = stream.ReadByte();
            while (b >= 0)
            {
                Debug.Write(string.Format("0x{0:X2} ", b));
                b = stream.ReadByte();
            }

            stream.Position = currentPosition;
            Debug.WriteLine(string.Empty);
        }
        private static void DebugWrite(Byte[] bytes, string category)
        {
            Debug.Write(string.Format("{0,-10}: ", category));
            for (int i = 0; i < bytes.Length; i++)
            {
                Debug.Write(string.Format("0x{0:X2} ", bytes[i]));
            }
            Debug.WriteLine(string.Empty);
        }
        private static void DebugWriteIndexes(int count)
        {
            Debug.Write(string.Empty.PadRight(12));
            for (int i = 1; i <= count; i++)
            {
                Debug.Write(string.Format("{0,-4} ", i));
            }
            Debug.WriteLine(string.Empty);
        }

    }
}