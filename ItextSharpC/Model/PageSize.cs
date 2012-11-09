using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hp.SRA.Proofing.Chart.Model
{
    public class PageSize
    {
        /**
    * A page size of LETTER or 8.5x11.
    */
        public static PageSize PAGE_SIZE_LETTER = new PageSize(612, 792);
        /**
         * A page size of A0 Paper.
         */
        public static PageSize PAGE_SIZE_A0 = new PageSize(2383, 3370);
        /**
         * A page size of A1 Paper.
         */
        public static PageSize PAGE_SIZE_A1 = new PageSize(1685, 2383);
        /**
         * A page size of A2 Paper.
         */
        public static PageSize PAGE_SIZE_A2 = new PageSize(1192, 1685);
        /**
         * A page size of A3 Paper.
         */
        public static PageSize PAGE_SIZE_A3 = new PageSize(843, 1192);
        /**
         * A page size of A4 Paper.
         */
        public static PageSize PAGE_SIZE_A4 = new PageSize(596, 843);
        /**
         * A page size of A5 Paper.
         */
        public static PageSize PAGE_SIZE_A5 = new PageSize(421, 596);
        /**
         * A page size of A6 Paper.
         */
        public static PageSize PAGE_SIZE_A6 = new PageSize(298, 421);

        /// <summary>
        /// Initializes a new instance of the <see cref="PageSize"/> class.
        /// </summary>
        /// <param name="vWidth">Width of the v.</param>
        /// <param name="vHeight">Height of the v.</param>
        public PageSize(double vWidth, double vHeight)
        {
            Width = vWidth;
            Height = vHeight;
        }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public double Width { set; get; }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public double Height { set; get; }

        
    }
}
