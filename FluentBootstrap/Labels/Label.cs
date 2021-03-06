﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Labels
{
    public interface ILabelCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class LabelWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ILabel : ITag
    {
    }

    public class Label<THelper> : Tag<THelper, Label<THelper>, LabelWrapper<THelper>>, ILabel, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal Label(IComponentCreator<THelper> creator)
            : base(creator, "span", Css.Label, Css.LabelDefault)
        {
        }
    }
}
