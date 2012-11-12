using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using Com.Hp.SRA.Proofing.Chart.Util;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Point = Com.Hp.SRA.Proofing.Chart.Point;
using Rectangle = iTextSharp.text.Rectangle;

namespace ItextSharpC
{
    /// <summary>
    /// 
    /// </summary>
    public class IsisBarcode : Barcode
    {
        /** 1 millimeter in points. */
        public const float MmToPoints = 2.83464567F;
        /** 0.5 millimeter in points. */
        private const float HalfMmToPoints = 1.417322835F;
        /** Default bar width (4mm) in points. */
        private const float DefaultBarWidthInPoints = 11.33858268F;
        /** Default bar height (13mm) in points. */
        private const float DefaultBarHeightInPoints = 36.85039371F;
        /** The code39 bars, i.e. 0 for narrow bars and 1 for wide bars. */
        private static readonly byte[][] Code39Bars = new[]
                                                          {
        new byte[]{0, 0, 0, 1, 1, 0, 1, 0, 0},new byte[]{1, 0, 0, 1, 0, 0, 0, 0, 1},
        new byte[]{0, 0, 1, 1, 0, 0, 0, 0, 1},new byte[]{1, 0, 1, 1, 0, 0, 0, 0, 0},new byte[]{0, 0, 0, 1, 1, 0, 0, 0, 1},
        new byte[]{1, 0, 0, 1, 1, 0, 0, 0, 0},new byte[]{0, 0, 1, 1, 1, 0, 0, 0, 0}, new byte[]{0, 0, 0, 1, 0, 0, 1, 0, 1},
        new byte[]{1, 0, 0, 1, 0, 0, 1, 0, 0}, new byte[]{0, 0, 1, 1, 0, 0, 1, 0, 0}, new byte[]{1, 0, 0, 0, 0, 1, 0, 0, 1},
        new byte[]{0, 0, 1, 0, 0, 1, 0, 0, 1}, new byte[]{1, 0, 1, 0, 0, 1, 0, 0, 0}, new byte[]{0, 0, 0, 0, 1, 1, 0, 0, 1},
        new byte[]{1, 0, 0, 0, 1, 1, 0, 0, 0}, new byte[]{0, 0, 1, 0, 1, 1, 0, 0, 0}, new byte[]{0, 0, 0, 0, 0, 1, 1, 0, 1},
        new byte[]{1, 0, 0, 0, 0, 1, 1, 0, 0}, new byte[]{0, 0, 1, 0, 0, 1, 1, 0, 0}, new byte[]{0, 0, 0, 0, 1, 1, 1, 0, 0},
        new byte[]{1, 0, 0, 0, 0, 0, 0, 1, 1}, new byte[]{0, 0, 1, 0, 0, 0, 0, 1, 1}, new byte[]{1, 0, 1, 0, 0, 0, 0, 1, 0},
        new byte[]{0, 0, 0, 0, 1, 0, 0, 1, 1}, new byte[]{1, 0, 0, 0, 1, 0, 0, 1, 0}, new byte[]{0, 0, 1, 0, 1, 0, 0, 1, 0},
        new byte[]{0, 0, 0, 0, 0, 0, 1, 1, 1}, new byte[]{1, 0, 0, 0, 0, 0, 1, 1, 0}, new byte[]{0, 0, 1, 0, 0, 0, 1, 1, 0},
        new byte[]{0, 0, 0, 0, 1, 0, 1, 1, 0}, new byte[]{1, 1, 0, 0, 0, 0, 0, 0, 1}, new byte[]{0, 1, 1, 0, 0, 0, 0, 0, 1},
        new byte[]{1, 1, 1, 0, 0, 0, 0, 0, 0}, new byte[]{0, 1, 0, 0, 1, 0, 0, 0, 1}, new byte[]{1, 1, 0, 0, 1, 0, 0, 0, 0},
        new byte[]{0, 1, 1, 0, 1, 0, 0, 0, 0}, new byte[]{0, 1, 0, 0, 0, 0, 1, 0, 1}, new byte[]{1, 1, 0, 0, 0, 0, 1, 0, 0},
        new byte[]{0, 1, 1, 0, 0, 0, 1, 0, 0}, new byte[]{0, 1, 0, 1, 0, 1, 0, 0, 0},new byte[] {0, 1, 0, 1, 0, 0, 0, 1, 0},
        new byte[]{0, 1, 0, 0, 0, 1, 0, 1, 0}, new byte[]{0, 0, 0, 1, 0, 1, 0, 1, 0}, new byte[]{0, 1, 0, 0, 1, 0, 1, 0, 0}};

