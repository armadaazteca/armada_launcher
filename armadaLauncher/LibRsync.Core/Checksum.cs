﻿namespace LibRSync.Core
{
    public class Checksum
    {
        public const uint RS_CHAR_OFFSET = 31;

        public static uint Weak(byte[] buf, int len)
        {
            var s1 = 0u;
            var s2 = 0u;

            int i;

            for (i = 0; i < (len - 4); i += 4)
            {
                s2 += 4*(s1 + buf[i]) + (uint) 3*buf[i + 1] +
                      (uint) 2*buf[i + 2] + buf[i + 3] + 10*RS_CHAR_OFFSET;

                s1 += (uint) (buf[i + 0] + buf[i + 1] + buf[i + 2] + buf[i + 3] +
                              4*RS_CHAR_OFFSET);
            }

            for (; i < len; i++)
            {
                s1 += (buf[i] + RS_CHAR_OFFSET);
                s2 += s1;
            }

            return (s1 & 0xffff) + (s2 << 16);
        }

        public static StrongSum Strong(byte[] buf, int len)
        {
            return StrongSumAlgorithm.Md4.GetSum(buf, 0, len);
        }
    }
}
