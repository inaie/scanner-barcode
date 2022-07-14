using System.Threading.Tasks;

namespace Bar_Code01.Services
{
    public interface IQrCodeScanningService
    {
        Task<string> ScanAsync();
    }
}
