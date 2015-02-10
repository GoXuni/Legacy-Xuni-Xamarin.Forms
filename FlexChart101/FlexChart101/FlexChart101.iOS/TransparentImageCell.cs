using CoreGraphics;
using Foundation;
using UIKit;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlexChartDemo.Data.Views.TransparentImageCell), typeof(FlexChartDemo.TransparentImageCellRenderer))]

namespace FlexChartDemo
{
	public class TransparentImageCellRenderer : ImageCellRenderer
	{
		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = base.GetCell (item, reusableCell, tv);
			cell.BackgroundColor = UIColor.LightGray; // UIColor.FromRGB (0.2f, 0.2f, 0.2f);
			return cell;
		}
	}
}

