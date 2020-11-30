using System;
using System.IO;
using Syncfusion.SfChart.XForms;

namespace TestGitProject.Interfaces
{
    public interface IChartToPDFDependencyService
    {
        void ExportAsPDF(string filename, Stream chartStream, SfChart chart);
    }
}
