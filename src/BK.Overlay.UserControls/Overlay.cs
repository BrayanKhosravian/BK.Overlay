using BK.Overlay.Core.Shapes;
using BK.Overlay.UserControls.Common;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace BK.Overlay.UserControls
{
	[ContentProperty(nameof(CanvasItems))]
	public class Overlay : CustomWindow
	{
		public Overlay()
		{
			var resources = new OverlayResources();
			Resources = resources;

			var root = CreateRoot();
			Content = root;  
        }

		#region ContentProperty

		public ObservableCollection<UIElement> CanvasItems
		{
			get => (ObservableCollection<UIElement>)GetValue(CanvasItemsProperty);
			set => SetValue(CanvasItemsProperty, value);
		}

		public static readonly DependencyProperty CanvasItemsProperty = DependencyProperty.Register(nameof(CanvasItems), 
			typeof(ObservableCollection<UIElement>),
			typeof(Overlay), 
			new PropertyMetadata(new ObservableCollection<UIElement>(), new PropertyChangedCallback(CanvasItemsPropertyChanged)));

		private static void CanvasItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var old = (ObservableCollection<UIElement>)e.OldValue;
			if (old != null)
			{
				old.CollectionChanged -= CanvasItemsCollectionChanged;
			}
			((ObservableCollection<UIElement>)e.NewValue).CollectionChanged += CanvasItemsCollectionChanged;
		}

		private static void CanvasItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			
		}

		#endregion

		private DpiDecorator CreateRoot()
		{
			
			// canvas
			var itemsControl = new ItemsControl();
			DataContext = this;
			
			var canvasItemsBinding = new Binding(nameof(OverlayViewModelBase.CanvasItems));
			itemsControl.SetBinding(ItemsControl.ItemsSourceProperty, canvasItemsBinding);
			itemsControl.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(Overlay.CanvasItems)));

		//	itemsControl.ItemTemplateSelector = new CanvasItemSelector();
			// itemsControl.ItemContainerStyleSelector = new CanvasItemContainerStyleSelector();

			var itemsPanelTemplate = new ItemsPanelTemplate(new System.Windows.FrameworkElementFactory(typeof(Canvas)));
			itemsControl.ItemsPanel = itemsPanelTemplate;

			// dpi decorator

			var dpiDecorator = new DpiDecorator();
			dpiDecorator.Child = itemsControl;

			return dpiDecorator;

		}
    }

	public abstract class OverlayViewModelBase
	{
		public ObservableCollection<Shape> CanvasItems { get; protected set; } = new ObservableCollection<Shape>();
	}
}
