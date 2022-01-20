using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConcreteMediator();
            var checkbox = new Checkbox(mediator);
            var textBox = new TextBox(mediator);
            mediator.TextBox = textBox;
            mediator.HideCheckbox = checkbox;

            checkbox.Check();

            Console.ReadKey();

        }
    }


    public abstract class Mediator
    {
        public abstract void Notify(Component sender, string @event);
    }

    public class ConcreteMediator : Mediator
    {
        public Checkbox HideCheckbox { get; set; }

        public TextBox TextBox { get; set; }


        public override void Notify(Component sender, string @event)
        {
            if (sender == HideCheckbox && @event == "check")
            {
                TextBox.IsVisible = !TextBox.IsVisible;
            }
        }
    }



    public abstract class Component
    {
        protected readonly Mediator _mediator;
        public bool IsVisible { get; set; }

        protected Component(Mediator mediator)
        {
            _mediator = mediator;
        }
    }

    public class TextBox : Component
    {
        public TextBox(Mediator mediator) : base(mediator)
        {
        }

        public void Click()
        {
            _mediator.Notify(this,"click");
        }
    }

    public class Checkbox : Component
    {
        public Checkbox(Mediator mediator) : base(mediator)
        {
        }

        public void Check()
        {
            Console.WriteLine("Checkbox was clicked.This info should be delivered to textbox through mediator");
            _mediator.Notify(this,"check");
        }
    }
}
