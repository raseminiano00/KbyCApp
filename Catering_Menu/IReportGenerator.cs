using System.Data;

namespace Catering_Menu
{
    public interface IReportGenerator
    {
        DataTable Generate();
    }
}