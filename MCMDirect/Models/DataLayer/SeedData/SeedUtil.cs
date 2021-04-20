using System.IO;

namespace MCMDirect.Areas.Store.Models.SeedData {
    public class SeedUtil {
        public static byte[] ReadFile(string sPath)
        {
            byte[] data = null;

            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fStream);

            data = br.ReadBytes((int) numBytes);

            return data;
        }
    }
}