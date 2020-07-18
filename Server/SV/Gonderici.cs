using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace SV
{
    class Gonderici
    {
        public static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
           // int startTickCount = Environment.TickCount;
            int sent = 0;
            do
            {
                //if (Environment.TickCount > startTickCount + timeout)
                  //  throw new Exception("Timeout.");
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;
                }
            } while (sent < size);
        }
    }
}