        private Point _point;
        private readonly float _mmFromDrawningBar = ConvertUtil.MMToPdfFloat(17);
        private readonly float _mmFromPageBorder = ConvertUtil.MMToPdfFloat(0);

        /** The code39 supported characters. */
        private const String Code39Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*";


        /// <summary>
        /// Gets the bars code39.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        /// Gets the bars code39.
        /// @param text the text
        /// @return the bars code39

        public static byte[] GetBarsCode39(string text)
        {

            text += "*"; // every iSis barcode must be finished with an asterisk
            const int numCharBars = 9;
            const int totalCharBars = 10;
            var barsSize = text.Length * totalCharBars - 1;
            var bars = new byte[barsSize];

            long cs = 0;

            for (var k = 0; k < text.Length; ++k)
            {
                var c = text[k];
                var idx = Code39Characters.IndexOf(Char.ToUpper(c));
                if (idx < 0)
                {
                    throw new Exception("Unsupported character for code39 barcode: " + c);
                }
                cs += c;
                Array.Copy(Code39Bars[idx], 0, bars, k * totalCharBars, numCharBars);
                // make the distance between the characters a wide white bar
                if (k < text.Length - 1)
                {
                    bars[k * totalCharBars + numCharBars] = 1;
                }
            }
            //%03d - > 000 | D3
            var checksum = cs.ToString(CultureInfo.InvariantCulture);
            var barsCheck = new byte[barsSize + checksum.Length * totalCharBars];

            Array.Copy(bars, 0, barsCheck, 0, barsSize);
            barsCheck[barsSize] = 1;


            for (var k = 0; k < checksum.Length; ++k)
            {
                var c = checksum[k];
                var idx = Code39Characters.IndexOf(Char.ToUpper(c));
                if (idx < 0)
                {
                    throw new Exception("Unsupported character for code39 barcode: " + c);
                }
                var destPos = 1 + barsSize + k * totalCharBars;
                Array.Copy(Code39Bars[idx], 0, barsCheck, destPos, numCharBars);
                // make the distance between the characters a wide white bar
                if (k < checksum.Length - 1)
                {
                    barsCheck[destPos + numCharBars] = 1;
                }
            }

            return barsCheck;
        }

        public void SetPoint(Point point)
        {
            this._point = point;
        }


        public override Rectangle PlaceBarcode(PdfContentByte cb, BaseColor barColor, BaseColor textColor)
        {
            const float distanceBetweenBars = MmToPoints;
            const float wideBarPoints = MmToPoints;
            const float narrowBarPoints = HalfMmToPoints;
            const float barWidth = DefaultBarWidthInPoints;
            const float fullHeight = DefaultBarHeightInPoints;

            var barStartX = _point.X - _mmFromPageBorder;
            var barStartY = _point.Y - _mmFromDrawningBar;
            var bars = GetBarsCode39("123456789012345678901234567890123456789");
            var print = true;
            if (barColor != null)
            {
                cb.SetColorFill(barColor);
                cb.SetColorStroke(barColor);
            }

            const int elementBars = 20;
            var elemBarCount = 1;
            foreach (var vbarHeight in bars.Select(t => (t == 0 ? narrowBarPoints : wideBarPoints)))
            {
                if (print)
                {
                    cb.Rectangle(barStartX, barStartY, barWidth, vbarHeight);
                }
                print = !print;
                barStartY += vbarHeight;

                if (elemBarCount++ != elementBars) continue; // start a new element
                elemBarCount = 1;
                barStartY = _point.Y - _mmFromDrawningBar;
                barStartX += barWidth + distanceBetweenBars;
            }
            cb.Fill();
            var fullWidth = barStartX + barWidth;
            return new Rectangle(fullWidth, fullHeight);
        }

