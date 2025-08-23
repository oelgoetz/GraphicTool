using System.Drawing;
using System.Drawing.Imaging;
using Blur;

public class GaussianBlurOutside
{
    private readonly Bitmap _source;
    private readonly Rectangle _outerRect;
    private readonly Rectangle _innerRect;
    private readonly int _radial;

    public GaussianBlurOutside(Bitmap source, Rectangle outerRect, Rectangle innerRect, int radial)
    {
        _source = source;
        _outerRect = outerRect;
        _innerRect = innerRect;
        _radial = radial;
    }

    public Bitmap Process()
    {
        // Clone the outer rectangle from the source image
        Bitmap outerBmp = new Bitmap(_outerRect.Width, _outerRect.Height, PixelFormat.Format32bppArgb);
        using (Graphics g = Graphics.FromImage(outerBmp))
        {
            g.DrawImage(_source, new Rectangle(0, 0, _outerRect.Width, _outerRect.Height), _outerRect, GraphicsUnit.Pixel);
        }

        // Apply Gaussian blur to the whole outer rectangle
        GaussianBlur blur = new GaussianBlur(outerBmp);
        Bitmap blurred = blur.Process(_radial);

        // Copy the inner rectangle from the original image (unblurred)
        Rectangle innerOnBlurred = new Rectangle(
            _innerRect.X - _outerRect.X,
            _innerRect.Y - _outerRect.Y,
            _innerRect.Width,
            _innerRect.Height);

        using (Graphics g = Graphics.FromImage(blurred))
        {
            g.DrawImage(_source, innerOnBlurred, _innerRect, GraphicsUnit.Pixel);
        }

        return blurred;
    }
}
