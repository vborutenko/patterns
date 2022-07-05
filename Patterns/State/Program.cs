using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    //State is a behavioral design pattern that lets an object alter its behavior when its internal state changes.
    //It appears as if the object changed its class.

    //The State pattern suggests that you create new classes for all possible states of an object and extract
    //all state-specific behaviors into these classes.
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();
            document.SetState(new NewState());
            document.Publish();
        }
    }

    //with State pattern


    public class Document
    {
        private State _state;

        public Document()
        {
            SetState(new NewState());
        }

        public void SetState(State state)
        {
            _state = state;
            _state.SetDocument(this);
        }

        public void Publish()
        {
            _state.Publish();
        }
    }

    public abstract class State
    {
        protected Document _document;

        public void SetDocument(Document document)
        {
            _document = document;
        }

        public abstract void Publish();
    }

    public class NewState : State
    {
        public override void Publish()
        {
            _document.SetState(new DraftState());
        }
    }

    public class DraftState : State
    {
        public override void Publish()
        {
            if (true)
            {
                _document.SetState(new NewState());
            }

        }
    }



    // Without State pattern

    //public class Document
    //{

    //    public Guid DocumentOwner { get; set; }

    //    public DocumentState DocumentState { get; set; }

    //    public void Publish()
    //    {
    //        switch (DocumentState)
    //        {
    //            case DocumentState.Draft:
    //                DocumentState = DocumentState.Moderation;
    //                break;
    //            case DocumentState.Moderation:
    //                if (DocumentOwner == Guid.NewGuid())
    //                {
    //                    DocumentState = DocumentState.Published;
    //                }
    //                break;
    //            case DocumentState.Published:
    //                break;
    //            default:
    //                throw new ArgumentOutOfRangeException();
    //        }
    //    }
    //}

    //public enum DocumentState
    //{
    //    Draft,
    //    Moderation,
    //    Published
    //}

}
