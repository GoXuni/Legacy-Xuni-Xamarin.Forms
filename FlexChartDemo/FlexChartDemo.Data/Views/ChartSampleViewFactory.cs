﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using FlexChartDemo.Data.Chart;
using FlexChartDemo.Data.Views.Samples;

namespace FlexChartDemo.Data.Views
{
    public static class ChartSampleViewFactory
    {
        public static ContentPage GetChartContentPage(ChartSample chartSample)
        {
            ContentPage page = null;

            switch (chartSample.SampleViewType)
            {
                case (int)ChartSampleViewType.GETTING_STARTED:
                    page = new GettingStartedSample(chartSample);
                    break;

                case (int)ChartSampleViewType.CHART_TYPES:
                    page = new ChartTypesSample(chartSample);
                    break;

                case (int)ChartSampleViewType.MIXED_CHART_TYPES:
                    page = new MixedChartTypesSample(chartSample);
                    break;

                case (int)ChartSampleViewType.LEGEND_AND_TITLES:
                    page = new TitleAndLegendSample(chartSample);
                    break;

                case (int)ChartSampleViewType.TOOLTIPS:
                    page = new TooltipsSample(chartSample);
                    break;

                case (int)ChartSampleViewType.STYLING_SERIES:
                    page = new StylingSeriesSample(chartSample);
                    break;

                case (int)ChartSampleViewType.CUSTOMIZING_AXES:
                    page = new CustomizingAxesSample(chartSample);
                    break;

                case (int)ChartSampleViewType.THEMING:
                    page = new ThemingSample(chartSample);
                    break;

                case (int)ChartSampleViewType.SELECTION_MODES:
                    page = new SelectionModesSample(chartSample);
                    break;

                case (int)ChartSampleViewType.TOGGLE_SERIES:
                    page = new ToggleSeriesSample(chartSample);
                    break;

                case (int)ChartSampleViewType.DYNAMIC_CHARTS:
                    page = new DynamicChartsSample(chartSample);
                    break;
                case (int)ChartSampleViewType.BUBBLE_CHART:
                    page = new BubbleChartSample(chartSample);
                    break;
                case (int)ChartSampleViewType.FINANCIAL_CHART:
                    page = new FinancialChart(chartSample);
                    break;
                case (int)ChartSampleViewType.ZOOMING_AND_SCROLLING:
                    page = new ZoomingAndScrolling(chartSample);
                    break;
                case (int)ChartSampleViewType.HITTEST:
                    page = new HitTest();
                    break;
            }

            page.Title = chartSample.Name;

            return page;
        }
    }
}
