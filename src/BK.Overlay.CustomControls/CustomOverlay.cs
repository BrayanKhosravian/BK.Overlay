using BK.Overlay.Controls.Common.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BK.Overlay.CustomControls
{

	/// <summary>
	/// Returns an Enumerator that enumerates over nothing.
	/// </summary>
	internal class EmptyIEnumerable : IEnumerable
	{
		// singleton class, private ctor
		private EmptyIEnumerable()
		{
		}

		/// <summary>
		/// Read-Only instance of an Empty Enumerator.
		/// </summary>
		public static IEnumerable Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new EmptyIEnumerable();
				}
				return _instance;
			}
		}

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		private static IEnumerable _instance;
		
	}

	[ContentProperty(nameof(BindableChildren))]
	internal class BindableCanvas : Canvas
	{
		internal Collection<UIElement> BindableChildren 
		{
			get => (Collection<UIElement>)GetValue(BindableChildrenProperty);
			set => SetValue(BindableChildrenProperty, value);
		}

		internal static DependencyProperty BindableChildrenProperty = DependencyProperty.Register(
			nameof(BindableChildren),
			typeof(Collection<UIElement>),
			typeof(BindableCanvas),
			new PropertyMetadata(new Collection<UIElement>(), new PropertyChangedCallback(BindableChildrenOnPropertyChanged)));

		private static void BindableChildrenOnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			
		}
	}

	[ContentProperty("CanvasItems")]
    public class CustomOverlay : Window
    {
        static CustomOverlay()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomOverlay), new FrameworkPropertyMetadata(typeof(Window)));
        }

		public CustomOverlay()
		{
            Content = CreateContent();
		}

		public Collection<UIElement> CanvasItems 
		{
			get => (Collection<UIElement>) GetValue(CanvasItemsProperty);
			set => SetValue(CanvasItemsProperty, value);
		}

		public static DependencyProperty CanvasItemsProperty = DependencyProperty.Register(
			nameof(CanvasItems),
			typeof(Collection<UIElement>),
			typeof(CustomOverlay),
			new PropertyMetadata(new Collection<UIElement>(), new PropertyChangedCallback(OnCanvasItemsPropertyChanged)));
		
		private static void OnCanvasItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			
		}

		private DpiDecorator CreateContent()
		{
			var dpiDecorator = new DpiDecorator();
            var itemsControl = new ItemsControl();

            var canvasFactory = new FrameworkElementFactory(typeof(BindableCanvas));
			canvasFactory.SetBinding(BindableCanvas.BindableChildrenProperty, new Binding(nameof(CanvasItems)));

            var itemsPanelTemplate = new ItemsPanelTemplate(canvasFactory);
            itemsControl.ItemsPanel = itemsPanelTemplate;



            // todo: add following bindings to support MVVM
            //      ItemsControl.ItemsSource
            //      ItemsControl.ItemTemplateSelector
            //      ItemContainerStyleSelector

            
            dpiDecorator.Child = itemsControl;
			return dpiDecorator;


		}
	}
}
