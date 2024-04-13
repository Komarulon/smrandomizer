using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class IpsPatcher
    {
        public const int EndOfFile = 0x454F46;

        public static void PatchIps(Stream originalFile, byte[] ipsPatch)
        {
            // https://zerosoft.zophar.net/ips.php
            using (var ipsPatchStream = new MemoryStream(ipsPatch))
            {

                // Skip PATCH text.
                ipsPatchStream.Seek(5, SeekOrigin.Begin);
                int offset = Read24(ipsPatchStream);
                while (offset != EndOfFile)
                {
                    int size = Read16(ipsPatchStream);


                    originalFile.Seek(offset, SeekOrigin.Begin);
                    // If RLE patch.
                    if (size == 0)
                    {
                        size = Read16(ipsPatchStream);
                        var rleValue = Read8(ipsPatchStream);
                        var rleArray = new byte[1];
                        rleArray[0] = rleValue;
                        for (var i = 0; i < size; i++)
                        {
                            originalFile.Write(rleArray, 0, 1);
                        }
                    }
                    // If normal patch.
                    else
                    {
                        byte[] data = new byte[size];
                        ipsPatchStream.Read(data, 0, size);
                        originalFile.Write(data, 0, size);

                    }
                    offset = Read24(ipsPatchStream);
                }
            }
        }

        // Helper to read 8 bit.
        public static byte Read8(Stream stream, int offset = -1)
        {
            if (offset != -1 && stream.Position != offset)
            {
                stream.Seek(offset, SeekOrigin.Begin);
            }
            if (stream.Position < stream.Length)
            {
                return (byte)stream.ReadByte();
            }
            else
            {
                return 0;
            }
        }
        // Helper to read 16bit.
        public static int Read16(Stream stream)
        {
            if (stream.Position + 1 < stream.Length)
            {
                byte[] data = new byte[2];
                data[0] = (byte)stream.ReadByte();
                data[1] = (byte)stream.ReadByte();
                return (data[0] << 8) | data[1];
            }
            else
            {
                return 0;
            }
        }
        // Helper to read 24bit.
        public static int Read24(Stream stream)
        {
            if (stream.Position + 1 < stream.Length)
            {
                byte[] data = new byte[3];
                data[0] = (byte)stream.ReadByte();
                data[1] = (byte)stream.ReadByte();
                data[2] = (byte)stream.ReadByte();
                return (data[0] << 16) | (data[1] << 8) | data[2];
            }
            else
            {
                return 0;
            }
        }
    }
}
