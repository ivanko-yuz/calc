
using Grpc.Core;
using System.Threading.Tasks;
using static calc.CalcService;

namespace calc.Grpc
{
    public class CalcClientManager
    {
        private Channel _channel;
        private CalcServiceClient _client;

        public void Connect()
        {
            _channel = new Channel("localhost:1234", ChannelCredentials.Insecure);
            _client = new CalcServiceClient(_channel);
        }

        public async Task<string> SendMessageAsync(string formula)
        {
            return (await _client.GetAnswerAsync(new CalcRequest() { Formula = formula })).Answer;
        }

        public async Task ShutDownAsync()
        {
            await _channel.ShutdownAsync();
        }
    }
}
