using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFStructure.iOS.CustomRenderers;
using XFStructure.Views;

[assembly: ExportRenderer(typeof(CircularFrame), typeof(CircularFrameRenderer))]
namespace XFStructure.iOS.CustomRenderers
{
    public class CircularFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (NativeView != null && e.NewElement != null)
            {
                var cFrame = e.NewElement as CircularFrame;

                var layer = NativeView.Layer;
                layer.CornerRadius = cFrame.CornerRadius / 2;
                layer.ShadowRadius = cFrame.Elevation * 0.3f;
                layer.ShadowOpacity = 0.36f;
            }
        }
    }
}