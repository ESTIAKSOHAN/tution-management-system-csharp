using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

public class EDDiagramGenerator
{
    private const int Width = 1600;
    private const int Height = 1200;
    private Bitmap bitmap;
    private Graphics graphics;
    private Brush blackBrush = Brushes.Black;
    private Brush whiteBrush = Brushes.White;
    private Brush lightGrayBrush = new SolidBrush(Color.FromArgb(230, 230, 230));
    private Pen blackPen = new Pen(Color.Black, 2);
    private Pen thinPen = new Pen(Color.Black, 1.5f);
    private Font largeFont = new Font("Arial", 12, FontStyle.Bold);
    private Font normalFont = new Font("Arial", 10);
    private Font smallFont = new Font("Arial", 8);

    public EDDiagramGenerator()
    {
        bitmap = new Bitmap(Width, Height);
        graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.White);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    }

    private void DrawRoundedBox(int x, int y, int width, int height, string text, bool isModal = false)
    {
        // Draw box
        graphics.FillRoundedRectangle(lightGrayBrush, x - width / 2, y - height / 2, width, height, 15);
        graphics.DrawRoundedRectangle(blackPen, x - width / 2, y - height / 2, width, height, 15);

        // Draw text
        SizeF textSize = graphics.MeasureString(text, normalFont);
        float textX = x - textSize.Width / 2;
        float textY = y - textSize.Height / 2;
        graphics.DrawString(text, normalFont, blackBrush, textX, textY);
    }

    private void DrawDiamond(int x, int y, int width, int height, string text)
    {
        Point[] points = new Point[4]
        {
            new Point(x, y - height / 2),           // Top
            new Point(x + width / 2, y),            // Right
            new Point(x, y + height / 2),           // Bottom
            new Point(x - width / 2, y)             // Left
        };

        graphics.FillPolygon(lightGrayBrush, points);
        graphics.DrawPolygon(blackPen, points);

        // Draw text
        SizeF textSize = graphics.MeasureString(text, normalFont);
        float textX = x - textSize.Width / 2;
        float textY = y - textSize.Height / 2;
        graphics.DrawString(text, normalFont, blackBrush, textX, textY);
    }

    private void DrawArrow(int x1, int y1, int x2, int y2, string label, float curveAmount = 0)
    {
        // Draw arrow line with optional curve
        if (curveAmount == 0)
        {
            graphics.DrawLine(thinPen, x1, y1, x2, y2);
        }
        else
        {
            // Draw curved line using Bezier
            int cp1X = (x1 + x2) / 2 + (int)(curveAmount * (y2 - y1) / 2);
            int cp1Y = (y1 + y2) / 2 - (int)(curveAmount * (x2 - x1) / 2);
            int cp2X = (x1 + x2) / 2 + (int)(curveAmount * (y2 - y1) / 2);
            int cp2Y = (y1 + y2) / 2 - (int)(curveAmount * (x2 - x1) / 2);

            graphics.DrawBezier(thinPen, x1, y1, cp1X, cp1Y, cp2X, cp2Y, x2, y2);
        }

        // Draw arrowhead
        float angle = (float)Math.Atan2(y2 - y1, x2 - x1);
        float arrowSize = 15;
        float arrowX = x2 - arrowSize * (float)Math.Cos(angle);
        float arrowY = y2 - arrowSize * (float)Math.Sin(angle);

        PointF[] arrowHead = new PointF[3]
        {
            new PointF(x2, y2),
            new PointF(arrowX - 10 * (float)Math.Sin(angle), arrowY + 10 * (float)Math.Cos(angle)),
            new PointF(arrowX + 10 * (float)Math.Sin(angle), arrowY - 10 * (float)Math.Cos(angle))
        };

        graphics.FillPolygon(blackBrush, arrowHead);
        graphics.DrawPolygon(blackPen, arrowHead);

        // Draw label
        if (!string.IsNullOrEmpty(label))
        {
            int midX = (x1 + x2) / 2;
            int midY = (y1 + y2) / 2;
            SizeF labelSize = graphics.MeasureString(label, smallFont);

            // Draw label background
            graphics.FillRectangle(whiteBrush, midX - labelSize.Width / 2 - 5, midY - labelSize.Height / 2 - 2, labelSize.Width + 10, labelSize.Height + 4);
            graphics.DrawRectangle(thinPen, midX - labelSize.Width / 2 - 5, midY - labelSize.Height / 2 - 2, labelSize.Width + 10, labelSize.Height + 4);
            graphics.DrawString(label, smallFont, blackBrush, midX - labelSize.Width / 2, midY - labelSize.Height / 2);
        }
    }

    private void DrawLoadingIndicator(int x, int y)
    {
        // Draw circle
        graphics.FillEllipse(whiteBrush, x - 20, y - 20, 40, 40);
        graphics.DrawEllipse(blackPen, x - 20, y - 20, 40, 40);

        // Draw dotted circle indicator
        graphics.DrawString("...", smallFont, blackBrush, x - 12, y - 10);
    }

    private void DrawScreen(int x, int y, int width, int height, string title, string[] buttons)
    {
        // Draw outer box (device frame)
        int frameX = x - width / 2;
        int frameY = y - height / 2;
        graphics.FillRoundedRectangle(lightGrayBrush, frameX, frameY, width, height, 20);
        graphics.DrawRoundedRectangle(blackPen, frameX, frameY, width, height, 20);

        // Draw title
        graphics.DrawString(title, smallFont, blackBrush, frameX + 10, frameY + 10);

        // Draw buttons
        int buttonY = frameY + 40;
        foreach (var button in buttons)
        {
            int buttonWidth = width - 20;
            int buttonHeight = 40;
            graphics.FillRoundedRectangle(whiteBrush, frameX + 10, buttonY, buttonWidth, buttonHeight, 5);
            graphics.DrawRoundedRectangle(thinPen, frameX + 10, buttonY, buttonWidth, buttonHeight, 5);

            SizeF buttonTextSize = graphics.MeasureString(button, smallFont);
            graphics.DrawString(button, smallFont, blackBrush, 
                frameX + 10 + (buttonWidth - buttonTextSize.Width) / 2, 
                buttonY + (buttonHeight - buttonTextSize.Height) / 2);

            buttonY += buttonHeight + 10;
        }

        // Draw status indicator dot at bottom
        graphics.FillEllipse(blackBrush, x - 3, frameY + height - 15, 6, 6);
    }

    public void Generate()
    {
        // Title
        graphics.DrawString("Navigation Flow Diagram - Login/Logout System", largeFont, blackBrush, 400, 30);

        // Draw screens
        // Right side - Login/Overview screens
        DrawScreen(1350, 250, 120, 180, "Login", new[] { "Login", "Overview" });

        // Top right - Details screen
        DrawScreen(900, 100, 150, 200, "Details", new[] { "Details" });

        // Left side - Home screen (logged in)
        DrawScreen(250, 280, 150, 200, "Home", new[] { "Details", "Logout" });

        // Bottom middle - Confirm logout screen
        DrawScreen(650, 650, 180, 150, "Confirm", new[] { "Confirmation" });

        // Bottom right - Await logout screen
        DrawScreen(950, 850, 180, 180, "Await", new[] { "Loading..." });

        // Draw arrows with labels
        // Login to Details [Push]
        DrawArrow(1250, 180, 950, 150, "[Push]", 0.2f);

        // Overview to Home [Push]
        DrawArrow(1250, 350, 350, 300, "[Push]", 0.3f);

        // Home Logout to Confirm [Modal]
        DrawArrow(250, 400, 580, 620, "[Modal]", -0.2f);

        // Details back to Home [Cancel & Pop]
        DrawArrow(850, 150, 350, 280, "[Cancel & Pop]", 0.4f);

        // Details Pop (curved back)
        DrawArrow(950, 80, 1280, 200, "[Pop]", 0.3f);

        // Confirm Logout - No back to Home [Dismiss modal]
        DrawArrow(580, 700, 350, 450, "[Dismiss modal]", -0.3f);

        // Confirm Logout - Yes to Await [Push]
        DrawArrow(750, 750, 900, 850, "[Push]", 0.1f);

        // Await Logout - Success/Reset to Overview
        DrawArrow(1050, 800, 1350, 400, "[Reset]", 0.4f);

        // Add decision diamond and connectors
        DrawDiamond(750, 700, 100, 80, "Confirmed?");

        // No branch
        DrawArrow(700, 720, 650, 720, "No", 0);

        // Yes branch
        DrawArrow(800, 740, 900, 800, "Yes", 0);

        // Draw loading indicator inside Await screen
        DrawLoadingIndicator(950, 850);

        // Save the image
        string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ED_Navigation_Diagram.jpg");
        bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        Console.WriteLine($"Diagram saved successfully: {outputPath}");
    }

    public static void Main()
    {
        var generator = new EDDiagramGenerator();
        generator.Generate();
    }
}

// Extension methods for rounded rectangles
public static class GraphicsExtensions
{
    public static void DrawRoundedRectangle(this Graphics g, Pen pen, int x, int y, int width, int height, int radius)
    {
        using (GraphicsPath path = new GraphicsPath())
        {
            AddRoundedRectangle(path, x, y, width, height, radius);
            g.DrawPath(pen, path);
        }
    }

    public static void FillRoundedRectangle(this Graphics g, Brush brush, int x, int y, int width, int height, int radius)
    {
        using (GraphicsPath path = new GraphicsPath())
        {
            AddRoundedRectangle(path, x, y, width, height, radius);
            g.FillPath(brush, path);
        }
    }

    private static void AddRoundedRectangle(GraphicsPath path, int x, int y, int width, int height, int radius)
    {
        path.AddArc(x, y, radius, radius, 180, 90);
        path.AddArc(x + width - radius, y, radius, radius, 270, 90);
        path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
        path.AddArc(x, y + height - radius, radius, radius, 90, 90);
        path.CloseFigure();
    }
}
