using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    [Keyless]
    public class QueryStatus
    {
        public const string Free = "Требуется фрилансер";
        public const string Working = "Выполняется";
        public const string Finished = "Выполнено";
    }
}
