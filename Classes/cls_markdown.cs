using System.IO;
using CommonMark;

namespace trill.Classes {
    public class cls_markdown {
        public static string ConvertMDtoTXT (string filename) {
            string text = File.ReadAllText (filename);

            return CommonMark.CommonMarkConverter.Convert (text);
        }
    }
}