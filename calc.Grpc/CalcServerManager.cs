/*set TOOLS_PATH=%userprofile%\.nuget\packages\Grps.Tools\1.15.0\tools\windows_x64
* CALL GRPC Protocol builder 
*  C:\Users\iyuzv\.nuget\packages\grpc.tools\1.15.0\tools\windows_x64\protoc.exe service.proto 
*  --grpc_out . --csharp_out=. 
*  --csharp_opt=file_extension=.g.cs 
*  --plugin=protoc-gen-grpc=C:\Users\iyuzv\.nuget\packages\grpc.tools\1.15.0\tools\windows_x64\grpc_csharp_plugin.exe
*C:\Users\iyuzv\.nuget\packages\grpc.tools\1.15.0\tools\windows_x64\protoc.exe service.proto --grpc_out . --csharp_out=. --csharp_opt=file_extension=.g.cs --plugin=protoc-gen-grpc=C:\Users\iyuzv\.nuget\packages\grpc.tools\1.15.0\tools\windows_x64\grpc_csharp_plugin.exe
 */


using Grpc.Core;
using System.Threading.Tasks;

namespace calc.Grpc
{
    public class CalcServerManager
    {
        private Server _server;

        public CalcServerManager()
        {
            _server = new Server
            {
                Services = { CalcService.BindService(new CalcServiceImplementation()) },
                Ports = { new ServerPort("localhost", 1234, ServerCredentials.Insecure) }

            };           

        }

        public void Listen()
        {
            _server.Start();
        }

        public async Task ShutDownAsync()
        {
            await _server.ShutdownAsync();
        }

    }
}
