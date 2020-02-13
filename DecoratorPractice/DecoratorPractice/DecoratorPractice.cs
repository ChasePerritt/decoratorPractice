using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Name: Chase Perritt
 * Date: 12 February 2020
 * File: DecoratorPractice.cs
 * Description: This file contains practice for the Decorator pattern (with its structure described in the decorator.dia file attached)
 */
namespace DecoratorPractice
{
    public interface Widget
    {
        void draw();
    }
    public sealed class TextField : Widget
    {
        private int width;
        private int height;

        public TextField(int w, int h)
        {
            width = w;
            height = h;
        }

        public void draw()
        {
            Console.WriteLine("a text field with width: " + width + ", height: " + height);
        }
    }
     public abstract class Decorator : Widget
    {
        private Widget wid;

        public Decorator(Widget w)
        {
            wid = w;
        }

        public virtual void draw()
        {
            wid.draw();
        }
    }
    public class BorderDecorator : Decorator
    {
        public BorderDecorator(Widget w) : base(w) { }

        public override void draw()
        {
            Console.Write("a border decorator, holding: ");
            base.draw();
        }
    }
    public class ScrollDecorator : Decorator
    {
        public ScrollDecorator(Widget w) : base(w) { }

        public override void draw()
        {
            Console.Write("a scroll decorator, holding: ");
            base.draw();
        }
    }
    public class FancyBorderDecorator : Decorator
    {
        public FancyBorderDecorator(Widget w) : base(w) { }

        public override void draw()
        {
            Console.Write("a fancy border decorator, holding: ");
            base.draw();
        }
    }
    public class DecoratorDemo
    {
        public static void Main(string[] args)
        {
            TextField txt = new TextField(2, 4);
            // ScrollDecorator added to TextField
            // BorderDecorator added to ScrollDecorated TextField
            Widget txtDeco = new BorderDecorator(new ScrollDecorator(txt));

            Console.Write("This is ");
            txtDeco.draw();

            Console.WriteLine();

            // FancyBorderDecorator added to BorderDecorated ScrollDecorated TextField
            txtDeco = new FancyBorderDecorator(txtDeco);

            Console.Write("This is ");
            txtDeco.draw();

            Console.ReadKey();
        }
    }
}
