using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace UnityClassNameHasher;

public static class FileIDUtil
{
    public static int Compute(string namespaceStr, string className)
    {
        string toBeHashed = "s\0\0\0" + namespaceStr + className;

        using (HashAlgorithm hash = new UnityClassNameHasher.Crypto.MD4())
        {
            byte[] hashed = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(toBeHashed));

            int result = 0;

            for (int i = 3; i >= 0; --i)
            {
                result <<= 8;
                result |= hashed[i];
            }

            return result;
        }
    }
}