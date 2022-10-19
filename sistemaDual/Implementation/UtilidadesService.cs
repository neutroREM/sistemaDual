using sistemaDual.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace sistemaDual.Implementation
{
    public class UtilidadesService : IUtilidadesService
    {
        public string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;
        }

        public string ConvertirSha256(string clave)
        {
            StringBuilder sn = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(clave));

                foreach (byte b in result)
                {
                    sn.Append(b.ToString("x2"));
                }
                return sn.ToString();
            }
        }

    }
}
