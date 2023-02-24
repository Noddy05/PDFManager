using System;
using System.Collections.Generic;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PDFManager
{
    class Program
    {
        private static PdfDocument document;
        private static PdfPage currentPage;
        private static XGraphics gfx;
        private static List<PdfPage> pages = new();


        private static (double Left, double Top) margin = (20, 20);
        private static XRect pageRect;
        private static (double Left, double Top) cursor = (0, 0);

        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            NewDocument();

            cursor = margin;
            pageRect = new(new XPoint(margin.Left, margin.Top),
                new XPoint(currentPage.Width - margin.Left, currentPage.Height - margin.Top));


            XFont font = new XFont("Franklin Gothic Book", 12);
            //gfx.DrawRectangle(XBrushes.Red, pageRect);
            WriteParagraph("Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. \n Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. \n Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. \n Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. \n Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. \n Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. \n Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. \n Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. \n Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum. \n ",
                font, XBrushes.Black, XStringFormats.Default, pageRect);

            cursor.Top += font.Size * 2;
            WriteParagraph("Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. \n Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. \n Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. \n Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. \n Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. \n Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. \n Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. \n Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. \n Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum. \n ",
                font, XBrushes.Black, XStringFormats.Default, pageRect);

            cursor.Top += font.Size * 3;
            WriteParagraph("Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. \n Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. \n Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. \n Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. \n Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. \n Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. \n Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. \n Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. \n Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum. \n ",
                font, XBrushes.Black, XStringFormats.Default, pageRect);

            AddNewPage();
            WriteParagraph("Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. \n Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. \n Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. \n Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. \n Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. \n Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. \n Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. \n Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. \n Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum. \n ",
                font, XBrushes.Red, XStringFormats.Center, pageRect);

            document.Save("../../../PDFTest.pdf");

            while (true) ;
        }

        private static void WriteParagraph(string text, XFont font, XBrush brush, XStringFormat format, XRect boundingBox)
        {
            (double Left, double Top) currentCursor = cursor;

            string[] words = text.Split(' ');
            bool ranOutOfSpace = false;
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i] + " ";

                XSize size = gfx.MeasureString(word, font, format);
                if (currentCursor.Left + size.Width >= boundingBox.Width + boundingBox.Left
                    || word == "\n ")
                {
                    currentCursor.Left = margin.Left;
                    currentCursor.Top += size.Height;

                    if (currentCursor.Top + size.Height >= boundingBox.Height + boundingBox.Top)
                    {
                        gfx.DrawString("...",
                            font, brush, new XRect(currentCursor.Left, currentCursor.Top + font.Size, 0, 0));
                        ranOutOfSpace = true;
                        break;
                    }

                    if (word == "\n ")
                        continue;
                }

                gfx.DrawString(word,
                    font, brush, new XRect(currentCursor.Left, currentCursor.Top + font.Size, 0, 0), format);

                currentCursor.Left += size.Width;
            }
            if(!ranOutOfSpace)
                currentCursor.Left -= gfx.MeasureString(" ", font, format).Width;

            cursor = currentCursor;
        }

        private static void NewDocument()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            document = new();
            document.Info.Title = "PDF Test";
            document.Info.Author = "PDFManager | Noah D. Dirksen";
            document.Info.CreationDate = DateTime.Now;

            AddNewPage();
        }

        private static void AddNewPage()
        {
            cursor = margin;
            currentPage = document.AddPage();
            gfx = XGraphics.FromPdfPage(currentPage);
            pages.Add(currentPage);
        }
    }
}
