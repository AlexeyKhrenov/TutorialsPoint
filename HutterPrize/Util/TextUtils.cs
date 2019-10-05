using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HutterPrize.Util
{
    public static class TextUtils
    {
        public static Encoding GetEncoding(StreamReader stream)
        {
            stream.Peek();
            return stream.CurrentEncoding;
        }
    }
}
