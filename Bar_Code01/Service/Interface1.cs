using System.Threading.Tasks;

namespace Bar_Code01
{
    public interface IQrCodeScanningService
    {
        Task<string> ScanAsync();
    }
}
