using ChartJSCore.Helpers;
using ChartJSCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace IDTPDashboard.Web.Helper
{
    public static class ChartHelper
    {

        #region Chart Method


        public static int GetRandomInteger(int minValue = 0, int maxValue = int.MaxValue)
        {
            if (maxValue < minValue)
            {
                throw new ArgumentOutOfRangeException("Maximum value must be greater than minimum value");
            }
            else if (maxValue == minValue)
            {
                return 0;
            }

            Int64 diff = maxValue - minValue;

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                while (true)
                {
                    byte[] fourBytes = new byte[4];
                    crypto.GetBytes(fourBytes);

                    // Convert that into an uint.
                    UInt32 scale = BitConverter.ToUInt32(fourBytes, 0);

                    Int64 max = (1 + (Int64)UInt32.MaxValue);
                    Int64 remainder = max % diff;
                    if (scale < max - remainder)
                    {
                        return (Int32)(minValue + (scale % diff));
                    }
                }
            }
        }

        public static string[] GetColorList()
        {
            return new string[] { "#FE9666", "#01B8AA", "#698B69", "#008080", "#007EB9", "#5F6B6D", "#DFBFBF", "#660000", "#FFDEAD", "#9AFF9A", "#4F8E83", "#62B1F6", "#990099", "#9D6B84", "#551011" };
        }
        public static Chart GenerateBarChart(List<string> labels, string xaxisLabel, string yaxisLabel, params Dataset[] datasets)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Bar;

            Data data = new Data();
            data.Labels = labels;
            data.Datasets = datasets;

            chart.Data = data;

            var joption = @"{	
                    plugins:{
                     labels:{
                      render: 'value',
                        }
                    },
					tooltips: {
						mode: 'index',
						intersect: false
					},
					responsive: true,
					scales: {
						xAxes: [{
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + xaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
							},
                            barThickness: 40

                        }],
						yAxes: [{
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + yaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
                                }
						    }]
					}
				}";

            chart.Options = JsonConvert.DeserializeObject<Options>(joption);                      

            //chart.Options.PluginDynamic =new Dictionary<string, object>() { { "plugins", "{labels: { render: function(args){return '$$'+args.value;}} }" } };

            //chart.Options.PluginDynamic =new Dictionary<string, object>() { {"plugins", "{{'labels': {'render': 'value' }}}" } };
            chart.Options.Layout = new Layout
            {
                Padding = new Padding
                {
                    PaddingObject = new PaddingObject
                    {
                        Left = 10,
                        Right = 12
                    }
                }
            };

            return chart;
        }

        public static Chart GenerateBarChartforthickbar(List<string> labels, string xaxisLabel, string yaxisLabel, params Dataset[] datasets)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Bar;

            Data data = new Data();
            data.Labels = labels;
            data.Datasets = datasets;

            chart.Data = data;

            var joption = @"{	
                    plugins:{
                     labels:{
                      render: 'value',
                        }
                    },
					tooltips: {
						mode: 'index',
						intersect: false
					},
					responsive: true,
					scales: {
						xAxes: [{
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + xaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
							},
                            barThickness: 25

                        }],
						yAxes: [{
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + yaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
                                }
						    }]
					}
				}";

            chart.Options = JsonConvert.DeserializeObject<Options>(joption);

            //chart.Options.PluginDynamic =new Dictionary<string, object>() { { "plugins", "{labels: { render: function(args){return '$$'+args.value;}} }" } };

            //chart.Options.PluginDynamic =new Dictionary<string, object>() { {"plugins", "{{'labels': {'render': 'value' }}}" } };
            chart.Options.Layout = new Layout
            {
                Padding = new Padding
                {
                    PaddingObject = new PaddingObject
                    {
                        Left = 10,
                        Right = 12
                    }
                }
            };

            return chart;
        }

        public static Chart GeneratePieChart(List<string> labels, params Dataset[] datasets)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Pie;

            Data data = new Data();
            List<string> reducedStringLengthLabels = new List<string>();
            foreach (var item in labels)
            {
                int stringLength = item.Length;
                if (stringLength > 25)
                {
                    reducedStringLengthLabels.Add(item.Substring(0, 25));
                }
                else reducedStringLengthLabels.Add(item);
            }
            data.Labels = reducedStringLengthLabels;



            data.Datasets = datasets;

            var joption = @"{	
                     plugins:{
                     labels:{
                      render: 'percentage',
                      fontColor:'white',
                        }
                    },
					tooltips: {
						mode: 'index',
						intersect: false
					},
                    responsive: true,
                    legend: {
                        //display:True,
						position: 'right'
                        //itemStyle: {
                        //    width: 90 // or whatever, auto-wrap
                        //},
					}
				}";
            
            chart.Options = JsonConvert.DeserializeObject<Options>(joption);
            chart.Data = data;

            


            return chart;
        }


        public static Chart GenerateStackedBarChart(List<string> labels, string xaxisLabel, string yaxisLabel, params Dataset[] datasets)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Bar;

            Data data = new Data();
            data.Labels = labels;
            data.Datasets = datasets;

            chart.Data = data;

            var joption =
                @"{
                    plugins:{
                     labels:{
                      render: 'value',
                        }
                    },
					tooltips: {
						mode: 'index',
						intersect: false
					},
					responsive: true,
					scales: {
						xAxes: [{
							stacked: true,
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + xaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
							},
                            maxBarThickness: 40

                        }],
						yAxes: [{
							stacked: true,
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + yaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
							}
						}]
					}
				}";

            chart.Options = JsonConvert.DeserializeObject<Options>(joption);


            chart.Options.Layout = new Layout
            {
                Padding = new Padding
                {
                    PaddingObject = new PaddingObject
                    {
                        Left = 10,
                        Right = 12
                    }
                }
            };

            return chart;
        }

        public static Chart GenerateStackedBarWithOutLabelChart(List<string> labels, string xaxisLabel, string yaxisLabel, params Dataset[] datasets)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Bar;

            Data data = new Data();
            data.Labels = labels;
            data.Datasets = datasets;

            chart.Data = data;

            var joption =
                @"{
                    plugins:{
                     labels:false,
                    },
					tooltips: {
						mode: 'index',
						intersect: false
					},
					responsive: true,
					scales: {
						xAxes: [{
							stacked: true,
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + xaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
							},
                            maxBarThickness: 40

                        }],
						yAxes: [{
							stacked: true,
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + yaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
							}
						}]
					}
				}";

            chart.Options = JsonConvert.DeserializeObject<Options>(joption);


            chart.Options.Layout = new Layout
            {
                Padding = new Padding
                {
                    PaddingObject = new PaddingObject
                    {
                        Left = 10,
                        Right = 12
                    }
                }
            };

            return chart;
        }
        public static Chart GeneratePieWithOutLabelChart(List<string> labels, params Dataset[] datasets)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Pie;

            Data data = new Data();
            List<string> reducedStringLengthLabels = new List<string>();
            foreach (var item in labels)
            {
                int stringLength = item.Length;
                if (stringLength > 25)
                {
                    reducedStringLengthLabels.Add(item.Substring(0, 25));
                }
                else reducedStringLengthLabels.Add(item);
            }
            data.Labels = reducedStringLengthLabels;



            data.Datasets = datasets;

            var joption = @"{	
                     plugins:{
                     labels:{
                      render: 'value',
                      fontColor:'white',
                        }
                    },
					tooltips: {
						mode: 'index',
						intersect: false
					},
                    responsive: true,
                    legend: {
                        //display:True,
						position: 'right'
                        //itemStyle: {
                        //    width: 90 // or whatever, auto-wrap
                        //},
					}
				}";

            chart.Options = JsonConvert.DeserializeObject<Options>(joption);
            chart.Data = data;




            return chart;
        }
        public static Chart FilledPostVacantPosts()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Bar;

            Data data = new Data();
            data.Labels = new List<string>() { "Officer", "Staff" };
            //data.XLabels = new List<string>() { "Post Type" };
            //data.YLabels = new List<string>() { "Employee Count" };
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Filled Posts",
                Data = new List<double?>() { 827, 907 },
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Vacant Posts",
                Data = new List<double?>() { 466, 321 },
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(54, 162, 235),
                },
                BorderWidth = new List<int>() { 1 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset1);
            data.Datasets.Add(dataset2);

            chart.Data = data;

            var joption = @"{					
					tooltips: {
						mode: 'index',
						intersect: false
					},
					responsive: true,
					scales: {
						xAxes: [{
                            display: true,
							scaleLabel: {
								display: true,
								labelString: 'Post Type'
							},
                            labelFontWeight: 'bold',
                            barThickness: 40

                        }],
						yAxes: [{
                            display: true,
							scaleLabel: {
								display: true,
								labelString: 'Employee Count'
							}
						}]
					}
				}";

            chart.Options = JsonConvert.DeserializeObject<Options>(joption);

            chart.Options.Layout = new Layout
            {
                Padding = new Padding
                {
                    PaddingObject = new PaddingObject
                    {
                        Left = 10,
                        Right = 12
                    }
                }
            };

            return chart;
        }

        public static Chart EmployeeQualification()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Pie;

            Data data = new Data();
            data.Labels = new List<string>() { "S.S.C", "Diploma", "H.S.C", "Hon`s", "Master`s", "PH.D", "Post Doc." };

            PieDataset dataset = new PieDataset()
            {
                Label = "My dataset",
                BackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#FF6384"),
                    ChartColor.FromHexString("#36A2EB"),
                    ChartColor.FromHexString("#FFCE56"),
                    ChartColor.FromHexString("#008080"),
                    ChartColor.FromHexString("#FF7E42"),
                    ChartColor.FromHexString("#985EFF"),
                    ChartColor.FromHexString("#698B69")
                },
                HoverBackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#FF6384"),
                    ChartColor.FromHexString("#36A2EB"),
                    ChartColor.FromHexString("#FFCE56"),
                    ChartColor.FromHexString("#008080"),
                    ChartColor.FromHexString("#FF7E42"),
                    ChartColor.FromHexString("#985EFF"),
                    ChartColor.FromHexString("#698B69")
                },
                Data = new List<double?>() { 12, 21, 9, 68, 17, 36, 41 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            var joption = @"{					
					tooltips: {
						mode: 'index',
						intersect: false
					},
					responsive: true,
                    legend: {
						position: 'right',
					}
				}";

            chart.Options = JsonConvert.DeserializeObject<Options>(joption);

            chart.Data = data;

            return chart;
        }






        public static Chart GenerateLineChart(List<string> labels, string xaxisLabel, string yaxisLabel, params Dataset[] datasets)
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Line;

            Data data = new Data();
            data.Labels = labels;
            data.Datasets = datasets;
            //chart.Data = data;
            //data.Labels = new List<string>() { "January", "February", "March", "April", "May", "June", "July" };

            //LineDataset dataset = new LineDataset()
            //{
            //    Label = "My First dataset",
            //    Data = new List<double?>() { 65, 59, 80, 81, 56, 55, 40 },
            //    Fill = "false",
            //    LineTension = 0.1,
            //    BackgroundColor = ChartColor.FromRgba(75, 192, 192, 0.4),
            //    BorderColor = ChartColor.FromRgba(75, 192, 192, 1),
            //    BorderCapStyle = "butt",
            //    BorderDash = new List<int> { },
            //    BorderDashOffset = 0.0,
            //    BorderJoinStyle = "miter",
            //    PointBorderColor = new List<ChartColor>() { ChartColor.FromRgba(75, 192, 192, 1) },
            //    PointBackgroundColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
            //    PointBorderWidth = new List<int> { 1 },
            //    PointHoverRadius = new List<int> { 5 },
            //    PointHoverBackgroundColor = new List<ChartColor>() { ChartColor.FromRgba(75, 192, 192, 1) },
            //    PointHoverBorderColor = new List<ChartColor>() { ChartColor.FromRgba(220, 220, 220, 1) },
            //    PointHoverBorderWidth = new List<int> { 2 },
            //    PointRadius = new List<int> { 1 },
            //    PointHitRadius = new List<int> { 10 },
            //    SpanGaps = false
            //};

            //data.Datasets = new List<Dataset>();
            //data.Datasets.Add(dataset);
            var joption = @"{	
                    plugins:{
                     labels:{
                      render: 'value',
                        }
                    },
					tooltips: {
						mode: 'index',
						intersect: false
					},
					responsive: true,
					scales: {
						xAxes: [{
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + xaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
							},
                            barThickness: 40

                        }],
						yAxes: [{
                            display: true,
							scaleLabel: {
								display: true,
								labelString: '" + yaxisLabel + @"',
                                fontColor: '#000',
                                fontStyle: 'bold'
                                }
						    }]
					}
				}";

            chart.Options = JsonConvert.DeserializeObject<Options>(joption);
            //Options options = new Options()
            //{
            //    Scales = new Scales()
            //};

            //Scales scales = new Scales()
            //{
            //    YAxes = new List<Scale>()
            //    {
            //        new CartesianScale()
            //    }
            //};

            //CartesianScale yAxes = new CartesianScale()
            //{
            //    Ticks = new Tick()
            //};

            //Tick tick = new Tick()
            //{
            //    Callback = "function(value, index, values) {return value;}"
            //};

            //yAxes.Ticks = tick;
            //scales.YAxes = new List<Scale>() { yAxes };
            //options.Scales = scales;
            //chart.Options = options;

            chart.Data = data;

            return chart;
        }

        public static Chart GenerateLineScatterChart()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Line;

            Data data = new Data();

            LineScatterDataset dataset = new LineScatterDataset()
            {
                Label = "Scatter Dataset",
                Data = new List<LineScatterData>()
            };

            LineScatterData scatterData1 = new LineScatterData();
            LineScatterData scatterData2 = new LineScatterData();
            LineScatterData scatterData3 = new LineScatterData();

            scatterData1.X = "-10";
            scatterData1.Y = "0";
            dataset.Data.Add(scatterData1);

            scatterData2.X = "0";
            scatterData2.Y = "10";
            dataset.Data.Add(scatterData2);

            scatterData3.X = "10";
            scatterData3.Y = "5";
            dataset.Data.Add(scatterData3);

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            Options options = new Options()
            {
                Scales = new Scales()
            };

            Scales scales = new Scales()
            {
                XAxes = new List<Scale>()
                {
                    new CartesianScale()
                    {
                        Type = "linear",
                        Position = "bottom",
                        Ticks = new CartesianLinearTick()
                        {
                            BeginAtZero = true
                        }
                    }
                }
            };

            options.Scales = scales;

            chart.Options = options;

            return chart;
        }

        public static Chart GenerateRadarChart()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Radar;

            Data data = new Data();
            data.Labels = new List<string>() { "Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running" };

            RadarDataset dataset1 = new RadarDataset()
            {
                Label = "My First dataset",
                BackgroundColor = ChartColor.FromRgba(179, 181, 198, 0.2),
                BorderColor = ChartColor.FromRgba(179, 181, 198, 1),
                PointBackgroundColor = new List<ChartColor>() { ChartColor.FromRgba(179, 181, 198, 1) },
                PointBorderColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
                PointHoverBackgroundColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
                PointHoverBorderColor = new List<ChartColor>() { ChartColor.FromRgba(179, 181, 198, 1) },
                Data = new List<double?>() { 65, 59, 80, 81, 56, 55, 40 }
            };

            RadarDataset dataset2 = new RadarDataset()
            {
                Label = "My Second dataset",
                BackgroundColor = ChartColor.FromRgba(255, 99, 132, 0.2),
                BorderColor = ChartColor.FromRgba(255, 99, 132, 1),
                PointBackgroundColor = new List<ChartColor>() { ChartColor.FromRgba(255, 99, 132, 1) },
                PointBorderColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
                PointHoverBackgroundColor = new List<ChartColor>() { ChartColor.FromHexString("#fff") },
                PointHoverBorderColor = new List<ChartColor>() { ChartColor.FromRgba(255, 99, 132, 1) },
                Data = new List<double?>() { 28, 48, 40, 19, 96, 27, 100 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset1);
            data.Datasets.Add(dataset2);

            chart.Data = data;

            return chart;
        }

        public static Chart GeneratePolarChart()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.PolarArea;

            Data data = new Data();
            data.Labels = new List<string>() { "Red", "Green", "Yellow", "Grey", "Blue" };

            PolarDataset dataset = new PolarDataset()
            {
                Label = "My dataset",
                BackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#FF6384"),
                    ChartColor.FromHexString("#4BC0C0"),
                    ChartColor.FromHexString("#FFCE56"),
                    ChartColor.FromHexString("#E7E9ED"),
                    ChartColor.FromHexString("#36A2EB")
                },
                Data = new List<double?>() { 11, 16, 7, 3, 14 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            return chart;
        }

        public static Chart GeneratePieChart()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Pie;

            Data data = new Data();
            data.Labels = new List<string>() { "Red", "Blue", "Yellow" };

            PieDataset dataset = new PieDataset()
            {
                Label = "My dataset",
                BackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#FF6384"),
                    ChartColor.FromHexString("#36A2EB"),
                    ChartColor.FromHexString("#FFCE56")
                },
                HoverBackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#FF6384"),
                    ChartColor.FromHexString("#36A2EB"),
                    ChartColor.FromHexString("#FFCE56")
                },
                Data = new List<double?>() { 300, 50, 100 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            return chart;
        }

        public static Chart GenerateNestedDoughnutChart()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Doughnut;

            Data data = new Data();
            data.Labels = new List<string>() {
                "resource-group-1",
                "resource-group-2",
                "Data Services - Basic Database Days",
                "Data Services - Basic Database Days",
                "Azure App Service - Basic Small App Service Hours",
                "resource-group-2 - Other"
            };

            PieDataset outerDataset = new PieDataset()
            {
                BackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#3366CC"),
                    ChartColor.FromHexString("#DC3912"),
                    ChartColor.FromHexString("#FF9900"),
                    ChartColor.FromHexString("#109618"),
                    ChartColor.FromHexString("#990099"),
                    ChartColor.FromHexString("#3B3EAC")
                },
                HoverBackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#3366CC"),
                    ChartColor.FromHexString("#DC3912"),
                    ChartColor.FromHexString("#FF9900"),
                    ChartColor.FromHexString("#109618"),
                    ChartColor.FromHexString("#990099"),
                    ChartColor.FromHexString("#3B3EAC")
                },
                Data = new List<double?>() {
                    0.0,
                    0.0,
                    8.31,
                    10.43,
                    84.69,
                    0.84
                }
            };

            PieDataset innerDataset = new PieDataset()
            {
                BackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#3366CC"),
                    ChartColor.FromHexString("#DC3912"),
                    ChartColor.FromHexString("#FF9900"),
                    ChartColor.FromHexString("#109618"),
                    ChartColor.FromHexString("#990099"),
                    ChartColor.FromHexString("#3B3EAC")
                },
                HoverBackgroundColor = new List<ChartColor>() {
                    ChartColor.FromHexString("#3366CC"),
                    ChartColor.FromHexString("#DC3912"),
                    ChartColor.FromHexString("#FF9900"),
                    ChartColor.FromHexString("#109618"),
                    ChartColor.FromHexString("#990099"),
                    ChartColor.FromHexString("#3B3EAC")
                },
                Data = new List<double?>() {
                    8.31,
                    95.96
                }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(outerDataset);
            data.Datasets.Add(innerDataset);

            chart.Data = data;

            return chart;
        }

        public static Chart AddMillionWithYaxes(this Chart chart)
        {
            CartesianScale yAxes = new CartesianScale()
            {
                Ticks = new Tick()
            };

            Tick tick = new Tick()
            {
                Callback = "function(value, index, values) {return value + 'M';}"
            };

            yAxes.Ticks = tick;
            chart.Options.Scales.YAxes = new List<Scale>() { yAxes };
            return chart;
        }
        public static double ConvertThousand(this double amount)
        {
            return Math.Round(amount / 1000, 2);
        }
        public static double ConvertMillions(this double amount)
        {
            return Math.Round(amount/1000000,2);
        }
        public static double ConvertCrores(this double amount)
        {
            return Math.Round(amount / 10000000, 2);
        }
        public static double ConvertBilions(this double amount)
        {
            return Math.Round(amount / 1000000000, 2);
        }
        #endregion
    }
}