        internal static char GetChecksum(string text)
        {
            var num1 = 0;
            foreach (var t in text)
            {
                var num2 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*".IndexOf(t);
                if (num2 < 0)
                {
                    throw new ArgumentException("Unsupported character for code39 barcode: " + t);
                }
                num1 += num2;
            }
            return "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"[num1 % 43];
        }


        public static string GetCode39Ex(string text)
        {
            var stringBuilder = new StringBuilder();
            foreach (var ch1 in text)
            {
                if (ch1 > sbyte.MaxValue)
                {
                    throw new ArgumentException("Unsupported character for code39 barcode: " + ch1);
                }
                var ch2 = "%U$A$B$C$D$E$F$G$H$I$J$K$L$M$N$O$P$Q$R$S$T$U$V$W$X$Y$Z%A%B%C%D%E  /A/B/C/D/E/F/G/H/I/J/K/L - ./O 0 1 2 3 4 5 6 7 8 9/Z%F%G%H%I%J%V A B C D E F G H I J K L M N O P Q R S T U V W X Y Z%K%L%M%N%O%W+A+B+C+D+E+F+G+H+I+J+K+L+M+N+O+P+Q+R+S+T+U+V+W+X+Y+Z%P%Q%R%S%T"[ch1 * 2];
                var ch3 = "%U$A$B$C$D$E$F$G$H$I$J$K$L$M$N$O$P$Q$R$S$T$U$V$W$X$Y$Z%A%B%C%D%E  /A/B/C/D/E/F/G/H/I/J/K/L - ./O 0 1 2 3 4 5 6 7 8 9/Z%F%G%H%I%J%V A B C D E F G H I J K L M N O P Q R S T U V W X Y Z%K%L%M%N%O%W+A+B+C+D+E+F+G+H+I+J+K+L+M+N+O+P+Q+R+S+T+U+V+W+X+Y+Z%P%Q%R%S%T"[ch1 * 2 + 1];
                if (ch2 != 32)
                    stringBuilder.Append(ch2);
                stringBuilder.Append(ch3);

            }
            return stringBuilder.ToString();
        }

        public override Rectangle BarcodeSize
        {
            get
            {
                var val2 = 0.0f;
                var num1 = 0.0f;
                var text = code;
                if (extended)
                    text = GetCode39Ex(code);
                if (font != null)
                {
                    num1 = (double)baseline <= 0.0 ? -baseline + size : baseline - font.GetFontDescriptor(3, size);
                    var str = code;
                    if (generateChecksum && checksumText)
                        str = str + GetChecksum(text);
                    if (startStopText)
                        str = "*" + str + "*";
                    val2 = font.GetWidthPoint(altText ?? str, size);
                }
                var num2 = text.Length + 2;
                if (generateChecksum)
                    ++num2;
                return new Rectangle(Math.Max((float)(num2 * (6.0 * x + 3.0 * x * n) + (num2 - 1) * (double)x), val2),
                    barHeight + num1);
            }
        }

        public override System.Drawing.Image CreateDrawingImage(Color foreground, Color background)
        {
            var text = code;
            if (extended)
                text = GetCode39Ex(code);
            if (generateChecksum)
                text = text + GetChecksum(text);
            var num1 = text.Length + 2;
            var num2 = (int)n;
            var width = num1 * (6 + 3 * num2) + (num1 - 1);
            var height = (int)barHeight;
            var bitmap = new Bitmap(width, height);
            var barsCode39 = GetBarsCode39(text);
            for (var y = 0; y < height; ++y)
            {
                var flag = true;
                var num3 = 0;
                foreach (var t in barsCode39)
                {
                    var num4 = (int)t == 0 ? 1 : num2;
                    var color = background;
                    if (flag)
                        color = foreground;
                    flag = !flag;
                    for (int index2 = 0; index2 < num4; ++index2)
                        bitmap.SetPixel(num3++, y, color);
                }
            }
            return bitmap;
        }

    }
}
