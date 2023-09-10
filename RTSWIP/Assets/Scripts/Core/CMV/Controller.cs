using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.CMV
{
    public class Controller<ModelType, ViewType> where ModelType : Model where ViewType : View
    {
        public ModelType Model;
        public ViewType View;

        public virtual void Intialize(ModelType model)
        {
            Model = model;
        }

        public virtual void BindView(ViewType view)
        {
            View = view;
        }
    }
}