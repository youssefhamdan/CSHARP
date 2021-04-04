using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Port
{
    public partial class Form1
    {

        private void Chart()
        {
            chart1.Series.Clear();
            Series series = chart1.Series.Add("Series2");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            foreach (Base index in listeTrier)
            {

                if (index.id == int.Parse(graph.Text) && ((Mesure)index).valuesConverti.Count != 0)
                {

                    for (int i = 0; i < ((Mesure)index).valuesConverti.Count; i++)
                    {
                        series.Points.AddXY(i + 1, ((Mesure)index).valuesConverti[i]);
                    }

                }


            }

        }
    }
}
